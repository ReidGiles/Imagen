using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imagen.Core;

namespace Imagen.Models
{
    /// <summary>
    /// Model for displays.
    /// 
    /// Author: Reid Giles
    /// </summary>
    public class DisplayModel : IDisplayModel, IDisplayPublisher
    {
        // DECLARE an IImageManager, call it '_imageManager':
        private IImageManager _imageManager;

        string _key;

        private event EventHandler<DisplayEventArgs> DisplayEvent;

        public DisplayModel(IImageManager imageManager, string key)
        {
            _imageManager = imageManager;
            _key = key;
        }

        /// <summary>
        /// Loads an image into storage.
        /// Fires an event containing the loaded images to display listeners.
        /// </summary>
        /// <param name="pathfilenames"></param>
        /// <param name="frameWidth"></param>
        /// <param name="frameHeight"></param>
        public void LoadImage(string imageKey, int width, int height)
        {
            Image image = _imageManager.getImage(imageKey, width, height);
            DisplayEventArgs args = new DisplayEventArgs(image);
            DisplayEvent(this, args);
        }

        /// <summary>
        /// Rotates an image.
        /// Fires an event containing the rotated image to display listeners.
        /// </summary>
        /// <param name="imageKey"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="rotateDegrees"></param>
        public void RotateImage(string imageKey, int width, int height, float rotateDegrees)
        {
            Image image = _imageManager.RotateImage(imageKey, width, height, rotateDegrees);
            DisplayEventArgs args = new DisplayEventArgs(image);
            DisplayEvent(this, args);
        }

        /// <summary>
        /// Flips an image.
        /// Fires an event containing the flipped image to display listeners.
        /// </summary>
        /// <param name="imageKey"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="rotateDegrees"></param>
        public void FlipImage(string key, int width, int height, bool flipVeritcal, bool flipHorizontal)
        {
            Image image = _imageManager.FlipImage(key, width, height, flipVeritcal, flipHorizontal);
            DisplayEventArgs args = new DisplayEventArgs(image);
            DisplayEvent(this, args);
        }

        /// <summary>
        /// Resizes an image.
        /// Fires an event containing the resized image to display listeners.
        /// </summary>
        /// <param name="imageKey"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="rotateDegrees"></param>
        public void ResizeImage(string imageKey, int width, int height)
        {
            Image image = _imageManager.Resize(imageKey, width, height);
            DisplayEventArgs args = new DisplayEventArgs(image);
            DisplayEvent(this, args);
        }

        /// <summary>
        /// Event subscriber, subscribes display listeners.
        /// </summary>
        /// <param name="handler"></param>
        public void Subscribe(EventHandler<DisplayEventArgs> handler)
        {
            DisplayEvent += handler;
        }

        /// <summary>
        /// Event unsubscriber, unsubscribes display listeners.
        /// </summary>
        /// <param name="handler"></param>
        public void Unsubscribe(EventHandler<DisplayEventArgs> handler)
        {
            DisplayEvent -= handler;
        }
    }
}