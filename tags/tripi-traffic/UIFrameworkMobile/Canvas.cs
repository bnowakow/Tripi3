//--------------------------------------------------------------------- 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY 
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A 
//PARTICULAR PURPOSE. 
//---------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Msdn.UIFramework
{
    public class Canvas : UIElement
    {        
        private VisualCollection children;      
        private Control host;

        public Canvas()          
        {
            this.children = new VisualCollection(this);
            ApplicationPath = System.IO.Path.GetDirectoryName
                    (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        }

        public Canvas(Control host) : this()
        {
            this.host = host;            
        }

        public T AddElement<T>(Func<T> buildFunc) where T : UIElement
        {
            if (buildFunc == null)
                throw new ArgumentNullException("buildFunc");

            T instance = buildFunc();
            this.children.Add(instance as UIElement);           
            return instance;
        }

        internal void InvalidateChild(UIElement element)
        {
            if (this.host != null)
            {
                this.host.Invalidate(element.Rectangle);
            }           
        }      

        protected override void OnRender(Graphics graphics)
        {
            // Draw a back color
            if (this.Background != null)
            {
                using (Brush brush = new SolidBrush(Background))
                {
                     graphics.FillRectangle(brush, new Rectangle(this.Left, this.Top, this.Height, this.Width));
                }
            }

            // Pass the graphics objects to all UI elements
            for (int i = 0; i < children.Count; i++)
            {
                UIElement element = children[i];
                if (element.Visible)
                {
                    element.Render(graphics);
                }
            }
        }
       

        public VisualCollection Children
        {
            get
            {
                return this.children;
            }
            set
            {
                this.children = value;
            }
        }       
    }
}
