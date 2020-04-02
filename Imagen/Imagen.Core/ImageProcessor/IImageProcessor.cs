using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
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
    }
}