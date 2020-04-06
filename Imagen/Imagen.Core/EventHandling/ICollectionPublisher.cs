using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    /// <summary>
    /// Event publisher for collection events
    /// 
    /// Author: Reid Giles
    /// </summary>
    public interface ICollectionPublisher
    {
        /// <summary>
        /// Event subscriber, subscribes collection listeners.
        /// </summary>
        /// <param name="handler"></param>
        void Subscribe(EventHandler<CollectionEventArgs> handler);
        /// <summary>
        /// Event unsubscriber, unsubscribes collection listeners.
        /// </summary>
        /// <param name="handler"></param>
        void Unsubscribe(EventHandler<CollectionEventArgs> handler);
    }
}