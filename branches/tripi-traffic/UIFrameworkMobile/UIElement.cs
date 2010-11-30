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
using System.Windows.Forms;

namespace Msdn.UIFramework
{
    public abstract class UIElement
    {
        #region events

        public event MouseEventHandler MouseMove;
        public event MouseEventHandler MouseDown;
        public event MouseEventHandler MouseUp;
        public event EventHandler Click;
        public event EventHandler Invalidate;

        internal static string ApplicationPath;

        #endregion

        #region fields

        private byte opacity;
        private bool visible;
        private string name;

        protected int height;
        protected int width;
        protected int left;
        protected int top;

        private Color foreground;
        private Color background;

        private UIElement parent;

        #endregion

        #region constructor

        public UIElement()
        {
            this.visible = true;
            this.name = "";
            this.opacity = 255;
           
        }

        #endregion

        #region public and protected methods

        /// <summary>
        /// Detects a hit test.
        /// </summary>
        /// <param name="point">a point to detect</param>
        /// <returns>True: if the UIElement was hit.</returns>
        public bool HitTest(Point point)
        {            
            return this.Rectangle.Contains(point);
        }

        /// <summary>
        /// Renders the UIElement.
        /// </summary>
        /// <param name="graphics">Graphics object.</param>
        public void Render(Graphics graphics)
        {
            this.OnRender(graphics);
        }

        /// <summary>
        /// Render method to implement by inheritors
        /// </summary>
        /// <param name="graphics">Graphics object.</param>
        protected virtual void OnRender(Graphics graphics)
        {

        }

        public void OnInvalidate(UIElement element)
        {
            if (this.Invalidate != null)
            {
                this.Invalidate(element, null);
            }
        }

        public void OnInvalidate()
        {
            if (this.Invalidate != null)
            {
                this.Invalidate(this, null);
            }
        }      

        public void OnClick(EventArgs e)
        {
            if (this.Click != null)
            {
                this.Click(this, e);
            }
        }

        public void OnMouseDown(MouseEventArgs e)
        {
            if (this.MouseDown != null)
            {
                this.MouseDown(this, e);
            }
        }

        public void OnMouseUp(MouseEventArgs e)
        {
            if (this.MouseUp != null)
            {
                this.MouseUp(this, e);
            }
        }

        public void OnMouseMove(MouseEventArgs e)
        {
            if (this.MouseMove != null)
            {
                this.MouseMove(this, e);
            }
        }

        #endregion

        #region properties

        public int Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

        public int Top
        {
            get
            {
                return top;
            }
            set
            {
                top = value;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(this.left, this.top, this.width, this.height);
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        public UIElement Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public byte Opacity
        {
            get
            {
                return opacity;
            }
            set
            {
                opacity = value;
            }
        }

        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                visible = value;
            }
        }

        public Color Foreground
        {
            get
            {
                return foreground;
            }
            set
            {
                if (this.foreground != value)
                {
                    this.foreground = value;
                    this.OnInvalidate();
                }
            }
        }

        public Color Background
        {
            get
            {
                return background;
            }
            set
            {
                if (this.background != value)
                {
                    this.background = value;
                    this.OnInvalidate();
                }
            }
        }

        #endregion

    }
}
