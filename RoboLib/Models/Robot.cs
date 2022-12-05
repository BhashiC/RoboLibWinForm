using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RoboLib.Models
{
    public class Robot : ComponentBase
    {
        /// <summary>
        /// Program directory
        /// </summary>
        [ViewMode(PropertyViewModes.ReadOnly)]
        public string RootFolder { get; set; }

        /// <summary>
        /// Plugin directory
        /// </summary>
        [JsonIgnore]
        public string PluginFolder
        {
            get
            {
                return string.Format(@"{0}\Plugin", RootFolder);
            }
        }

        /// <summary>
        /// Backup Json directory
        /// </summary>
        [JsonIgnore]
        public string BackupJsonFolder
        {
            get
            {
                return string.Format(@"{0}\BackupJson", RootFolder);
            }
        }

        public static Robot Instance
        {
            get
            {
                return SystemBuilder.Instance.Robot;
            }
        }

        public Robot()
        {
            string rootFolder = @"C:\RoboFactory";
            var entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {

                rootFolder = string.Format(@"{0}\{1}", rootFolder, entryAssembly.GetName().Name);
            }
            RootFolder = rootFolder;
        }

        internal static Robot CreateRobot(string robotName, Type tRobot)
        {
            Robot robot = null;
            robot = (Robot)Activator.CreateInstance(tRobot);
            robot.SetCoreInfo(robotName, tRobot.Name, "NA", null);
                
            #region Json deserialization
            string robotJson = string.Format(@"{0}\{1}.json", robot.RootFolder, robotName);
            if (File.Exists(robotJson))
            {
                try
                {
                    string jsonText = File.ReadAllText(robotJson);
                    robot = JsonConvert.DeserializeObject<Robot>(jsonText, JsonDefaultSettings);
                    
                    if (robot == null)
                    {
                        robot = new Robot();
                    }
                    robot.RegisterComponent(null); // This help to add machine itself, as well as make sure components added to json file get registered.
                }
                catch (Exception ex)
                {
                    throw new RException("Error Reading json file. Default Robot is created! Please verify json file.", ex);
                }
            }
            #endregion
            return robot;
        }

        static JsonSerializerSettings JsonDefaultSettings = new JsonSerializerSettings()
        {
            ContractResolver = new DefaultPropertyOrderContractResolver(),
            Converters = CustomJsonSettings.DefaultConverters(),
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented,
            Error = HandleDeserializationError
        };

        static void HandleDeserializationError(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs errorArgs)
        {
            errorArgs.ErrorContext.Handled = true;
            throw new RException(errorArgs.ErrorContext.Error.ToString());
        }

        /// <summary>
        /// Save the whole machine to file
        /// </summary>
        /// <remarks>The machine will be saved as [Name.json] under the root folder.  A copy of the same json file for back up will be performed all the times before the machine is saved.</remarks>
        public void SaveRobot()
        {
            try
            {
                string robotJson = string.Format(@"{0}\{1}.json", RootFolder, Name);
                // Back up first
                if (File.Exists(robotJson))
                {
                    string robotJsonBackup = string.Format(@"{0}\{1}-{2}.json", BackupJsonFolder, Name, DateTime.Now.ToString("dd-MMM-yy-HHmmss"));
                    EnsureDirectory(Path.GetDirectoryName(robotJsonBackup));
                    File.Copy(robotJson, robotJsonBackup, true);
                }

                EnsureDirectory(Path.GetDirectoryName(robotJson));
                var jsonText = JsonConvert.SerializeObject(this, JsonDefaultSettings);
                File.WriteAllText(robotJson, jsonText);
            }
            catch (Exception ex) 
            {
                throw new RException("Robot Saving Error!", ex);
            }
        }

        public void EnsureDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch { }
        }
    }
}
