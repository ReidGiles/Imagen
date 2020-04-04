using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imagen.Core;

namespace Imagen.Models
{
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

        public void LoadImage(string imageKey, int width, int height)
        {
            Image image = _imageManager.getImage(imageKey, width, height);
            DisplayEventArgs args = new DisplayEventArgs(image);
            DisplayEvent(this, args);
        }

        public void RotateImage(string imageKey, int width, int height, float rotateDegrees)
        {
            Image image = _imageManager.RotateImage(imageKey, width, height, rotateDegrees);
            DisplayEventArgs args = new DisplayEventArgs(image);
            DisplayEvent(this, args);
        }

        public void FlipImage(string key, int width, int height, bool flipVeritcal, bool flipHorizontal)
        {
            Image image = _imageManager.FlipImage(key, width, height, flipVeritcal, flipHorizontal);
            DisplayEventArgs args = new DisplayEventArgs(image);
            DisplayEvent(this, args);
        }

        public void ResizeImage(string imageKey, int width, int height)
        {
            Image image = _imageManager.Resize(imageKey, width, height);
            DisplayEventArgs args = new DisplayEventArgs(image);
            DisplayEvent(this, args);
        }

        public void Subscribe(EventHandler<DisplayEventArgs> handler)
        {
            DisplayEvent += handler;
        }

        public void Unsubscribe(EventHandler<DisplayEventArgs> handler)
        {
            DisplayEvent -= handler;
        }
    }
}