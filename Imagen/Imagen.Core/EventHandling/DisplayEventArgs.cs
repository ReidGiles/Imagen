using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    public class DisplayEventArgs
    {
        /// <summary>
        /// Property to hold the published image
        /// </summary>
        public Image Image { get; set; }

        public DisplayEventArgs(Image image)
        {
            // INSTANTIATE Image:
            Image = image;
        }
    }
}