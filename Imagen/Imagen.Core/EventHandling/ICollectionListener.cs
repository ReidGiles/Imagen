using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    /// <summary>
    /// Event listener for collection events
    /// 
    /// Author: Reid Giles
    /// </summary>
    public interface ICollectionListener
    {
        /// <summary>
        /// Listener method, receives collection events.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        void OnNewInput(object source, CollectionEventArgs args);
    }
}