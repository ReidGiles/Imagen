using ImageProcessor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    /// <summary>
    /// Image manipulation class, uses the 'ImageProcessor' library.
    /// 
    /// Author: Reid Giles
    /// </summary>
    class ImageProcessor : IImageProcessor
    {
        // DECLARE an ImageFactory, call it '_imageFactory'
        private ImageFactory _imageFactory;

        /// <summary>
        /// Constructor for image processor
        /// </summary>
        public ImageProcessor()
        {
            // INSTANTIATE _imageFactory
            _imageFactory = new ImageFactory();
        }

        /// <summary>
        /// Loads an image from disk using filepath
        /// </summary>
        /// <param name="pFilePath"></param>
        /// <returns></returns>
        public Image LoadImage(string pFilePath)
        {
            _imageFactory.Load(pFilePath);
            return _imageFactory.Image;
        }

        /// <summary>
        /// Resizes an image
        /// </summary>
        /// <param name="pImage"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public Image ResizeImage(Image pImage, Size pSize)
        {
            _imageFactory.Load(pImage);
            _imageFactory.Resize(pSize);
            return _imageFactory.Image;
        }

        /// <summary>
        /// Rotates an image
        /// </summary>
        /// <param name="pImage"></param>
        /// <param name="pDegrees"></param>
        /// <returns></returns>
        public Image RotateImage(Image pImage, float pDegrees)
        {
            _imageFactory.Load(pImage);
            _imageFactory.Rotate(pDegrees);
            return _imageFactory.Image;
        }

        /// <summary>
        /// Flips an image
        /// </summary>
        /// <param name="pImage"></param>
        /// <param name="flipVertical"></param>
        /// <param name="flipHorizontal"></param>
        /// <returns></returns>
        public Image FlipImage(Image pImage, bool flipVertical, bool flipHorizontal)
        {
            _imageFactory.Load(pImage);
            _imageFactory.Flip(flipVertical, flipHorizontal);
            return _imageFactory.Image;
        }
    }
}