using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Controller
{
    interface ICommand
    {
        /// <summary>
        /// Executes the command
        /// </summary>
        void Execute();
    }
}