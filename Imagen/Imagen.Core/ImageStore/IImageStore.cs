using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Core
{
    public interface IImageStore
    {
        Image Retrieve(string pFilePath);
        bool Delete(string pKey, Image pImage);
        void Set(string pKey, Image pImage);
    }
}