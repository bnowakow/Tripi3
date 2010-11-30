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
    public class TextBlock : UIElement
    {
        private string fontFamily;
        private float fontSize;
        private FontStyle fontStyle;
        private Color foreground;
        private Color background;       
        private string text;
        private TextAlignment alignment;        

        public TextBlock()
        {
            // Set defaults
            this.fontFamily = "Tahoma";
            this.fontSize = 9f;
            this.fontStyle = FontStyle.Regular;
            this.alignment = TextAlignment.Left;
            this.Width = 50;
            this.Height = 16;
            this.foreground = Color.Black;
            this.background = Color.Transparent;
        }

        public TextBlock(string text)
            : this()
        {
            this.text = text;
        }

        protected override void OnRender(Graphics drawingContext)
        {
            if (this.Text != null)
            {
                Size sizeContent = Size.Empty;
                // Prepare font
                Font font = new Font(this.fontFamily, this.fontSize, fontStyle);
                // Measure the string
                SizeF sizeContentF = drawingContext.MeasureString(this.Text, font);
                sizeContent.Width = (int)sizeContentF.Width;
                sizeContent.Height = (int)sizeContentF.Height;
                // Calculate the location of the text
                Point point = GetLocationFromContentAlignment(this.alignment, sizeContent);
                // Draw the text
                using (Brush brushText = new SolidBrush(this.Foreground))
                {
                    Rectangle textRect = new Rectangle(point.X, point.Y, this.Width - 1, this.Height - 1);
                    drawingContext.DrawString(this.Text, font, brushText, textRect);
                }
                // Clean up
                font.Dispose();
            }
        }
             

        private Point GetLocationFromContentAlignment(TextAlignment alignment, Size sizeContent)
        {
            Point point = new Point(this.Left, this.Top);
            byte offset = 2;
            
            // Horizontal Alignment
            if ((alignment & TextAlignment.Center) > 0)		// Center
            {
                point.X = (this.Rectangle.Width / 2) - (sizeContent.Width / 2);
            }
            else if ((alignment & TextAlignment.Left) > 0)	// Left
            {
                point.X = this.Rectangle.X + offset;
            }
            else if ((alignment & TextAlignment.Right) > 0)	// Right
            {
                point.X = this.Rectangle.Width - sizeContent.Width - offset;
            }

            return point;
        }

        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                if (this.text != value)
                {
                    this.text = value;
                    this.OnInvalidate();
                }
            }
        }

        public TextAlignment TextAlignment
        {
            get
            {
                return this.alignment;
            }
            set
            {
                this.alignment = value;
            }
        }


        public string FontFamily
        {
            get
            {
                return this.fontFamily;
            }
            set
            {
                this.fontFamily = value;
            }
        }

        public float FontSize
        {
            get
            {
                return fontSize;
            }
            set
            {
                fontSize = value;
                this.Height = (int)fontSize + 6;
            }
        }

        public FontStyle FontStyle
        {
            get
            {
                return fontStyle;
            }
            set
            {
                this.fontStyle = value;
            }
        }     


    }

    #region enums

    public enum TextAlignment
    {
        Left,
        Right,
        Center,
        Justify
    }

    public enum TextWrapping
    {
        WrapWithOverflow,
        NoWrap,
        Wrap
    }

    #endregion
}
