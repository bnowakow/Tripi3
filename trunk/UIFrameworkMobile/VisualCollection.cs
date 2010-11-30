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

namespace Msdn.UIFramework
{
    public sealed class VisualCollection : List<UIElement>
    {
        private Dictionary<string, int> nameList;
        private Canvas canvas;

        public VisualCollection()
        {
            //this.host = host;
            this.nameList = new Dictionary<string, int>();
        }

        public VisualCollection(Canvas canvas)
        {
            this.canvas = canvas;
            this.nameList = new Dictionary<string, int>();
        }

        public T Add<T>(Func<T> build)
        {
            T element = build();
            this.Add(element as UIElement);
            return element;
        }

        public new void Add(UIElement element)
        {
            if (element.Name != "")
            {
                nameList.Add(element.Name, this.Count);
            }
            element.Parent = canvas;
            element.Invalidate += new EventHandler(element_Invalidate);
            base.Add(element);
        }

        void element_Invalidate(object sender, EventArgs e)
        {
            // Pass invalidation event to the canvas          
            canvas.InvalidateChild(sender as UIElement);
        }

        public UIElement this[string name]
        {
            get
            {
                return this[nameList[name]];
            }
        }

       


    }
}
