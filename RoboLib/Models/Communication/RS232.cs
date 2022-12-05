using Newtonsoft.Json;
using RoboLib.Extensions;
using RoboLib.Models.Communication.Pages;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib.Models.Communication
{
    public class RS232 : ComponentBase
    {

        SerialPort _port;
        readonly object _lockPort = new object();

        [JsonIgnore]
        public List<string> ComPorts { get; set; }
        public string ComPort { get; set; }

        /// <summary>
        /// List of baud Rates
        /// </summary>
        [JsonIgnore]
        public List<string> BaudRates { get; set; }

        /// <summary>
        /// Selected Baud Rate
        /// </summary>
        public string BaudRate { get; set; }

        /// <summary>
        /// Selected Hand Shake type
        /// </summary>
        public Handshake HandShake { get; set; }

        /// <summary>
        /// Number of data bits
        /// </summary>
        public int DataBits { get; set; }

        /// <summary>
        /// Selected Parity type
        /// </summary>
        public Parity Parity { get; set; }

        /// <summary>
        /// Selected Stop Bit type
        /// </summary>
        public StopBits StopBits { get; set; }

        /// <summary> 
        /// Selected New Line type
        /// </summary>
        public NewLines NewLine { get; set; }

        /// <summary>
        /// Communication Timeout
        /// </summary>
        [BindingTools(Unit = Units.msec)]
        public int Timeout { get; set; }

        /// <summary>
        /// Command List
        /// </summary>
        public List<string> Commands { get; set; }

        /// <summary>
        /// Test Command
        /// </summary>
        [JsonIgnore]
        public string Command { get; set; }

        /// <summary>
        /// Response
        /// </summary>
        [JsonIgnore]
        public string Response { get; set; }

        /// <summary>
        /// True when port is connected
        /// </summary>
        [JsonIgnore]
        public bool Connected { get; private set; }

        /// <summary>
        /// Communication command list, for help
        /// </summary>
        [JsonIgnore]
        public List<string> CommandList { get; set; }
        
        public RS232()
        {
            DataBits = 8;
            Parity = Parity.None;
            StopBits = StopBits.One;
            NewLine = NewLines.CR;
            Timeout = 20000; //later adit this to 1sec
            BaudRate = "115200";
        }

        protected override void OnInitializeRecurse() 
        {
            base.OnInitializeRecurse();
            ComPorts = SerialPort.GetPortNames().ToList();
            BaudRates = BaudRates ?? new List<string>() 
            { 
                "110", "300", "1200", "2400", "4800", "9600", "19200", 
                "38400", "57600", "115200", "230400", "460800", "921600 " 
            };
            Commands = new List<string>();
        }

        protected override void OnBeforeDestroyRecurse()
        {
            base.OnBeforeDestroyRecurse();
            this.DoDisconnect();
        }

        protected override void DefinePages(Dictionary<string, Type> pageTypes)
        {
            base.DefinePages(pageTypes);
            pageTypes.Add("Communication", typeof(RS232Page));
        }

        /// <summary>
        /// Connect to Port with given settings
        /// </summary>
        public void Connect()
        {
            try
            {
                DoConnect();
            }
            catch (Exception ex)
            {
                throw new RException(string.Format("{0} is fail to Connect!", this.Name), ex);
            }
            finally 
            {
                Connected = _port.IsOpen;
            }
        }

        void DoConnect()
        {
            if (_port != null && _port.IsOpen)
            {
                _port.Close();
            }
            _port = new SerialPort(ComPort, int.Parse(BaudRate), Parity, DataBits, StopBits);
            _port.DtrEnable = true;
            _port.Handshake = HandShake;
            _port.ReadTimeout = Timeout;
            _port.WriteTimeout = Timeout;
            _port.NewLine = NewLine.AsString();
            _port.Open();
        }
       
                                 
        /// <summary>
        /// Disconnect Port
        /// </summary>
        public void Disconnect() 
        {
            try
            {
                DoDisconnect();
            }
            catch (Exception ex)
            {
                throw new RException(string.Format("{0} is fail to Disconnect!", this.Name), ex);
            }
            finally 
            {
                Connected = _port.IsOpen;
            }
        }

        void DoDisconnect() 
        {
            if (_port != null && _port.IsOpen)
            {
                _port.Close();
            }
        }

        /// <summary>
        /// Send a cmd and wait for the response
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="waitForRes"></param>
        /// <returns></returns>
        public string ReadPortCmd(string cmd, bool waitForRes = true)
        {
            lock (_lockPort)
            {
                try
                {
                    if (cmd == null)
                    {
                        throw new RException(string.Format("{0} ReadPortCmd fail, Command is null!", this.Name));
                    }
                    else if (_port == null || !_port.IsOpen)
                    {
                        throw new RException(string.Format("{0} ReadPortCmd fail, Port is null or not Connected!", this.Name));
                    }
                    return DoReadPortCmd(cmd, waitForRes);
                }
                catch (Exception ex)
                {
                    throw new RException(string.Format("{0} is fail to ReadPortCmd!", this.Name), ex);
                }
            }
        }

        string DoReadPortCmd(string cmd, bool waitForRes = true) 
        {
            // Clear buffer
            _port.ReadExisting();
            _port.Write(cmd);
            // Wait to get data here
            string response = string.Empty;
            if (waitForRes)
            {
                response = _port.ReadLine();
            }
            Response = response.Trim();
            return Response;
        }
    }
}
