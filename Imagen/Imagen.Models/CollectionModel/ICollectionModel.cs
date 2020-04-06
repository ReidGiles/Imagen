using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Models
{
    /// <summary>
    /// Model for collections.
    /// 
    /// Author: Reid Giles
    /// </summary>
    public interface ICollectionModel
    {
        /// <summary>
        /// Loads a group of images into storage from a list of pathFileNames & width/height.
        /// Fires an event containing the loaded images to collection listeners.
        /// </summary>
        /// <param name="pathfilenames"></param>
        /// <param name="frameWidth"></param>
        /// <param name="frameHeight"></param>
        void LoadImages(IList<string> pathfilenames, int frameWidth, int frameHeight);
    }
}