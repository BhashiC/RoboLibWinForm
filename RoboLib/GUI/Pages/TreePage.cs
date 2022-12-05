using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoboLib.Models;

namespace RoboLib.GUI.Pages
{
    public partial class TreePage : ViewPage
    {
        /// <summary>
        /// Fire when a component node is selected
        /// </summary>
        public event Action<object> evAfterSelect;

        public TreePage()
        {
            InitializeComponent();
        }

        protected override void DefineBinding(ObjBase objBase)
        {
            base.DefineBinding(objBase);
            RefreshTree();
            treeViewRobot.AfterSelect += new TreeViewEventHandler(treeViewRobot_AfterSelect);
        }

        void treeViewRobot_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (evAfterSelect != null) evAfterSelect(e.Node.Tag);
        }

        public void RefreshTree()
        {
            treeViewRobot.Nodes.Clear();
            Robot.Instance.AddToTreeNode(treeViewRobot.Nodes);
            SetNodeToolTip(treeViewRobot.Nodes);
            treeViewRobot.EndUpdate();
            SelectFirstNode();
        }

        void SelectFirstNode()
        {
            var first = treeViewRobot.Nodes.OfType<TreeNode>().First();
            if (treeViewRobot.SelectedNode == first)
            {
                treeViewRobot.SelectedNode = null;
            }
            treeViewRobot.SelectedNode = first;
        }

        void SetNodeToolTip(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.ToolTipText = node.Tag.ToString();
                SetNodeToolTip(node.Nodes);
            }
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            treeViewRobot.AfterSelect -= new TreeViewEventHandler(treeViewRobot_AfterSelect);
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
