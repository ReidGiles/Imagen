using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Imagen.Core;

namespace Imagen.Views
{
    public partial class CollectionView : Form, ICollectionListener
    {
        // DECLARE an ExecuteDelegate, call it '_execute':
        private ExecuteDelegate _execute;

        private Action<IList<string>, int, int> _loadImages;

        int imageNum = 1;
        int x = 0;
        int y = 0;
        int _height = 150;
        int _width = 150;

        public CollectionView()
        {
            InitializeComponent();
        }

        public void Initialise(ExecuteDelegate execute, Action<IList<string>, int, int> loadImages)
        {
            // SET _execute:
            _execute = execute;

            _loadImages = loadImages;

            this.imagePanel.AutoScroll = true;
        }

        void ICollectionListener.OnNewInput(object source, CollectionEventArgs args)
        {
            foreach (Image image in args.Images)
            {
                PictureBox picture = new PictureBox();
                picture.Location = new Point(x, y);
                picture.Size = new Size(_width, _height);
                picture.Image = image;
                imagePanel.Controls.Add(picture);

                if (imageNum % 3 == 0)
                {
                    x = 0;
                    y += 175;
                }
                else
                {
                    x += 175;
                }

                imageNum += 1;
            }
        }

        private void btnLoadImages_Click(object sender, EventArgs e)
        {
            OpenFileDialog filePicker = new OpenFileDialog();
            filePicker.Multiselect = true;
            DialogResult result = filePicker.ShowDialog();

            ICommand loadImages = new Command<IList<string>, int, int>(_loadImages, filePicker.FileNames.ToList(), _width, _height);
            _execute(loadImages);
        }
    }
}