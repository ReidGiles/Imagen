using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    /// <summary>
    /// Event listener for display events
    /// 
    /// Author: Reid Giles
    /// </summary>
    public interface IDisplayListener
    {
        /// <summary>
        /// Listener method, receives display events.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        void OnNewInput(object source, DisplayEventArgs args);
    }
}