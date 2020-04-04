using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    public interface IDisplayPublisher
    {
        void Subscribe(EventHandler<DisplayEventArgs> handler);
        void Unsubscribe(EventHandler<DisplayEventArgs> handler);
    }
}