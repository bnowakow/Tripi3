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
using System.IO;
using System.Reflection;

namespace Msdn.UIFramework
{
    public class TitleBar : UIElement
    {
        #region fields

        private LinearGradient fillBrush;
        private Bitmap battery;
        private Bitmap signal;
        private Font font;

        #endregion

        #region constructor

        public TitleBar()
        {
            this.Left = 0;
            this.Top = 0;
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream batteryStream = myAssembly.GetManifestResourceStream("Msdn.UIFramework.Images.battery_70.bmp");
            this.battery = new Bitmap(batteryStream);
            Stream signalStream = myAssembly.GetManifestResourceStream("Msdn.UIFramework.Images.signal_4.bmp");
            this.signal = new Bitmap(signalStream);
            this.font = new Font("Tahoma", 8f, FontStyle.Bold);
            this.Foreground = Color.White;
        }

        #endregion

        #region properties

        public LinearGradient Fill
        {
            get
            {
                return fillBrush;
            }
            set
            {
                if (this.fillBrush != value)
                {
                    this.fillBrush = value;
                    this.OnInvalidate();
                }
            }
        }

        public string Text 
        { 
            get; 
            set;
        }

        #endregion

        #region overrides and helper methods

        protected override void OnRender(Graphics graphics)
        {
            // Current rectangle
            Rectangle rc = new Rectangle(this.Left, this.Top, this.Width, this.Height);
            
            this.DrawBackground(graphics, rc);

            this.DrawBattery(graphics);

            this.DrawSignal(graphics);

            this.DrawCaption(graphics);
           
            base.OnRender(graphics);
        }

        private void DrawCaption(Graphics graphics)
        {
            if (this.Text != null)
            {
                SizeF size = graphics.MeasureString(this.Text, this.font);

                Rectangle rect = new Rectangle((this.Width - (int)size.Width) / 2, (this.Height - (int)size.Height) / 2,
                                                        (int)size.Width, (int)size.Height);
                using(Brush brush = new SolidBrush(this.Foreground))
                {
                    graphics.DrawString(this.Text, font, brush, rect);
                }
            }

        }

        private void DrawBattery(Graphics graphics)
        {
            Rectangle rect = new Rectangle(3, (this.Height - this.battery.Height) / 2,
                                                        this.battery.Width, this.battery.Height);
            graphics.DrawImageTransparent(battery, rect);
        }

        private void DrawSignal(Graphics graphics)
        {
            Rectangle rect = new Rectangle(this.Width - this.signal.Width - 3, (this.Height - this.signal.Height) / 2,
                                                        this.signal.Width, this.signal.Height);
            graphics.DrawImageTransparent(signal, rect);
        }

        private void DrawBackground(Graphics graphics, Rectangle rc)
        {
            if (this.Opacity == 255)
            {
                if (this.fillBrush != null)
                {
                    graphics.FillGradientRectangle(rc, this.fillBrush.LinearColors[0], this.fillBrush.LinearColors[1], (FillDirection)fillBrush.GradientMode);
                }
                else
                {
                    using (Brush localBrush = new SolidBrush(this.Background))
                    {
                        graphics.FillRectangle(localBrush, rc);
                    }
                }
            }
            else
            {
                graphics.DrawRectandleAlpha(this.Foreground, this.Background, rc, this.Opacity);
            }
        }

        #endregion
    }
}
