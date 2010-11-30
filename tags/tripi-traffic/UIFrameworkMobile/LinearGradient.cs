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

namespace Msdn.UIFramework
{
    public class LinearGradient 
    {        
        private List<Color> colors;
        private LinearGradientMode mode;      

        public LinearGradient()
        {
            this.colors = new List<Color>();
            this.mode = LinearGradientMode.Vertical;
        }

        public LinearGradient(Color color1, Color color2)
        {
            this.colors = new List<Color>();
            this.mode = LinearGradientMode.Vertical;
            this.colors.Add(color1);
            this.colors.Add(color2);
        }        

        public List<Color> LinearColors
        {
            get
            {
                return this.colors;
            }
            set
            {
                this.colors = value;
            }
        }      

        public LinearGradientMode GradientMode
        {
            get
            {
                return this.mode;
            }
            set
            {
                this.mode = value;
            }

        }

    }

    public enum LinearGradientMode
    {
        Horizontal,
        Vertical
    }

}
