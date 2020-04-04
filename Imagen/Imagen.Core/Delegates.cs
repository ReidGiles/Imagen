using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    /// <summary>
    /// Declare a delegate to execute commands, call it 'ExecuteDelegate'
    /// </summary>
    /// <param name="command"></param>
    public delegate void ExecuteDelegate(ICommand command);
}