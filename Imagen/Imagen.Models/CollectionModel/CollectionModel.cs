using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imagen.Core;

namespace Imagen.Models
{
    public class CollectionModel : ICollectionModel, ICollectionPublisher
    {
        // DECLARE an IImageManager, call it '_imageManager':
        private IImageManager _imageManager;

        // DECLARE an event for storing collection event handlers, call it '_collectionEvent':
        private event EventHandler<CollectionEventArgs> CollectionEvent;

        /// <summary>
        /// Contructor for the collection model
        /// </summary>
        public CollectionModel(IImageManager imageManager)
        {
            // INSTANTIATE _imageManager
            _imageManager = imageManager;
        }

        public void LoadImages(IList<string> pathfilenames, int frameWidth, int frameHeight)
        {
            IDictionary<string, Image> images = new Dictionary<string, Image>();
            IList<String> imageKeyList = new List<String>();
            imageKeyList = _imageManager.load(pathfilenames);
            foreach (string key in imageKeyList)
            {
                images.Add(key, _imageManager.getImage(key, frameWidth, frameHeight));
            }

            CollectionEventArgs args = new CollectionEventArgs(images);
            CollectionEvent(this, args);
        }

        /// <summary>
        /// Subscribe a listener to the collection event
        /// </summary>
        /// <param name="handler"></param>
        public void Subscribe(EventHandler<CollectionEventArgs> handler)
        {
            CollectionEvent += handler;
        }

        /// <summary>
        /// Unsubscribe a listener from the collection event
        /// </summary>
        /// <param name="handler"></param>
        public void Unsubscribe(EventHandler<CollectionEventArgs> handler)
        {
            CollectionEvent -= handler;
        }
    }
}