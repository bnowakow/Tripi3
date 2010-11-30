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

namespace Msdn.UIFramework
{
    public class ImageElement : UIElement
    {
        private string source;
        private Bitmap image;
        private bool transparentBackground;
        private IImage imagingImage;
        private bool alphaChannel;
        private bool stretch;

        public ImageElement()
        {
            this.transparentBackground = false;
            this.Opacity = 255;
        }

        public string Source
        {
            get
            {               
                return source;
            }
            set
            {
                source = value;
                this.LoadImage();
                this.OnInvalidate();
            }
        }

        public bool Stretch
        {
            get
            {
                return this.stretch;
            }
            set
            {
                this.stretch = value;
                this.OnInvalidate();
            }
        }

        public Bitmap BitmapImage
        {
            get
            {
                return image;
            }
        }

        public bool TransparentBackground
        {
            get
            {
                return transparentBackground;
            }
            set
            {
                transparentBackground = value;
            }
        }

        public bool AlphaChannel
        {
            get
            {
                return alphaChannel;
            }
            set
            {
                alphaChannel = value;
            }
        }

        public int Width
        {
            get
            {
                if (stretch)
                {
                    return width;
                }
                else
                {
                    return this.image.Width;
                }
            }
            set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                if (stretch)
                {
                    return height;
                }
                else
                {
                    return this.image.Height;
                }
            }
            set
            {
                height = value;
            }
        }
        

        private void LoadImage()
        {
            if (this.image != null)
            {
                this.image.Dispose();              
            }
            

            if (source != null)
            {                
                try
                {                  
                    source = Path.Combine(Canvas.ApplicationPath, source);                    
                    image = new Bitmap(source);                  

                   IImagingFactory factory = ImagingFactory.GetImaging();
                   factory.CreateImageFromFile(source, out imagingImage);
                }
                catch{}                                                      
            }
        }

        protected override void OnRender(Graphics graphics)
        {
            if (this.image != null)
            {
                if (transparentBackground)
                {
                    graphics.DrawImageTransparent(this.image, this.Rectangle);                     
                }
                else if (alphaChannel)
                {                    
                    graphics.DrawImageAlphaChannel(this.imagingImage, this.Left, this.Top);
                }
                else if (stretch)
                {
                    graphics.DrawImage(this.image, this.Rectangle, new Rectangle(0, 0, this.image.Width, this.image.Height), GraphicsUnit.Pixel);
                }
                else
                {
                    graphics.DrawAlpha(this.image, this.Opacity, this.Left, this.Top);
                }
            }
        }
    }
}
