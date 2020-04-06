using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    /// <summary>
    /// Image manipulation, uses the 'ImageProcessor' library.
    /// 
    /// Author: Reid Giles
    /// </summary>
    public interface IImageProcessor
    {
        /// <summary>
        /// Loads an image from disk using filepath
        /// </summary>
        /// <param name="pFilePath"></param>
        /// <returns></returns>
        Image LoadImage(string pFilePath);

        /// <summary>
        /// Resizes an image
        /// </summary>
        /// <param name="pImage"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        Image ResizeImage(Image pImage, Size pSize);

        /// <summary>
        /// Rotates an image
        /// </summary>
        /// <param name="pImage"></param>
        /// <param name="pDegrees"></param>
        /// <returns></returns>
        Image RotateImage(Image pImage, float pDegrees);

        /// <summary>
        /// Flips an image
        /// </summary>
        /// <param name="pImage"></param>
        /// <param name="flipVertical"></param>
        /// <param name="flipHorizontal"></param>
        /// <returns></returns>
        Image FlipImage(Image pImage, bool flipVertical, bool flipHorizontal);
    }
}