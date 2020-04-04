using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    public interface IDisplayListener
    {
        void OnNewInput(object source, DisplayEventArgs args);
    }
}