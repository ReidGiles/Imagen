using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Imagen.Views;
using Imagen.Models;
using Imagen.Core;
using System.Drawing;

namespace Imagen.Controller
{
    /// <summary>
    /// Controller class.
    /// 
    /// Author: Reid Giles
    /// </summary>
    class Controller
    {
        // DECLARE an IImageManager, call it '_imageManager':
        private IImageManager _imageManager;

        // DECLARE a collectionView, call it '_collectionView':
        private CollectionView _collectionView;

        // DECLARE a collectionModel, call it '_collectionModel':
        private ICollectionModel _collectionModel;
        
        /// <summary>
        /// Constructor for the Controller
        /// </summary>
        public Controller()
        {
            // INSTANTIATE _imageManager:
            _imageManager = new ImageManager();

            // INSTANTIIATE _collectionModel:
            _collectionModel = new CollectionModel(_imageManager);

            // INSTANTIATE _collectionView:
            _collectionView = new CollectionView();

            _collectionView.Initialise(ExecuteCommand, _collectionModel.LoadImages, OpenDisplayView);

            (_collectionModel as ICollectionPublisher).Subscribe((_collectionView as ICollectionListener).OnNewInput);

            // Set view title bar
            _collectionView.Text = "Imagen Demo Application";
            // Open view
            Application.Run(_collectionView);
        }

        /// <summary>
        /// Executes the passed command
        /// </summary>
        /// <param name="command"></param>
        public void ExecuteCommand(ICommand command)
        {
            // Execute the command:
            command.Execute();
        }

        /// <summary>
        /// Opens a display view with a specified image.
        /// </summary>
        /// <param name="imageKey"></param>
        /// <param name="image"></param>
        private void OpenDisplayView(string imageKey, Image image)
        {
            IDisplayModel displayModel = new DisplayModel(_imageManager, imageKey);

            DisplayView displayView = new DisplayView();

            // Subscribe displayView to displayModel:
            (displayModel as IDisplayPublisher).Subscribe((displayView as IDisplayListener).OnNewInput);

            // Initialise displayView with ExecuteDelegate and a collection of Actions to execute:
            displayView.Initialise(ExecuteCommand, displayModel.LoadImage, displayModel.RotateImage, displayModel.FlipImage, displayModel.ResizeImage, SaveImage, imageKey);            

            // Set the displayView window title:
            displayView.Text = "Display View";

            // Open displayView:
            displayView.Show();
        }

        /// <summary>
        /// Saves a copy of the image to the user specified file path.
        /// </summary>
        /// <param name="image"></param>
        private void SaveImage(Image image)
        {
            /*
             * Code reference:
             * 
             * URL: docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-save-files-using-the-savefiledialog-component
             * Author: Microsoft
             * Date: 03/30/2017
            */

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Png Image|*.png|JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        image.Save(fs,
                        System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case 2:
                        image.Save(fs,
                        System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        image.Save(fs,
                        System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case 4:                        
                        image.Save(fs,
                        System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                }
                fs.Close();
            }
        }
    }
}