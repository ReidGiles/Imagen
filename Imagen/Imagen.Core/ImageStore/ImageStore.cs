﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    /// <summary>
    /// Data storage class, retrieves stores and sets images into a dictionary.
    /// 
    /// Author: Reid Giles
    /// </summary>
    class ImageStore : IImageStore
    {
        // DECLARE an IDictionary of type Image, call it 'imageDictionary'
        private IDictionary<string, Image> _imageDic;

        /// <summary>
        /// Constructor for Images
        /// </summary>
        public ImageStore()
        {
            // INSTANTIATE _imageDic
            _imageDic = new Dictionary<string, Image>();
        }

        /// <summary>
        /// Deletes an image from memory.
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="pImage"></param>
        /// <returns></returns>
        public bool Delete(string pKey, Image pImage)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns an image from memory.
        /// </summary>
        /// <param name="pKey"></param>
        /// <returns></returns>
        public Image Retrieve(string pKey)
        {
            return _imageDic[pKey];
        }

        /// <summary>
        /// Stores an image in memory.
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="pImage"></param>
        /// <returns></returns>
        public void Set(string pKey, Image pImage)
        {
            // IF the image already exists in the dictionary, overwrite the image:
            if (_imageDic.ContainsKey(pKey))
            {
                _imageDic[pKey] = pImage;
            }
            // ELSE add the image as a new entry:
            else
            {
                _imageDic.Add(pKey, pImage);
            }
        }
    }
}