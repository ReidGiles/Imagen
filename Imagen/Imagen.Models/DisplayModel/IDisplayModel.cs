using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Models
{
    /// <summary>
    /// Model for displays.
    /// 
    /// Author: Reid Giles
    /// </summary>
    public interface IDisplayModel
    {
        /// <summary>
        /// Loads an image into storage.
        /// Fires an event containing the loaded image to display listeners.
        /// </summary>
        /// <param name="pathfilenames"></param>
        /// <param name="frameWidth"></param>
        /// <param name="frameHeight"></param>
        void LoadImage(string imageKey, int width, int height);

        /// <summary>
        /// Rotates an image.
        /// Fires an event containing the rotated image to display listeners.
        /// </summary>
        /// <param name="imageKey"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="rotateDegrees"></param>
        void RotateImage(string imageKey, int width, int height, float rotateDegrees);

        /// <summary>
        /// Flips an image.
        /// Fires an event containing the flipped image to display listeners.
        /// </summary>
        /// <param name="imageKey"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="rotateDegrees"></param>
        void FlipImage(string key, int width, int height, bool flipVeritcal, bool flipHorizontal);

        /// <summary>
        /// Resizes an image.
        /// Fires an event containing the resized image to display listeners.
        /// </summary>
        /// <param name="imageKey"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="rotateDegrees"></param>
        void ResizeImage(string imageKey, int width, int height);
    }
}