using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    /// <summary>
    /// Event publisher for display events
    /// 
    /// Author: Reid Giles
    /// </summary>
    public interface IDisplayPublisher
    {
        /// <summary>
        /// Event subscriber, subscribes display listeners.
        /// </summary>
        /// <param name="handler"></param>
        void Subscribe(EventHandler<DisplayEventArgs> handler);

        /// <summary>
        /// Event unsubscriber, unsubscribes display listeners.
        /// </summary>
        /// <param name="handler"></param>
        void Unsubscribe(EventHandler<DisplayEventArgs> handler);
    }
}