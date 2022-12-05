using RoboLib;
using RoboLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Robo3DWpf
{
    public class Kinematics : ObjBase
    {
        Transform3DGroup F0; //A fixed translation for base to center with 3D cordinate origin
        Transform3DGroup F1;
        Transform3DGroup F2;
        Transform3DGroup F3;
        Transform3DGroup F4;
        Transform3DGroup F5;
        Transform3DGroup F6;
        Transform3DGroup F7;
        RotateTransform3D R;
        TranslateTransform3D T;

        /// <summary>
        /// Main Joints of the Robot (Except the Fixed Base)
        /// </summary>
        List<Joint> MainJoints { get; set; }

        /// <summary>
        /// Initial offsets of the 3D model with the origin of the cordinate system (Fixed Base part)
        /// </summary>
        Vector3D _initPointModelOffSet;

        //End Point (Target Point) coordinates
        double _endPointX;
        [BindingTools(Unit = Units.mm, DisplayFormat = "#0.##")]
        public double EndPointXCoordinate
        {
            get
            {
                return _endPointX;
            }
            set
            {
                _endPointX = value;
                _userControl.DrawSphere(_endPointX, _endPointY, _endPointZ, _userControl.SphereEndPont);
            }
        }

        double _endPointY;
        [BindingTools(Unit = Units.mm, DisplayFormat = "#0.##")]
        public double EndPointYCoordinate
        {
            get
            {
                return _endPointY;
            }
            set
            {
                _endPointY = value;
                _userControl.DrawSphere(_endPointX, _endPointY, _endPointZ, _userControl.SphereEndPont);
            }
        }

        double _endPointZ;
        [BindingTools(Unit = Units.mm, DisplayFormat = "#0.##")]
        public double EndPointZCoordinate
        {
            get
            {
                return _endPointZ;
            }
            set
            {
                _endPointZ = value;
                _userControl.DrawSphere(_endPointX, _endPointY, _endPointZ, _userControl.SphereEndPont);
            }
        }

        //End Effector (Robot Arm Tool Tip) coordinates
        [BindingTools(Unit = Units.mm, DisplayFormat = "#0.##")]
        public double EndEffectorXCoordinate { get; set; }
        [BindingTools(Unit = Units.mm, DisplayFormat = "#0.##")]
        public double EndEffectorYCoordinate { get; set; }
        [BindingTools(Unit = Units.mm, DisplayFormat = "#0.##")]
        public double EndEffectorZCoordinate { get; set; }

        /// <summary>
        /// True when 3D model is moving 
        /// </summary>
        public bool IsSimulating { get; set; }

        /// <summary>
        /// Maximum num of stepes for the Target point 
        /// (while running exceeding this will auto stop the simulation)
        /// </summary>
        public int MaximumSimulationSteps { get; set; }

        /// <summary>
        /// Learning Rates of the each joints 
        /// (weights - more weight will effect to change that angle more to achive the desired point)
        /// </summary>
        List<double> LearningRates { get; set; }

        /// <summary>
        /// Sampling step size of the angle 
        /// </summary>
        double SamplingAngle { get; set; }

        /// <summary>
        /// Simulation will stop if |DistanceVector| is below the DistanceThreshold
        /// </summary>
        double DistanceThreshold { get; set; }

        /// <summary>
        /// Sync speeds of each joint for PtoP Fwd kinematics
        /// </summary>
        public double[] SyncFwdKinematicsSpeeds { get; set; }

        Robo3DUserControl _userControl;

        public Kinematics(List<Joint> mainJoints, Vector3D initPointlOffSet, Robo3DUserControl userControl)
        {
            MainJoints = mainJoints;
            _initPointModelOffSet = initPointlOffSet;
            _userControl = userControl;

            LearningRates = new List<double>() { 0.05, 0.07, 0.07, 0.005, 0.7, 0.005, 0.00 };
            SamplingAngle = 0.2; //degree
            DistanceThreshold = 0.7; //mm

            EndPointXCoordinate = 300;
            EndPointYCoordinate = 0;
            EndPointZCoordinate = 562;
            SyncFwdKinematicsSpeeds = new double[6] { 1, 1, 1, 1, 1, 1 };
        }

        #region Forward Kinematics================================>
        public Vector3D ForwardKinematics(double[] jointAngles, bool OnlyNeedCalculation = false)
        {
            F0 = new Transform3DGroup(); // Fixed Transformation to relocate 3D Model on to the origin of the 3D Space
            T = new TranslateTransform3D(-_initPointModelOffSet.X, -_initPointModelOffSet.Y, -_initPointModelOffSet.Z);
            F0.Children.Add(T);

            F1 = new Transform3DGroup();
            R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(MainJoints[0].RotAxisX, MainJoints[0].RotAxisY, MainJoints[0].RotAxisZ), jointAngles[0]), new Point3D(MainJoints[0].RotPointX, MainJoints[0].RotPointY, MainJoints[0].RotPointZ));
            F1.Children.Add(F0);
            F1.Children.Add(R);

            F2 = new Transform3DGroup();
            T = new TranslateTransform3D(0, 0, 0);
            R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(MainJoints[1].RotAxisX, MainJoints[1].RotAxisY, MainJoints[1].RotAxisZ), jointAngles[1]), new Point3D(MainJoints[1].RotPointX, MainJoints[1].RotPointY, MainJoints[1].RotPointZ));
            F2.Children.Add(T); // Translation should Add 1st
            F2.Children.Add(R); // Secondly Rotation should Add
            F2.Children.Add(F1); // Finally Previous Transformation must Add (FORWARD Kinematics) 

            F3 = new Transform3DGroup();
            T = new TranslateTransform3D(0, 0, 0);
            R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(MainJoints[2].RotAxisX, MainJoints[2].RotAxisY, MainJoints[2].RotAxisZ), jointAngles[2]), new Point3D(MainJoints[2].RotPointX, MainJoints[2].RotPointY, MainJoints[2].RotPointZ));
            F3.Children.Add(T);
            F3.Children.Add(R);
            F3.Children.Add(F2);

            F4 = new Transform3DGroup();
            T = new TranslateTransform3D(0, 0, 0);
            R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(MainJoints[3].RotAxisX, MainJoints[3].RotAxisY, MainJoints[3].RotAxisZ), jointAngles[3]), new Point3D(MainJoints[3].RotPointX, MainJoints[3].RotPointY, MainJoints[3].RotPointZ));
            F4.Children.Add(T);
            F4.Children.Add(R);
            F4.Children.Add(F3);

            F5 = new Transform3DGroup();
            T = new TranslateTransform3D(0, 0, 0);
            R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(MainJoints[4].RotAxisX, MainJoints[4].RotAxisY, MainJoints[4].RotAxisZ), jointAngles[4]), new Point3D(MainJoints[4].RotPointX, MainJoints[4].RotPointY, MainJoints[4].RotPointZ));
            F5.Children.Add(T);
            F5.Children.Add(R);
            F5.Children.Add(F4);

            F6 = new Transform3DGroup();
            T = new TranslateTransform3D(0, 0, 0);
            R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(MainJoints[5].RotAxisX, MainJoints[5].RotAxisY, MainJoints[5].RotAxisZ), jointAngles[5]), new Point3D(MainJoints[5].RotPointX, MainJoints[5].RotPointY, MainJoints[5].RotPointZ));
            F6.Children.Add(T);
            F6.Children.Add(R);
            F6.Children.Add(F5);

            F7 = new Transform3DGroup();
            T = new TranslateTransform3D(0, 0, 0);
            R = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(MainJoints[7].RotAxisX, MainJoints[7].RotAxisY, MainJoints[7].RotAxisZ), jointAngles[6]), new Point3D(MainJoints[7].RotPointX, MainJoints[7].RotPointY, MainJoints[7].RotPointZ));
            F7.Children.Add(T);
            F7.Children.Add(R);
            F7.Children.Add(F6);

            if (OnlyNeedCalculation)
            {
                // Clone the model data so that model will not modify
                var tr0 = MainJoints[0].Model.Transform.Clone();
                var tr1 = MainJoints[1].Model.Transform.Clone();
                var tr2 = MainJoints[2].Model.Transform.Clone();
                var tr3 = MainJoints[3].Model.Transform.Clone();
                var tr4 = MainJoints[4].Model.Transform.Clone();
                var tr5 = MainJoints[5].Model.Transform.Clone();
                var tr6 = MainJoints[6].Model.Transform.Clone();
                var tr7 = MainJoints[7].Model.Transform.Clone();

                var mj0 = MainJoints[0].Model.Clone();
                var mj1 = MainJoints[1].Model.Clone();
                var mj2 = MainJoints[2].Model.Clone();
                var mj3 = MainJoints[3].Model.Clone();
                var mj4 = MainJoints[4].Model.Clone();
                var mj5 = MainJoints[5].Model.Clone();
                var mj6 = MainJoints[6].Model.Clone();
                var mj7 = MainJoints[7].Model.Clone();

                mj0.Transform = tr0;
                mj1.Transform = tr1;
                mj2.Transform = tr2;
                mj3.Transform = tr3;
                mj4.Transform = tr4;
                mj5.Transform = tr5;
                mj6.Transform = tr6;
                mj7.Transform = tr7;

                mj6.Transform = F0;
                mj0.Transform = F1;
                mj1.Transform = F2;
                mj2.Transform = F3;
                mj3.Transform = F4;
                mj4.Transform = F5;
                mj5.Transform = F6;
                mj7.Transform = F7;

                return new Vector3D(mj7.Bounds.Location.X, mj7.Bounds.Location.Y, mj7.Bounds.Location.Z);
            }

            else
            {
                MainJoints[6].Model.Transform = F0; // Fixed Base (transform to origin of the 3D space)
                MainJoints[0].Model.Transform = F1; // Base joint
                MainJoints[1].Model.Transform = F2; // Bicep joint
                MainJoints[2].Model.Transform = F3; // Elbow jint
                MainJoints[3].Model.Transform = F4; // Forearm joint 
                MainJoints[4].Model.Transform = F5; // Wrist Pitch joint
                MainJoints[5].Model.Transform = F6; // End Effector joint
                MainJoints[7].Model.Transform = F7; // End Effector joint

                foreach (Joint mainJoint in MainJoints)
                {
                    if (mainJoint.SubParts != null)
                    {
                        foreach (Joint subPart in mainJoint.SubParts)
                        {
                            subPart.Model.Transform = mainJoint.Model.Transform;
                        }
                    }
                }
                _userControl.UpdateEndEffectorPosition();
                return new Vector3D(MainJoints[7].Model.Bounds.Location.X, MainJoints[7].Model.Bounds.Location.Y, MainJoints[7].Model.Bounds.Location.Z);
            }
        }

        public double[] CalculateSyncSpeeds(double[] targetJointAngles, double[] initialJointAngles, double percent = 1)
        {
            double maxSpeed = 50 * percent; //degsec-1
            double[] timeDurations = new double[7];
            double[] syncSpeeds = new double[7];

            for (int i = 0; i < targetJointAngles.Count(); i++)
            {
                timeDurations[i] = Math.Abs(targetJointAngles[i] - initialJointAngles[i]) / maxSpeed;
            }
            double maxTime = timeDurations.Max();

            for (int i = 0; i < targetJointAngles.Count(); i++)
            {
                syncSpeeds[i] = (targetJointAngles[i] - initialJointAngles[i]) / maxTime;
            }
            SyncFwdKinematicsSpeeds = syncSpeeds;
            return SyncFwdKinematicsSpeeds;
        }
        
        public double[] SyncFwdKinematicAngles(double[] targetJointAngles, double[] initialJointAngles, double travelSpeed)
        {
            double[] nextAngles = new double[7];
            for (int i = 0; i < targetJointAngles.Count(); i++)
            {
                nextAngles[i] = initialJointAngles[i] + SyncFwdKinematicsSpeeds[i] * _userControl.SimWatchFwdKinematics.ElapsedMilliseconds / 1000;
            }
            return nextAngles;
        }
        #endregion

        #region Inverse Kinematics================================>
        public double[] InverseKinematics(Vector3D target, double[] angles)
        {
            if (DistanceFromTarget(target, angles) < DistanceThreshold)
            {
                MaximumSimulationSteps = 0;
                return angles;
            }

            double[] oldAngles = { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
            angles.CopyTo(oldAngles, 0);

            for (int i = 0; i <= 6; i++)
            {
                // Gradient descent
                // Update : NewJointAngle = CurrentJointAngle - LearningRate * Gradient
                double m_theta = PartialGradient(target, angles, i);
                angles[i] = angles[i] - LearningRates[i] * m_theta;

                // Clamp
                angles[i] = CheckLimits(angles[i], MainJoints[i].LowerLimit, MainJoints[i].UpperLimit);

                // Early termination
                if (DistanceFromTarget(target, angles) < DistanceThreshold || SameAngleBefore(oldAngles, angles))
                {
                    MaximumSimulationSteps = 0;
                    return angles;
                }
            }



            return angles;
        }

        /// <summary>
        /// Returns the Distance between Current end effector point and Target end effector point 
        /// </summary>
        /// <param name="target"></param> Target point in 3D space
        /// <param name="angles"></param> Current joint angles
        /// <returns></returns>
        public double DistanceFromTarget(Vector3D target, double[] angles)
        {
            Vector3D point = ForwardKinematics(angles);
            point.X = point.X;
            point.Y = point.Y;
            point.Z = point.Z;
            return Math.Sqrt(Math.Pow((point.X - target.X), 2.0) + Math.Pow((point.Y - target.Y), 2.0) + Math.Pow((point.Z - target.Z), 2.0));
        }

        /// <summary>
        /// Returns the partial of the joint angle i
        /// </summary>
        /// <param name="target"></param> Target point in 3D space
        /// <param name="angles"></param> Current joint angles
        /// <param name="i"></param> "Joint angle i"
        /// <returns></returns>
        public double PartialGradient(Vector3D target, double[] angles, int i)
        {
            // Saves the angle,
            // it will be restored later
            double angle = angles[i];

            // Gradient : [F(theta+SamplingDistance) - F(theta)] / SamplingDistance
            double f_theta = DistanceFromTarget(target, angles);

            angles[i] += SamplingAngle;
            double f_theta_plus_sampleAng = DistanceFromTarget(target, angles);

            double gradient = (f_theta_plus_sampleAng - f_theta) / SamplingAngle;

            // Restores
            angles[i] = angle;

            return gradient;
        }

        /// <summary>
        /// Check Current Angle is within the limits, If not returns min or max limit appropriately
        /// </summary>
        /// <typeparam name="T"></typeparam> Current joit angle or a min limit or max limit
        /// <param name="value"></param> Current joint angle
        /// <param name="min"></param> Minimum joint angle limit
        /// <param name="max"></param> Maximum joint angle limit
        /// <returns></returns>
        public static T CheckLimits<T>(T value, T min, T max)
        where T : System.IComparable<T>
        {
            T result = value;
            if (value.CompareTo(max) > 0)
                result = max;
            if (value.CompareTo(min) < 0)
                result = min;
            return result;
        }

        /// <summary>
        /// True if all new joint angles are similar with the old joint angles 
        /// </summary>
        /// <param name="oldAngles"></param> Angles before this round of inverse kinematics
        /// <param name="newAngles"></param> Angles after this round of inverse kinematics
        /// <returns></returns>
        public bool SameAngleBefore(double[] oldAngles, double[] newAngles)
        {
            for (int i = 0; i <= 5; i++)
            {
                if (oldAngles[i] != newAngles[i])
                    return false;
            }
            return true;
        }
        #endregion
    }
}
