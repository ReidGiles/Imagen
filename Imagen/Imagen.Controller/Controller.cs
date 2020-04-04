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
            command.Execute();
        }

        private void OpenDisplayView(string imageKey, Image image)
        {
            IDisplayModel displayModel = new DisplayModel(_imageManager, imageKey);

            DisplayView displayView = new DisplayView();

            (displayModel as IDisplayPublisher).Subscribe((displayView as IDisplayListener).OnNewInput);

            displayView.Initialise(ExecuteCommand, displayModel.LoadImage, displayModel.RotateImage, displayModel.FlipImage, displayModel.ResizeImage, imageKey);            

            displayView.Text = "Display View";

            displayView.Show();
        }
    }
}