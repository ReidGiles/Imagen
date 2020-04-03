using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    public interface ICollectionPublisher
    {
        void Subscribe(EventHandler<CollectionEventArgs> handler);
        void Unsubscribe(EventHandler<CollectionEventArgs> handler);
    }
}