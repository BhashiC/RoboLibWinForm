using HelixToolkit.Wpf;
using RoboJarvis;
using RoboJarvis.Comp.Motion;
using RoboJarvis.Comp.PathPlan;
using RoboLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Robo3DWpf
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Robo3DUserControl : UserControl
    {
        Model3DGroup RobotArm = new Model3DGroup();
        ModelVisual3D sphereEndEffectorVisual = null;
        ModelVisual3D sphereEndPointVisual = null;
        GeometryModel3D _oldSelectedModel = null;
        Color _oldColor = Colors.White;

        internal Model3D SphereEndEffector { get; set; }
        internal Model3D SphereEndPont { get; set; }

        public bool IsAnimating { get; set; }

        /// <summary>
        /// True when inverse kinematics simulation is running
        /// </summary>
        bool InverseKinematicsSimulation { get; set; }

        /// <summary>
        /// General point for translate a given sphere
        /// </summary>
        Vector3D _spherePoint = new Vector3D();

        /// <summary>
        /// Inverse kinematics target point
        /// </summary>
        Vector3D _invKinematicsPoint;

        /// <summary>
        /// Timer to run simulation
        /// </summary>
        System.Windows.Forms.Timer SimulationTimer { get; set; }

        /// <summary>
        /// Watch for forward kinematics simulation
        /// </summary>
        public Stopwatch SimWatchFwdKinematics { get; set; }

        PathPattern ExecutingPathPattern = new PathPattern();

        List<WorkPoint> ExecutingWorkPoints = new List<WorkPoint>();

        /// <summary>
        /// True after simulate all the P2P points 
        /// </summary>
        public bool AllWorkPontsSimulated { get; set; }

       
        /// <summary>
        /// Sync Fwd kinematics current working point No
        /// </summary>
        public int WorkingPointNo { get; set; }

        PathPlanner _pathPlanner;

        /// <summary>
        /// Next target joint angles for forward kinematics simulation
        /// </summary>
        double[] NextJointAngles = new double[7];

        /// <summary>
        /// Initial joint angles for forward kinematics simulation
        /// </summary>
        double[] PreviousJointAngles = new double[7];

        /// <summary>
        /// Travel speed for the forward kinematics simulation
        /// </summary>
        double TravelSpeed = 1;

        /// <summary>
        /// Status of the simulation timer 
        /// </summary>
        public bool SimulationTimerEnabled
        {
            get
            {
                if (SimulationTimer != null)
                {
                    return SimulationTimer.Enabled;
                }
                else
                {
                    return true; //Default send is true to stop the movemnts
                }
            }
        }

        //provides render to model3d objects
        ModelVisual3D RoboticArm = new ModelVisual3D();

        /// <summary>
        /// Name and color of the 3D models
        /// </summary>
        Dictionary<string, Color> ModelsInfo { get; set; }

        /// <summary>
        /// Materials to color the 3D model
        /// </summary>
        MaterialGroup MaterialInfo { get; set; }

        /// <summary>
        /// Main Joints of the Robot (Except the Fixed Base)
        /// </summary>
        public List<Joint> MainJoints { get; set; }

        string modelsFolder = @"C:\RoboFactory\Ref\3DModels\";

        /// <summary>
        /// Initial offsets of the 3D model with the origin of the cordinate system (Fixed Base part)
        /// </summary>
        Vector3D _initPointModelOffSet;

        double _fixedBaseRadius = 117.5;  // mm 

        public Kinematics RobotKinematics { get; set; }

        public Robo3DUserControl()
        {
            InitializeComponent();
            ModelsInfo = new Dictionary<string, Color>();
            _initPointModelOffSet = new Vector3D();

            #region Adding 3D Models' names
            ModelsInfo.Add("Assembly - JointAxis1.stl", Colors.LawnGreen);
            ModelsInfo.Add("Assembly - JointAxis2.stl", Colors.LightSlateGray);
            ModelsInfo.Add("Assembly - JointAxis3.stl", Colors.LawnGreen);
            ModelsInfo.Add("Assembly - JointAxis4.stl", Colors.LightSlateGray);
            ModelsInfo.Add("Assembly - JointAxis5.stl", Colors.LawnGreen);
            ModelsInfo.Add("Assembly - JointAxis6.stl", Colors.LightSlateGray);
            ModelsInfo.Add("Assembly - JointFixed.stl", Colors.LightSlateGray);
            ModelsInfo.Add("Assembly - EndPoint.stl", Colors.Red);
            #endregion

            DataContext = this;
            RoboticArm.Content = Initialize_Environment(ModelsInfo);
            RobotKinematics = new Kinematics(MainJoints, _initPointModelOffSet, this);
            viewPort3d.RotateGesture = new MouseGesture(MouseAction.RightClick);
            viewPort3d.PanGesture = new MouseGesture(MouseAction.LeftClick);
            viewPort3d.Children.Add(RoboticArm);

            /** Debug sphere to check in which point the joint is rotating**/
            var builder = new MeshBuilder(true, true);
            var position = new Point3D(0, 0, 0);
            builder.AddSphere(position, 12);
            SphereEndEffector = new GeometryModel3D(builder.ToMesh(), Materials.Blue);
            sphereEndEffectorVisual = new ModelVisual3D();
            sphereEndEffectorVisual.Content = SphereEndEffector;
            viewPort3d.Children.Add(sphereEndEffectorVisual);

            builder = new MeshBuilder(true, true);
            position = new Point3D(0, 0, 0); ///267.33, 0, 562
            builder.AddSphere(position, 12);
            SphereEndPont = new GeometryModel3D(builder.ToMesh(), Materials.Red);
            sphereEndPointVisual = new ModelVisual3D();
            sphereEndPointVisual.Content = SphereEndPont;
            viewPort3d.Children.Add(sphereEndPointVisual);

            viewPort3d.ShowFrameRate = false;
            viewPort3d.ShowFieldOfView = false;
            viewPort3d.ShowCoordinateSystem = true;
            viewPort3d.ShowViewCube = true;
            viewPort3d.ShowCameraInfo = false;
            viewPort3d.ShowTriangleCountInfo = false;
            viewPort3d.ShowCameraTarget = true;

            viewPort3d.Camera.LookDirection = new Vector3D(-1317, -1207, -910);
            viewPort3d.Camera.UpDirection = new Vector3D(0.000, 0.000, 1.000);
            viewPort3d.Camera.Position = new Point3D(970, 820, 924);

            double[] angles = { MainJoints[0].Angle, MainJoints[1].Angle, MainJoints[2].Angle, MainJoints[3].Angle, MainJoints[4].Angle, MainJoints[5].Angle, MainJoints[7].Angle };
            var intitvec = RobotKinematics.ForwardKinematics(angles);

            SimulationTimer = new System.Windows.Forms.Timer();
            SimulationTimer.Interval = 5;
            SimulationTimer.Tick += new System.EventHandler(simulationTimer_Tick);

            SimWatchFwdKinematics = new Stopwatch();
        }

        void simulationTimer_Tick(object sender, EventArgs e)
        {
            double[] angles = { MainJoints[0].Angle, MainJoints[1].Angle, MainJoints[2].Angle, MainJoints[3].Angle, MainJoints[4].Angle, MainJoints[5].Angle, MainJoints[7].Angle };
            //Inverse Kinematics==============================>
            if (InverseKinematicsSimulation)
            {
                angles = RobotKinematics.InverseKinematics(_invKinematicsPoint, angles);
                MainJoints[0].Angle = angles[0];
                MainJoints[1].Angle = angles[1];
                MainJoints[2].Angle = angles[2];
                MainJoints[3].Angle = angles[3];
                MainJoints[4].Angle = angles[4];
                MainJoints[5].Angle = angles[5];
                MainJoints[7].Angle = angles[6];

                if ((--RobotKinematics.MaximumSimulationSteps) <= 0)
                {
                    IsAnimating = false;
                    RobotKinematics.IsSimulating = false;
                    InverseKinematicsSimulation = false;
                    SimulationTimer.Stop();
                    return;
                }
            }
            //Forward Kinematics==============================>
            else
            {
                bool[] ReachedJoints = new bool[7];
                for (int i = 0; i < NextJointAngles.Count(); i++)
                {
                    if (NextJointAngles[i] - 2 <= MainJoints[i].Angle && NextJointAngles[i] + 2 >= MainJoints[i].Angle)
                    {
                        ReachedJoints[i] = true;
                    }
                }

                if (ReachedJoints.All(x => x == true))
                {
                    IsAnimating = false;
                    RobotKinematics.IsSimulating = false;
                    SimulationTimer.Stop();
                    SimWatchFwdKinematics.Stop();
                    SimWatchFwdKinematics.Reset();
                    MainJoints[0].Angle = NextJointAngles[0];
                    MainJoints[1].Angle = NextJointAngles[1];
                    MainJoints[2].Angle = NextJointAngles[2];
                    MainJoints[3].Angle = NextJointAngles[3];
                    MainJoints[4].Angle = NextJointAngles[4];
                    MainJoints[5].Angle = NextJointAngles[5];
                    MainJoints[7].Angle = NextJointAngles[6];
                    DrawSphere(0, 0, 0, SphereEndPont);
                    WorkingPointNo++;
                    if (WorkingPointNo <= ExecutingWorkPoints.Count)
                    {
                        _pathPlanner.WorkingPathPatternPointNo = WorkingPointNo;
                        AllWorkPontsSimulated = false;
                        CalculateFwdKinSimuData(ExecutingWorkPoints[WorkingPointNo - 1]);
                    }
                    else
                    {
                        AllWorkPontsSimulated = true;
                    }
                }
                else
                {
                    angles = RobotKinematics.SyncFwdKinematicAngles(NextJointAngles, PreviousJointAngles, TravelSpeed);

                    MainJoints[0].Angle = angles[0];
                    MainJoints[1].Angle = angles[1];
                    MainJoints[2].Angle = angles[2];
                    MainJoints[3].Angle = angles[3];
                    MainJoints[4].Angle = angles[4];
                    MainJoints[5].Angle = angles[5];
                }
            }
        }
       
        private Model3DGroup Initialize_Environment(Dictionary<string, Color> modelsInfo)
        {
            try
            {
                ModelImporter import = new ModelImporter();
                MainJoints = new List<Joint>();
                var joints = new List<Joint>();
                                          
                foreach (string modelName in modelsInfo.Keys)
                {
                    //Initialize the material information for color the 3D models 
                    MaterialInfo = new MaterialGroup();
                    Color mainColor = Colors.White;
                    EmissiveMaterial emissMat = new EmissiveMaterial(new SolidColorBrush(Colors.White));
                    DiffuseMaterial diffMat = new DiffuseMaterial(new SolidColorBrush(Colors.LightGray));
                    SpecularMaterial specMat = new SpecularMaterial(new SolidColorBrush(Colors.Ivory), 200);
                    MaterialInfo.Children.Add(emissMat);
                    MaterialInfo.Children.Add(diffMat);
                    MaterialInfo.Children.Add(specMat);

                    //Adding 3D models to robot
                    var link = import.Load(modelsFolder + modelName);
                    GeometryModel3D model = link.Children[0] as GeometryModel3D;
                    model.Material = MaterialInfo;
                    model.BackMaterial = MaterialInfo;
                    Joint newJoint = new Joint(link, this);
                    joints.Add(newJoint);
                    RobotArm.Children.Add(newJoint.Model);
                }

                //Assign color for each model
                int i = 0;
                foreach (Color color in modelsInfo.Values)
                {
                    InitModelColor(joints[i], color);
                    i++;
                }

                MKSAxis axis1 = RUtils.Map.GetComponent<MKSAxis>(CompNames.Joint1.ToString());
                MKSAxis axis2 = RUtils.Map.GetComponent<MKSAxis>(CompNames.Joint2.ToString());
                MKSAxis axis3 = RUtils.Map.GetComponent<MKSAxis>(CompNames.Joint3.ToString());
                MKSAxis axis4 = RUtils.Map.GetComponent<MKSAxis>(CompNames.Joint4.ToString());
                MKSAxis axis5 = RUtils.Map.GetComponent<MKSAxis>(CompNames.Joint5.ToString());
                MKSAxis axis6 = RUtils.Map.GetComponent<MKSAxis>(CompNames.Joint6.ToString());
                _pathPlanner = RUtils.Map.GetComponent<PathPlanner>(CompNames.PathPlan.ToString());

                _initPointModelOffSet.X = joints[6].Model.Bounds.Location.X + _fixedBaseRadius;
                _initPointModelOffSet.Y = joints[6].Model.Bounds.Location.Y + _fixedBaseRadius;
                _initPointModelOffSet.Z = joints[6].Model.Bounds.Location.Z;
                
                joints[0].InitMainJoint("Joint1", axis1.LowerLimit, axis1.UpperLimit, 0, 0, 1, 0, 0, 0, null);
                joints[1].InitMainJoint("Joint2", axis2.LowerLimit, axis2.UpperLimit, 0, 1, 0, _initPointModelOffSet.X, _initPointModelOffSet.Y, 282 + _initPointModelOffSet.Z, null);
                joints[2].InitMainJoint("Joint3", axis3.LowerLimit, axis3.UpperLimit, 0, 1, 0, _initPointModelOffSet.X, _initPointModelOffSet.Y, 562 + _initPointModelOffSet.Z, null);
                joints[3].InitMainJoint("Joint4", axis4.LowerLimit, axis4.UpperLimit, 1, 0, 0, _initPointModelOffSet.X, _initPointModelOffSet.Y, 562 + _initPointModelOffSet.Z, null);
                joints[4].InitMainJoint("Joint5", axis5.LowerLimit, axis5.UpperLimit, 0, 1, 0, _initPointModelOffSet.X + 171.83, _initPointModelOffSet.Y, 562 + _initPointModelOffSet.Z, null);
                joints[5].InitMainJoint("Joint6", axis6.LowerLimit, axis6.UpperLimit, 1, 0, 0, _initPointModelOffSet.X + 268.83, _initPointModelOffSet.Y, 562 + _initPointModelOffSet.Z, null);

                //Fixed base aded as the last Main Joint without a Name
                MainJoints.Add(joints[0]);
                MainJoints.Add(joints[1]);
                MainJoints.Add(joints[2]);
                MainJoints.Add(joints[3]);
                MainJoints.Add(joints[4]);
                MainJoints.Add(joints[5]);
                MainJoints.Add(joints[6]);
                MainJoints.Add(joints[7]);
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Error:" + e.StackTrace);
            }
            return RobotArm;
        }

        Color InitModelColor(Joint joint, Color newColor)
        {
            Model3DGroup models = joint.Model as Model3DGroup;
            return ChangeModelColor(models.Children[0] as GeometryModel3D, newColor);
        }

        Color ChangeModelColor(GeometryModel3D pModel, Color newColor)
        {
            if (pModel == null)
                return _oldColor;

            Color previousColor = Colors.Black;
            MaterialGroup mg = (MaterialGroup)pModel.Material;
            if (mg.Children.Count > 0)
            {
                try
                {
                    previousColor = ((EmissiveMaterial)mg.Children[0]).Color;
                    ((EmissiveMaterial)mg.Children[0]).Color = newColor;
                    ((DiffuseMaterial)mg.Children[1]).Color = newColor;
                }
                catch (Exception exc)
                {
                    previousColor = _oldColor;
                }
            }
            return previousColor;
        }
        
        void ViewPort3D_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePos = e.GetPosition(viewPort3d);
            PointHitTestParameters hitParams = new PointHitTestParameters(mousePos);
            //VisualTreeHelper.HitTest(viewPort3d, null, ResultCallback, hitParams);
        }

        //public HitTestResultBehavior ResultCallback(HitTestResult result)
        //{
        //    // Did we hit 3D?
        //    RayHitTestResult rayResult = result as RayHitTestResult;
        //    if (rayResult != null)
        //    {
        //        // Did we hit a MeshGeometry3D?
        //        RayMeshGeometry3DHitTestResult rayMeshResult = rayResult as RayMeshGeometry3DHitTestResult;
        //        _sphere.Transform = new TranslateTransform3D(new Vector3D(rayResult.PointHit.X, rayResult.PointHit.Y, rayResult.PointHit.Z));

        //        if (rayMeshResult != null)
        //        {
        //            // Yes we did!
        //        }
        //    }
        //    return HitTestResultBehavior.Continue;
        //}

        void ViewPort3D_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Perform the hit test on the mouse's position relative to the viewport.
            HitTestResult result = VisualTreeHelper.HitTest(viewPort3d, e.GetPosition(viewPort3d));
            RayMeshGeometry3DHitTestResult mesh_result = result as RayMeshGeometry3DHitTestResult;

            if (_oldSelectedModel != null)
                UnselectModel();

            if (mesh_result != null)
            {
                SelectModel(mesh_result.ModelHit);
            }
        }

        void SelectModel(Model3D pModel)
        {
            try
            {
                Model3DGroup models = ((Model3DGroup)pModel);
                _oldSelectedModel = models.Children[0] as GeometryModel3D;
            }
            catch (Exception exc)
            {
                _oldSelectedModel = (GeometryModel3D)pModel;
            }
            _oldColor = ChangeModelColor(_oldSelectedModel, ColorHelper.HexToColor("#ff3333"));
        }

        void UnselectModel()
        {
            ChangeModelColor(_oldSelectedModel, _oldColor);
        }

        Vector3D vec = new Vector3D();
        internal void DoForwardKinematics()
        {
            double[] angles = { MainJoints[0].Angle, MainJoints[1].Angle, MainJoints[2].Angle, MainJoints[3].Angle, MainJoints[4].Angle, MainJoints[5].Angle, MainJoints[7].Angle };
            vec = RobotKinematics.ForwardKinematics(angles);
        }

        public void UpdateEndEffectorPosition()
        {
            double x = RobotKinematics.EndEffectorXCoordinate = MainJoints[7].Model.Bounds.Location.X;
            double y = RobotKinematics.EndEffectorYCoordinate = MainJoints[7].Model.Bounds.Location.Y;
            double z = RobotKinematics.EndEffectorZCoordinate = MainJoints[7].Model.Bounds.Location.Z;
            DrawSphere(x, y, z, SphereEndEffector);
        }

        /// <summary>
        /// Draw sphere on a given point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="sphere"></param>
        public void DrawSphere(double x, double y, double z, Model3D sphere)
        {
            try
            {
                _spherePoint.X = x;
                _spherePoint.Y = y;
                _spherePoint.Z = z;
                sphere.Transform = new TranslateTransform3D(_spherePoint);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Start robot move to the End Point position
        /// </summary>
        public void StartSimulateInvKinematics()
        {            
            _invKinematicsPoint.X = RobotKinematics.EndPointXCoordinate;
            _invKinematicsPoint.Y = RobotKinematics.EndPointYCoordinate;
            _invKinematicsPoint.Z = RobotKinematics.EndPointZCoordinate;

            SphereEndEffector.Transform = new TranslateTransform3D(_invKinematicsPoint);

            RobotKinematics.MaximumSimulationSteps = 5000;
            IsAnimating = true;
            RobotKinematics.IsSimulating = true;
            InverseKinematicsSimulation = true; 
            SimulationTimer.Start();
        }

        /// <summary>
        /// Stop robot movement
        /// </summary>
        public void StopSimulation()
        {
            IsAnimating = false;
            RobotKinematics.IsSimulating = false;
            SimulationTimer.Stop();
            InverseKinematicsSimulation = false;
            RobotKinematics.MaximumSimulationSteps = 0;
            SimWatchFwdKinematics.Stop();
        }

        public void HomeSimulation()
        {
            ExecutingPathPattern = null;
            ExecutingWorkPoints = new List<WorkPoint> { new WorkPoint(1, 0, 0, 0, 0, 0, 0, 0.5) };
            TravelSpeed = 0.5;
            AllWorkPontsSimulated = false;
            SimWatchFwdKinematics.Reset();
            CalculateFwdKinSimuData(ExecutingWorkPoints[0]);
            WorkingPointNo = 1;
            _pathPlanner.WorkingPathPatternPointNo = 0;
        }

        public void StartSimulateFwdKinematics(PathPattern pathPattern, double speed = 1)
        {
            ExecutingPathPattern = null;
            ExecutingPathPattern = pathPattern;
            ExecutingWorkPoints = pathPattern.WorkPoints;
            WorkingPointNo = _pathPlanner.WorkingPathPatternPointNo = 1;
            TravelSpeed = speed;
            AllWorkPontsSimulated = false;
            SimWatchFwdKinematics.Reset();
            CalculateFwdKinSimuData(ExecutingWorkPoints[0]);               
        }

        public void ContinueSimulateFwdKinematics()
        {
            IsAnimating = true;
            RobotKinematics.IsSimulating = true;
            SimulationTimer.Start();
            SimWatchFwdKinematics.Start();
        }

        void CalculateFwdKinSimuData(WorkPoint wp)
        {
            var num = wp.No;
            NextJointAngles[0] = wp.J1Pos;
            NextJointAngles[1] = wp.J2Pos;
            NextJointAngles[2] = wp.J3Pos;
            NextJointAngles[3] = wp.J4Pos;
            NextJointAngles[4] = wp.J5Pos;
            NextJointAngles[5] = wp.J6Pos;
            NextJointAngles[6] = 0;

            Vector3D val = RobotKinematics.ForwardKinematics(NextJointAngles, true);
            DrawSphere(val.X, val.Y, val.Z, SphereEndPont);
            //SphereEndPont.Transform = new TranslateTransform3D(new Vector3D(val.X, val.Y, val.Z));

            RobotKinematics.EndPointXCoordinate = val.X;
            RobotKinematics.EndPointYCoordinate = val.Y;
            RobotKinematics.EndPointZCoordinate = val.Z;

            PreviousJointAngles[0] = MainJoints[0].Angle;
            PreviousJointAngles[1] = MainJoints[1].Angle;
            PreviousJointAngles[2] = MainJoints[2].Angle;
            PreviousJointAngles[3] = MainJoints[3].Angle;
            PreviousJointAngles[4] = MainJoints[4].Angle;
            PreviousJointAngles[5] = MainJoints[5].Angle;
            PreviousJointAngles[6] = 0;

            var speeds = RobotKinematics.CalculateSyncSpeeds(NextJointAngles, PreviousJointAngles, wp.Speed);

            IsAnimating = true;
            RobotKinematics.IsSimulating = true;
            SimulationTimer.Start();
            SimWatchFwdKinematics.Start();
        }
    }
}
