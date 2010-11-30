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
using System.Windows.Forms;

namespace Msdn.UIFramework
{
    public class MenuBar : UIElement
    {
        private event EventHandler leftMenuClicked = null;
        private event EventHandler rightMenuClicked = null;

        private string leftMenu;
        private string rightMenu;
        private LinearGradient fillBrush;
        private Font font;
        private Graphics cachedGx;
        private bool leftMenuPressed;
        private bool rightMenuPressed;

        public MenuBar()
        {
            this.Left = 0;           
            this.Background = Color.Black;
            this.Foreground = Color.White;
            this.Opacity = 180;
            this.font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.MouseDown += new MouseEventHandler(MenuBar_MouseDown);
            this.MouseUp += new MouseEventHandler(MenuBar_MouseUp); 
        }

        private void MenuBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftMenuPressed)
            {
                if(leftMenuClicked != null)
                    leftMenuClicked(this, EventArgs.Empty);
                this.leftMenuPressed = false;
            }
            else if (rightMenuPressed)
            {
                if (rightMenuClicked != null)
                    rightMenuClicked(this, EventArgs.Empty);
                this.rightMenuPressed = false;
            }
            this.OnInvalidate();
        }

        void MenuBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X < this.Width / 2)
            {
                this.leftMenuPressed = true;
            }
            else
            {
                this.rightMenuPressed = true;
            }
           
            this.OnInvalidate();
        }      

        protected override void OnRender(System.Drawing.Graphics graphics)
        {           
            //this.DrawBackground(graphics, this.Rectangle);

            this.DrawLeftMenu(graphics, leftMenuPressed);

            this.DrawRightMenu(graphics, rightMenuPressed);

            this.cachedGx = graphics;

            base.OnRender(graphics);

        }

       
        private void DrawLeftMenu(Graphics graphics, bool pressed)
        {
            Rectangle rc = new Rectangle(this.Left, this.Top, this.Width / 2, this.Height);

            if (pressed)
            {
                byte originalOpacity = this.Opacity;
                this.Opacity = 140;
                this.DrawBackground(graphics, rc);
                this.Opacity = originalOpacity;
            }
            else
            {
                this.DrawBackground(graphics, rc);
            }

            

            if (this.leftMenu != null)
            {
                SizeF size = graphics.MeasureString(this.leftMenu, this.font);

                Rectangle rect = new Rectangle((this.Width / 2 - (int)size.Width) / 2, this.Top + (this.Height - (int)size.Height) / 2,
                                                        (int)size.Width, (int)size.Height);               

                using (Brush brush = new SolidBrush(this.Foreground))
                {
                    graphics.DrawString(this.leftMenu, font, brush, rect);
                }
            }
        }

        private void DrawRightMenu(Graphics graphics, bool pressed)
        {
            Rectangle rc = new Rectangle(this.Width / 2, this.Top, this.Width / 2, this.Height);
            if (pressed)
            {                
                byte originalOpacity = this.Opacity;
                this.Opacity = 140;
                this.DrawBackground(graphics, rc);
                this.Opacity = originalOpacity;
            }
            else
            {
                this.DrawBackground(graphics, rc);
            }            

            if (this.rightMenu != null)
            {
                SizeF size = graphics.MeasureString(this.rightMenu, this.font);
                int left = this.Width / 2;

                Rectangle rect = new Rectangle((this.Width / 2 - (int)size.Width) / 2 + left, this.Top + (this.Height - (int)size.Height) / 2,
                                                        (int)size.Width, (int)size.Height);

                using (Brush brush = new SolidBrush(this.Foreground))
                {
                    graphics.DrawString(this.rightMenu, font, brush, rect);
                }
            }
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
                graphics.DrawRectandleAlpha(this.Background, this.Background, rc, this.Opacity);
            }
        }

        public string LeftMenu
        {
            get
            {
                return this.leftMenu;
            }
            set
            {
                this.leftMenu = value;
                this.OnInvalidate();
            }
        }

        public string RightMenu
        {
            get
            {
                return this.rightMenu;
            }
            set
            {
                this.rightMenu = value;
                this.OnInvalidate();
            }
        }

        public event EventHandler RightMenuClicked
        {
            add { rightMenuClicked += value; }
            remove { rightMenuClicked -= value; }
        }

        public event EventHandler LeftMenuClicked
        {
            add { leftMenuClicked += value; }
            remove { leftMenuClicked -= value; }
        }
    }
}
