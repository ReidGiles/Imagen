using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    /// <summary>
    /// Event argument class for collection events.
    /// 
    /// Author: Reid Giles
    /// </summary>
    public class CollectionEventArgs
    {
        /// <summary>
        /// Property to hold the published images with their unique ID
        /// </summary>
        public IDictionary<string, Image> Images { get; set; }

        /// <summary>
        /// Constructor for CollectionEventArgs
        /// </summary>
        public CollectionEventArgs(IDictionary<string, Image> images)
        {
            // INSTANTIATE _images:
            this.Images = images;
        }
    }
}