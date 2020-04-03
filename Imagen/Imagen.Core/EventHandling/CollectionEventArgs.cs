using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    public class CollectionEventArgs
    {
        /// <summary>
        /// Property to hold the published images
        /// </summary>
        public IList<Image> Images { get; set; }

        /// <summary>
        /// Constructor for CollectionEventArgs
        /// </summary>
        public CollectionEventArgs(IList<Image> images)
        {
            // INSTANTIATE _images
            this.Images = images;
        }
    }
}