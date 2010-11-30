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
using Microsoft.Drawing;


namespace Msdn.UIFramework
{
    public class Border : UIElement
    {
        #region fields

        private Color foreground;
        private Color background;
        private int thickness;
        private int cornerRadius;
        private LinearGradient brush;

        #endregion

        #region constructor

        public Border()
        {
            this.background = Color.Transparent;
            this.foreground = Color.Transparent;
            this.thickness = 1;
            this.brush = null;
        }

        #endregion

        #region overrides

        protected override void OnRender(Graphics graphics)
        {
                Rectangle rc = new Rectangle(this.Left, this.Top, this.Width, this.Height);
                
                // Check if we have rounded corners
                if (this.cornerRadius > 0)
                {
                    // Any alpha transparency?
                    if (this.Opacity == 255)
                    {
                        // Do we have gradient?
                        if (this.brush == null)
                        {
                            graphics.DrawRoundedRectangle(this.foreground, this.background, new Rectangle(this.Left, this.Top, this.Width, this.Height), new Size(this.cornerRadius, this.cornerRadius));
                        }
                        else
                        {
                            // Draw gradient
                            graphics.DrawGradientRoundedRectangle(new Rectangle(this.Left, this.Top, this.Width, this.Height), this.brush.LinearColors[0], this.brush.LinearColors[1], this.foreground, new Size(this.cornerRadius, this.cornerRadius));

                        }
                    }
                    else
                    {
                        // Do we have gradient?
                        if (this.brush == null)
                        {
                            graphics.DrawRoundedRectangleAlpha(this.foreground, this.background, new Rectangle(this.Left, this.Top, this.Width, this.Height), new Size(this.cornerRadius, this.cornerRadius), this.Opacity);
                        }
                        else
                        {
                            graphics.DrawGradientRoundedRectangleAlpha(new Rectangle(this.Left, this.Top, this.Width, this.Height), this.brush.LinearColors[0], this.brush.LinearColors[1], this.foreground, new Size(this.cornerRadius, this.cornerRadius), this.Opacity);
                        }
                    }
                }
                else
                {                    
                    if (this.Opacity == 255)
                    {
                        if (this.brush != null)
                        {
                            graphics.FillGradientRectangle(rc, this.brush.LinearColors[0], this.brush.LinearColors[1], (FillDirection)brush.GradientMode);
                        }
                        else
                        {
                            using (Brush localBrush = new SolidBrush(this.background))
                            {
                                graphics.FillRectangle(localBrush, rc);
                            }
                        }
                    }
                    else
                    {
                        graphics.DrawRectandleAlpha(this.foreground, this.background, rc, this.Opacity);
                    }
                }
                            
        }

        #endregion

        #region properties

        public int CornerRadius
        {
            get
            {
                return this.cornerRadius;
            }
            set
            {
                if (this.cornerRadius != value)
                {
                    this.cornerRadius = value;
                    this.OnInvalidate();
                }
            }
        }



        public int Thickness
        {
            get
            {
                return thickness;
            }
            set
            {
                this.thickness = value;
            }
        }       

        public LinearGradient Fill
        {
            get
            {
                return brush;
            }
            set
            {
                if (this.brush != value)
                {
                    this.brush = value;
                    this.OnInvalidate();
                }
            }
        }

        #endregion
    }
}
