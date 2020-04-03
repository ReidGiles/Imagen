using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Models
{
    public interface ICollectionModel
    {
        void LoadImages(IList<string> pathfilenames, int frameWidth, int frameHeight);
    }
}