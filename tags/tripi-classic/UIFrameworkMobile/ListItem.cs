using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Msdn.UIFramework
{
    public class ListItem : Canvas
    {
        private bool isSelected;
        private Border selectedStyle;

        public ListItem()
        {
            selectedStyle = new Border();
            selectedStyle.Fill = new LinearGradient(Color.LightSeaGreen, Color.GreenYellow);
            selectedStyle.CornerRadius = 4;
        }

        public UIElement SelectedStyle
        {
            get
            {
                return selectedStyle;
            }
        }

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                this.isSelected = value;
            }
        }
    }
}
