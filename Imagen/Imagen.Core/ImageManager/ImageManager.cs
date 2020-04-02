using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    /// <summary>
    /// Controller class, masks the functionality of ImageProcessor and Images.
    /// 
    /// Author: Reid Giles
    /// </summary>
    class ImageManager : IImageManager
    {
        // DECLARE an IImages, call it '_images'
        private IImageStore _images;

        // DECLARE an IImageProcessor, call it '_imageProcessor'
        private IImageProcessor _imageProcessor;

        /// <summary>
        /// Constructor for ImageManager
        /// </summary>
        public ImageManager()
        {
            // INSTANTIATE _images
            _images = new ImageStore();

            // INSTANTIATE _imageProcessorr
            _imageProcessor = new ImageProcessor();
        }

        /// <summary>
        /// Displays an image on the user form, resized appropriately.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="frameWidth"></param>
        /// <param name="frameHeight"></param>
        /// <returns></returns>
        public Image getImage(string key, int frameWidth, int frameHeight)
        {
            return _imageProcessor.ResizeImage(_images.Retrieve(key), new Size(frameWidth, frameHeight));

        }

        /// <summary>
        /// Loads a list of images into memory and stores the unique ID's for later retrieval.
        /// </summary>
        /// <param name="pathfilenames"></param>
        /// <returns></returns>
        public IList<string> load(IList<string> pathfilenames)
        {
            IList<String> uIDList = new List<String>();
            foreach (string filePath in pathfilenames)
            {
                Image image = _imageProcessor.LoadImage(filePath);
                String uID = Guid.NewGuid().ToString();
                _images.Set(uID, image);
                uIDList.Add(uID);
            }
            return uIDList;
        }
    }
}