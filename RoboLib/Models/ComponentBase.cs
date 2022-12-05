using Newtonsoft.Json;
using RoboLib.GUI.Pages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboLib.Models
{
    public class ComponentBase : ObjBase
    {
        /// <summary>
        /// The Generic Type, Component will be deserilized/created with this type if no PlugIn found.
        /// </summary>
        [JsonProperty(Order = -3), ViewMode(PropertyViewModes.ReadOnly)]
        public string GenericType { get; set; }

        /// <summary>
        /// The PlugIn Type, Component will be deserialized/created with this type if there is PlugIn dll loaded.
        /// </summary>
        [JsonProperty(Order = -4), ViewMode(PropertyViewModes.ReadOnly)]
        public string PlugInType { get; set; }

        /// <summary>
        /// Check whether the component has plugin or not
        /// </summary>
        [ViewMode(PropertyViewModes.ReadOnly)]
        public bool HasPlugIn
        {
            get
            {
                return ThisType == PlugInType;
            }
            set { }
        }

        /// <summary>
        /// Children components of the current component
        /// </summary>
        [JsonProperty(Order = -1)]
        public List<ComponentBase> Children { get; set; }

        /// <summary>
        /// Parent component of the current component 
        /// </summary>
        [JsonIgnore, ViewMode(PropertyViewModes.ReadOnly)]
        public ComponentBase ParentComp
        {
            get { return Parent as ComponentBase; }
        }

        public ComponentBase()
        {
            Children = new List<ComponentBase>();
        }

        /// <summary>
        /// Get First Child which is satisfying a given predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public ComponentBase GetFirstChild(Func<ComponentBase, bool> predicate)
        {
            return Children.Where(predicate).FirstOrDefault();
        }

        /// <summary>
        /// Whether there is child which is satisfying a given predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public bool HasChild(Func<ComponentBase, bool> predicate)
        {
            return GetFirstChild(predicate) != null;
        }

        /// <summary>
        /// Set Name and Type of the component and Add To Map
        /// </summary>
        /// <param name="name"></param>
        /// <param name="genericType"></param>
        /// <param name="parent"></param>
        protected void SetCoreInfo(string name, string genericType, string pluginType, ComponentBase parent = null)
        {
            Name = name;
            GenericType = genericType;
            PlugInType = pluginType;
            Parent = parent;
            RUtils.Map.AddToMap(this);
        }

        /// <summary>
        /// Creates a Component
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="name"></param>
        /// <param name="genericType"></param>
        /// <param name="pluginType"></param>
        /// <param name="firstTimeInit"></param>
        /// <returns></returns>
        internal static ComponentBase CreateComponent(ComponentBase parent, string name, Type genericType, string pluginType = "NA", Action<ComponentBase> firstTimeInit = null)
        {
            Type buildType =  Cache.GetLoadedType(pluginType) ?? genericType;
            ComponentBase comp = (ComponentBase)Activator.CreateInstance(buildType);

            comp.SetCoreInfo(name, genericType.Name, pluginType, parent);
            
            if (!parent.HasChild(x => x.Name == name)) 
            {
                if (firstTimeInit != null)
                {
                    firstTimeInit(comp);
                }
            }
            return parent.Add(comp);
        }

        public void AddToTreeNode(TreeNodeCollection nodes)
        {
            TreeNode node = nodes.Add(Name);
            node.Tag = this;
            SetTreeNodeStyle(this, node);
            Children.ForEach(x => x.AddToTreeNode(node.Nodes));
        }

        internal ComponentBase Add(ComponentBase child)
        {
            // Here where we deciding which component should remain for use
            // If component is created already from the deserialization we just assign that componet as our new component and use that
            // (So the properties will update with deserialized component)
            // If component is not in the deserialized Children list of the Robot, we keep our new component and use that
            child = GetFirstChild(x => x.Name == child.Name) ?? child;
            child.RegisterComponent(this);

            if (Children.Contains(child))
            {
                Children.Remove(child); // Remove then add later to enforce initialization order
            }
            Children.Add(child);
            return child;
        }

        protected void RegisterComponent(ComponentBase parent)
        {
            SetCoreInfo(Name, GenericType, PlugInType, parent);
            Children.ForEach(x => x.RegisterComponent(this));
        }

        public static void SetTreeNodeStyle(ComponentBase comp, TreeNode node)
        {
            node.BackColor = Color.White;
            node.ForeColor = Color.Black;
            node.NodeFont = new Font(node.TreeView.Font, FontStyle.Regular);
            node.ImageKey = comp.GetType().Name;
            node.SelectedImageKey = node.ImageKey;
        }

        /// <summary>
        /// Get Property Pages that defined for this component
        /// </summary>
        /// <returns></returns>
        Dictionary<string, Type> GetPages()
        {
            Dictionary<string, Type> pageTypes = new Dictionary<string, Type>();
            DefinePages(pageTypes);
            return pageTypes;
        }

        internal List<PropertyPageViewModel> GetPropertyPages()
        {
            // for legacy: those by DefinePages still use this as Obj
            var thisCompList = GetPages().Select(x =>
                new PropertyPageViewModel()
                {
                    PageTitle = x.Key,
                    PageType = x.Value,
                    Obj = this
                }).ToList();
            var customList = new List<PropertyPageViewModel>();

            var list = thisCompList.Concat(customList).ToList();
            //if (list.Count <= 1)
            //{
            // Add message page
            //    list.Add(new PropertyPageViewModel() { PageTitle = "Message", PageType = typeof(ComponentMessagePage), Obj = this });
            //}
            return list;
        }

        protected virtual void DefinePages(Dictionary<string, Type> pageTypes)
        {
            pageTypes.Add("General", typeof(ComponentGeneralPage));
        }

        #region Initialize Recurse process
        /// <summary>
        /// Call to Initialize the Robot and all child components
        /// </summary>
        public void InitializeRecurse()
        {
            if (this is Robot)
            {
                try
                {
                    OnInitializeThis();
                }
                catch (Exception ex)
                {
                    throw new RException("Initialize Recurse fail!", ex);
                }
            }
            else 
            {
                throw new RException("InitializeRecurse must call from the Robot component");
            }
        }

        void OnInitializeThis()
        {
            this.OnInitializeRecurse();
            if (Children.Count != 0)
            {
                this.Children.ForEach(x => x.OnInitializeThis());
            }
            this.OnAfterInitializeRecurse();
        }

        /// <summary>
        /// Override to do thing when initializing
        /// </summary>
        protected virtual void OnInitializeRecurse() { }

        /// <summary>
        /// Override to do thing afer initialize recurse
        /// </summary>
        protected virtual void OnAfterInitializeRecurse() { }
        #endregion

        #region Destroy Recurese process
        /// <summary>
        /// Call when Form1 closing to destroy components
        /// </summary>
        internal void DestroyRecurse() 
        {
            if (this is Robot)
            {
                try
                {
                    OnDestroyThis();
                }
                catch (Exception ex)
                {
                    throw new RException("Destroy Recurse fail!", ex);
                }
            }
            else
            {
                throw new RException("DestroyRecurse must call from the Robot component");
            } 
        }

        /// <summary>
        /// Destroy in reverse oreder, children first
        /// </summary>
        void OnDestroyThis() 
        {
            this.OnBeforeDestroyRecurse();
            if (Children.Count != 0)
            {
                this.Children.Reverse();
                this.Children.ForEach(x => x.OnDestroyThis());
            }
            this.OnDestroyRecurese();
        }

        /// <summary>
        /// verride to do thing when destroy recurse
        /// </summary>
        protected virtual void OnDestroyRecurese() 
        {

        }

        /// <summary>
        /// Override to do thing before destroy recurse
        /// </summary>
        protected virtual void OnBeforeDestroyRecurse() 
        {

        }
        #endregion
    }
}
