using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    /// <summary>
    /// Event argument class for display events
    /// 
    /// Author: Reid Giles
    /// </summary>
    public class DisplayEventArgs : EventArgs
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