using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoboLib.GUI.Pages;
using RoboLib.Models;
using RoboLib.Extensions;
using Robo3DWpf;
using RoboLib;
using System.Threading;

namespace RoboJarvis.Comp.PathPlan.Pages
{
    public partial class PathPlanPage : ViewPage
    {
        JarvisRobot _robot;
        PathPlanner _pathPlanner;
        Robo3DUserControl _wpfControl;
        bool _needNewSimulation;

        public PathPlanPage()
        {
            InitializeComponent();
        }

        protected override void DefineBinding(ObjBase objBase)
        {
            base.DefineBinding(objBase);
            _pathPlanner = objBase as PathPlanner;
            _robot = RUtils.Map.GetComponent<JarvisRobot>(CompNames.Jarvis.ToString());
            _wpfControl = _robot.RoboModelWpfControl;

            rcbCurrentPathPatern.BindToProperty(_pathPlanner, "WorkingPathPatternName", false)
                .UseDataSource(_pathPlanner.PathPatternNames);

            var kinematics = _wpfControl.RobotKinematics;
            var joints = _wpfControl.MainJoints;

            rtbWorkingPatern.SetReadOnly(true);
            rtbWorkingPointNo.SetReadOnly(true);
            rtbWorkingPointNo.BindToProperty(_pathPlanner, "WorkingPathPatternPointNo", false);
            rcbSimulating.SetReadOnly(true);
            rcbSimulating.BindToProperty(kinematics, "IsSimulating", false);

            DisplayPatternInfo(_pathPlanner.WorkingPathPattern);
            _needNewSimulation = true;

            _pathPlanner.PropertyChanged += new PropertyChangedEventHandler(_pathPlanner_PropertyChanged);
        }

        void _pathPlanner_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "WorkingPathPatternPointNo")
            {
                dgvPathPoints.ClearSelection();
                foreach (DataGridViewRow row in dgvPathPoints.Rows)
                {
                    if (_pathPlanner.WorkingPathPatternPointNo - 1 == row.Index)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.Style.BackColor = Color.Yellow;
                            //cell.Selected = true;
                        }
                    }
                    else
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.Style.BackColor = Color.Empty;
                            //cell.Selected = false;
                        }
                    }
                }
            }
        }

        private void btnCreatePattern_Click(object sender, EventArgs e)
        {
            if (ValidPatternName(rtbCreateNewPattern.ValueText))
            {
                _pathPlanner.PathPatterns.Add(new PathPattern(rtbCreateNewPattern.ValueText));
                (rcbCurrentPathPatern.ValueControl as ComboBox).DataSource = _pathPlanner.PathPatternNames;
            }
        }

        private void btnRemovePattern_Click(object sender, EventArgs e)
        {
            if (_pathPlanner.PathPatterns.Count > 0)
            {
                _pathPlanner.WorkingPathPattern = _pathPlanner.PathPatterns.FirstOrDefault(x => x.Name == _pathPlanner.WorkingPathPatternName);
                _pathPlanner.PathPatterns.Remove(_pathPlanner.WorkingPathPattern);

                _pathPlanner.WorkingPathPattern = null;
                _pathPlanner.WorkingPathPatternName = null;
                rtbWorkingPatern.ValueText = _pathPlanner.WorkingPathPatternName;

                (rcbCurrentPathPatern.ValueControl as ComboBox).DataSource = _pathPlanner.PathPatternNames;
                DisplayPatternInfo(null);
            }
        }

        private void btnLoadPattern_Click(object sender, EventArgs e)
        {
            if (_pathPlanner.PathPatterns.Count > 0)
            {
                _pathPlanner.WorkingPathPattern = _pathPlanner.PathPatterns.FirstOrDefault(x => x.Name == _pathPlanner.WorkingPathPatternName);
                DisplayPatternInfo(_pathPlanner.WorkingPathPattern);
                rtbWorkingPatern.ValueText = _pathPlanner.WorkingPathPatternName;
                _needNewSimulation = true;
                _pathPlanner.WorkingPathPatternPointNo = 0;
            }
            else
            {
                MessageBox.Show("Path Patterns are Empty! " +
                    "\nPlease Create a new pattern then Select and Load", "Patterns Empty!", MessageBoxButtons.OK);
            }
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            if (_pathPlanner.WorkingPathPattern == null)
            {
                MessageBox.Show("Path Patterns are Empty! " +
                    "\nPlease Create a new pattern then Select and Load", "Patterns Empty!", MessageBoxButtons.OK);
                return;
            }

            var points = _pathPlanner.WorkingPathPattern.WorkPoints;
            if (string.IsNullOrEmpty(tbAddPointAt.Text))
            {
                points.Add(new WorkPoint(points.Count + 1, 0, 0, 0, 0, 0, 0, 0.5));
            }
            else
            {
                points.Insert(Convert.ToInt32(tbAddPointAt.Text) - 1, new WorkPoint(points.Count + 1, 0, 0, 0, 0, 0, 0, 0.5));
                ReOrderPointNumbers(points);
            }
            DisplayPatternInfo(_pathPlanner.WorkingPathPattern);
        }

        private void btnDeletePoint_Click(object sender, EventArgs e)
        {
            if (_pathPlanner.WorkingPathPattern == null)
            {
                MessageBox.Show("Path Patterns are Empty! " +
                    "\nPlease Create a new pattern then Select and Load", "Patterns Empty!", MessageBoxButtons.OK);
                return;
            }

            var points = _pathPlanner.WorkingPathPattern.WorkPoints;
            if (string.IsNullOrEmpty(tbRemovePointAt.Text))
            {
                points.RemoveAt(_pathPlanner.WorkingPathPattern.WorkPoints.Count - 1);
            }
            else
            {
                points.RemoveAt(Convert.ToInt32(tbRemovePointAt.Text) - 1);
                ReOrderPointNumbers(points);
            }
            DisplayPatternInfo(_pathPlanner.WorkingPathPattern);
        }

        private void tbAddPointAt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ValidatePointNo(tbAddPointAt);
            }
            catch (Exception ex) { }
        }

        private void tbRemovePointAt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ValidatePointNo(tbRemovePointAt);
            }
            catch (Exception ex) { }
        }

        private void tbCopyToPointAt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ValidatePointNo(tbCopyToPointAt);
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// Validate pattern name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool ValidPatternName(string name)
        {
            if (String.IsNullOrEmpty(rtbCreateNewPattern.ValueText))
            {
                MessageBox.Show("Path Pattern name is Empty! " +
                    "\nPlease type pattern name and then click Create", "Pattern Name Warning!", MessageBoxButtons.OK);
                return false;
            }
            else if (_pathPlanner.PathPatterns.Any(x => x.Name == rtbCreateNewPattern.ValueText))
            {
                MessageBox.Show("Path Pattern name is already exist! " +
                    "\nPlease type a new pattern name and then click Create", "Pattern Name Warning!", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Display path pattern point data on grid view
        /// </summary>
        /// <param name="pattern"></param>
        void DisplayPatternInfo(PathPattern pattern)
        {
            if (pattern != null)
            {
                if (pattern.WorkPoints.Count <= 0)
                {
                    // Create a default work point to execute bindings and dsplay
                    pattern.WorkPoints.Add(new WorkPoint(1, 0, 0, 0, 0, 0, 0, 0.5));
                }

                // Update the workiing pattern name
                rtbWorkingPatern.ValueText = pattern.Name;

                // This is to redraw the grid view with latest updates
                dgvPathPoints.DataSource = null;
                dgvPathPoints.DataSource = pattern.WorkPoints;

                dgvPathPoints.Columns["Xcoordinate"].Visible = false;
                dgvPathPoints.Columns["Ycoordinate"].Visible = false;
                dgvPathPoints.Columns["Zcoordinate"].Visible = false;
                dgvPathPoints.Columns["Name"].Visible = false;
                dgvPathPoints.Columns["Parent"].Visible = false;
                dgvPathPoints.Columns["ThisType"].Visible = false;
                dgvPathPoints.Columns["No"].ReadOnly = true;

                dgvPathPoints.DefaultCellStyle.Format = "0.##";
                dgvPathPoints.RowHeadersVisible = false;
                dgvPathPoints.AllowUserToResizeRows = false;
                dgvPathPoints.AllowUserToResizeColumns = false;
                dgvPathPoints.AutoGenerateColumns = false;
                dgvPathPoints.AllowUserToAddRows = true;
                dgvPathPoints.AllowUserToDeleteRows = true;

                dgvPathPoints.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                dgvPathPoints.DataSource = null;
                dgvPathPoints.ClearSelection();
                dgvPathPoints.Invalidate();
                dgvPathPoints.Refresh();
            }
        }

        /// <summary>
        /// Validate point No input
        /// </summary>
        /// <param name="txtBox"></param>
        /// <returns></returns>
        bool ValidatePointNo(TextBox txtBox)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers!");
                txtBox.Text = txtBox.Text.Remove(txtBox.Text.Length - 1);
                return false;
            }
            else if (txtBox.Name.Contains("Add") && (Convert.ToInt32(txtBox.Text) > _pathPlanner.WorkingPathPattern.WorkPoints.Count + 1 || Convert.ToInt32(txtBox.Text) <= 0))
            {
                MessageBox.Show("Please add points sequentially or middle!");
                txtBox.Text = "";
                return false;
            }
            else if (Convert.ToInt32(txtBox.Text) > _pathPlanner.WorkingPathPattern.WorkPoints.Count || Convert.ToInt32(txtBox.Text) <= 0)
            {
                MessageBox.Show("Please remove a valid point number!");
                txtBox.Text = "";
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Re-arrange point No based on the order in the Pattern
        /// </summary>
        /// <param name="points"></param>
        void ReOrderPointNumbers(List<WorkPoint> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i].No = points.IndexOf(points[i]) + 1;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (!_wpfControl.SimulationTimerEnabled)
            {
                _wpfControl.HomeSimulation();
            }
        }

        private void btnCopyAngles_Click(object sender, EventArgs e)
        {
            int i = _pathPlanner.WorkingPathPattern.WorkPoints.Count - 1; // Default copy to last row
            if (!string.IsNullOrEmpty(tbCopyToPointAt.Text))
            {
                i = Convert.ToInt32(tbCopyToPointAt.Text) - 1;
            }
            if (cbRoundAngles.Checked)
            {
                _pathPlanner.WorkingPathPattern.WorkPoints.ElementAt(i).J1Pos = Math.Round(_wpfControl.MainJoints[0].Angle);
                _pathPlanner.WorkingPathPattern.WorkPoints.ElementAt(i).J2Pos = Math.Round(_wpfControl.MainJoints[1].Angle);
                _pathPlanner.WorkingPathPattern.WorkPoints.ElementAt(i).J3Pos = Math.Round(_wpfControl.MainJoints[2].Angle);
                _pathPlanner.WorkingPathPattern.WorkPoints.ElementAt(i).J4Pos = Math.Round(_wpfControl.MainJoints[3].Angle);
                _pathPlanner.WorkingPathPattern.WorkPoints.ElementAt(i).J5Pos = Math.Round(_wpfControl.MainJoints[4].Angle);
                _pathPlanner.WorkingPathPattern.WorkPoints.ElementAt(i).J6Pos = Math.Round(_wpfControl.MainJoints[5].Angle);
            }
            else
            {
                _pathPlanner.WorkingPathPattern.WorkPoints.ElementAt(i).J1Pos = _wpfControl.MainJoints[0].Angle;
                _pathPlanner.WorkingPathPattern.WorkPoints.ElementAt(i).J2Pos = _wpfControl.MainJoints[1].Angle;
                _pathPlanner.WorkingPathPattern.WorkPoints.ElementAt(i).J3Pos = _wpfControl.MainJoints[2].Angle;
                _pathPlanner.WorkingPathPattern.WorkPoints.ElementAt(i).J4Pos = _wpfControl.MainJoints[3].Angle;
                _pathPlanner.WorkingPathPattern.WorkPoints.ElementAt(i).J5Pos = _wpfControl.MainJoints[4].Angle;
                _pathPlanner.WorkingPathPattern.WorkPoints.ElementAt(i).J6Pos = _wpfControl.MainJoints[5].Angle;
            }
            DisplayPatternInfo(_pathPlanner.WorkingPathPattern);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            gbPathPatterns.Enabled = false;
            if (_needNewSimulation)
            {
                if (!_wpfControl.SimulationTimerEnabled)
                {
                    _wpfControl.StartSimulateFwdKinematics(_pathPlanner.WorkingPathPattern);
                    btnRun.Text = ";";
                    _needNewSimulation = false;
                }
                else
                {
                    if (_wpfControl.SimulationTimerEnabled)
                    {
                        _wpfControl.StopSimulation();
                        btnRun.Text = "4";
                    }
                }
            }
            else
            {
                if (_wpfControl.SimulationTimerEnabled)
                {
                    _wpfControl.StopSimulation();
                    btnRun.Text = "4";
                }
                else
                {
                    if (_wpfControl.AllWorkPontsSimulated)
                    {
                        // Start simulation from the begining for current working pattern
                        _wpfControl.StartSimulateFwdKinematics(_pathPlanner.WorkingPathPattern);
                        btnRun.Text = ";";
                    }
                    else
                    {
                        // Continue simulate rest of the point in the current working pattern
                        _wpfControl.ContinueSimulateFwdKinematics();
                        btnRun.Text = ";";
                    }
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            gbPathPatterns.Enabled = true;
            _wpfControl.StopSimulation();
            _needNewSimulation = true;
            btnRun.Text = "4";
        }

        private void btnInvKinSimStart_Click(object sender, EventArgs e)
        {
            if (!_wpfControl.SimulationTimerEnabled)
            {
                _wpfControl.StartSimulateInvKinematics();
            }
        }
    }
}
