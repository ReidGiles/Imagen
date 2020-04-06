using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    /// <summary>
    /// Controller, masks the functionality of ImageProcessor and Images.
    /// 
    /// Author: Reid Giles
    /// </summary>
    public interface IImageManager
    {
        /// <summary>
        /// Load the media items pointed to by 'pathfilenames' into the 'Model'
        /// </summary>
        /// <param name="pathfilenames">a vector of strings; each string containing path/filename for an image file to be loaded</param>
        /// <returns>the unique identifiers of the images that have been loaded</returns>
        IList<String> load(IList<String> pathfilenames);

        /// <summary>
        /// Return a copy of the image specified by 'key', scaled according to the dimentsions of the visual container (ie frame) it will be viewed in.
        /// </summary>
        /// <param name="key">the unique identifier for the image to be returned</param>
        /// <param name="frameWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="frameHeight">the height (in pixles) of the 'frame' it is to occupy</param>
        /// <returns>the Image pointed identified by key</returns>
        Image getImage(String key, int frameWidth, int frameHeight);

        /// <summary>
        /// Returns a copy of the image specified by 'key', rotated by 'rotateDegrees'. Updates image inside image storage class.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="frameWidth"></param>
        /// <param name="frameHeight"></param>
        /// <param name="rotateDegrees"></param>
        /// <returns></returns>
        Image RotateImage(string key, int frameWidth, int frameHeight, float rotateDegrees);

        /// <summary>
        /// Returns a copy of the image specified by 'key', flipped horizontal, vertical or both. Updates image inside image storage class.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="frameWidth"></param>
        /// <param name="frameHeight"></param>
        /// <param name="flipVeritcal"></param>
        /// <param name="flipHorizontal"></param>
        /// <returns></returns>
        Image FlipImage(string key, int frameWidth, int frameHeight, bool flipVeritcal, bool flipHorizontal);

        /// <summary>
        /// Returns a copy of the image specified by 'key', resized to 'frameWidth' and 'frameHeight'. Updates image inside image storage class.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="frameWidth"></param>
        /// <param name="frameHeight"></param>
        /// <returns></returns>
        Image Resize(string key, int frameWidth, int frameHeight);
    }
}