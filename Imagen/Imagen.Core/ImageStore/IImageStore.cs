using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    /// <summary>
    /// Data storage, retrieves stores and sets images into a dictionary.
    /// 
    /// Author: Reid Giles
    /// </summary>
    public interface IImageStore
    {
        /// <summary>
        /// Returns an image from memory.
        /// </summary>
        /// <param name="pKey"></param>
        /// <returns></returns>
        Image Retrieve(string pFilePath);

        /// <summary>
        /// Deletes an image from memory.
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="pImage"></param>
        /// <returns></returns>
        bool Delete(string pKey, Image pImage);

        /// <summary>
        /// Stores an image in memory.
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="pImage"></param>
        /// <returns></returns>
        void Set(string pKey, Image pImage);
    }
}