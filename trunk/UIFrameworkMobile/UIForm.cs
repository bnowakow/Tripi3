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
using System.Windows.Forms;
using System.Drawing;

namespace Msdn.UIFramework
{
    public class UIForm : Form
    {
        private Image backgroundImage;
        private Bitmap offBitmap;
        private Graphics offGx;
        private TitleBar titleBar;
        private MenuBar menuBar;
        private static string applicationPath;
        private Canvas canvas;
      
        public UIForm()
        {              
            this.canvas = new Canvas(this);
            this.titleBar = new TitleBar();
            this.titleBar.Text = this.Text;
            this.menuBar = new MenuBar();
            this.canvas.Children.Add(titleBar);
            this.canvas.Children.Add(menuBar);
            // Don't show title bar and allocate the full screen 
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;                                 
        }

        public Canvas Canvas
        {
            get
            {
                return this.canvas;
            }
        }

        internal static string ApplicationPath
        {
            get
            {
                if (applicationPath == null)
                {
                    applicationPath = System.IO.Path.GetDirectoryName
                 (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                }

                return applicationPath;
            }
        }

        public TitleBar TitleBar
        {
            get
            {
                return this.titleBar;
            }          
        }

        public MenuBar MenuBar
        {
            get
            {
                return this.menuBar;
            }
        }



        public Image BackgroundImage
        {
            get
            {
                return this.backgroundImage;
            }
            set
            {
                this.backgroundImage = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw a background first
            this.offGx.Clear(this.BackColor);

            if (this.backgroundImage != null)
            {
                this.offGx.DrawImage(this.backgroundImage, 0, 0);
            }           

            // Pass the graphics to the canvas to render
            if (this.canvas != null)
            {
                this.canvas.Render(offGx);
            }

            // Blit the offscreen bitmap
            e.Graphics.DrawImage(offBitmap, 0, 0);           
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }

        protected override void OnResize(EventArgs e)
        {            
            this.titleBar.Height = 24;
            this.titleBar.Width = this.Width;

            this.menuBar.Height = 30;
            this.menuBar.Width = this.Width;
            this.menuBar.Top = this.Height - this.menuBar.Height;

            if (this.offBitmap != null)
            {
                this.offBitmap.Dispose();
                this.offGx.Dispose();
            }
            // Create off screen bitmap for double buffering
            this.offBitmap = new Bitmap(this.Width, this.Height);
            this.offGx = Graphics.FromImage(offBitmap);
            base.OnResize(e);
            
        }
       
        protected override void OnClick(EventArgs e)
        {
            foreach (UIElement element in this.canvas.Children)
            {
                if (element.HitTest(new Point(Control.MousePosition.X, Control.MousePosition.Y)))
                {
                    element.OnClick(EventArgs.Empty);
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            foreach (UIElement element in this.canvas.Children)
            {
                if (element.HitTest(new Point(e.X, e.Y)))
                {
                    element.OnMouseDown(e);
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            foreach (UIElement element in this.canvas.Children)
            {
                if (element.HitTest(new Point(e.X, e.Y)))
                {
                    element.OnMouseUp(e);
                }
            }
        }
    }
}
