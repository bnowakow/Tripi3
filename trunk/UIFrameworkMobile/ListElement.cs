using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Msdn.UIFramework
{
    public class ListElement : UIElement
    {
        private Border border;
        private List<ListItem> items;


        public ListElement()
        {
            this.items = new List<ListItem>();
            this.border = new Border();            
        }

        public Border Border
        {
            get
            {
                return this.border;
            }
        }

        public List<ListItem> Items
        {
            get
            {
                return this.items;
            }
        }

        protected override void OnRender(Graphics graphics)
        {
            this.LayoutItems();
            this.border.Render(graphics);           

            for (int i = 0; i < this.items.Count; i++)
            {
                this.items[i].Render(graphics);
            }            
        }

        private void LayoutItems()
        {
            this.border.Left = this.Left;
            this.border.Top = this.Top;
            this.border.Width = this.Width;
            this.border.Height = this.Height;
            int height = this.Top;
            foreach (ListItem item in this.items)
            {                
                item.Left = this.left;               
                item.Top += height;
                height = item.Height;
            }
        }
       
    }
}
