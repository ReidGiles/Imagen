using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Imagen.Views;
using Imagen.Models;
using Imagen.Core;

namespace Imagen.Controller
{
    class Controller
    {
        // DECLARE a collectionView, call it '_collectionView':
        private CollectionView _collectionView;

        // DECLARE a collectionModel, call it '_collectionModel':
        private ICollectionModel _collectionModel;
        
        /// <summary>
        /// Constructor for the Controller
        /// </summary>
        public Controller()
        {
            // INSTANTIIATE _collectionModel:
            _collectionModel = new CollectionModel();

            // INSTANTIATE _collectionView:
            _collectionView = new CollectionView();

            _collectionView.Initialise(ExecuteCommand, _collectionModel.LoadImages);

            (_collectionModel as ICollectionPublisher).Subscribe( (_collectionView as ICollectionListener).OnNewInput );

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
    }
}