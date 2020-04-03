using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    public interface ICommand
    {
        /// <summary>
        /// Executes the command
        /// </summary>
        void Execute();
    }
}