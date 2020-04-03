using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    public interface ICollectionListener
    {
        void OnNewInput(object source, CollectionEventArgs args);
    }
}