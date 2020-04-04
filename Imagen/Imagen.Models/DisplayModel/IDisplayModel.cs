using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagen.Models
{
    public interface IDisplayModel
    {
        void LoadImage(string imageKey, int width, int height);
        void RotateImage(string imageKey, int width, int height, float rotateDegrees);
        void FlipImage(string key, int width, int height, bool flipVeritcal, bool flipHorizontal);
        void ResizeImage(string imageKey, int width, int height);
    }
}