using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace PictureBox_Zoom
{
    public partial class MainForm : Form
    {
        #region Constructor

        /// <summary>
        /// Default constructor for MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Synchronize some private members with the form's values.
            //_ZoomFactor = trbZoomFactor.Value;
            _ZoomFactor = zoomPopupBox1.ZoomFactor;
            //_BackColor = picImage.BackColor;

            // Set the sizemode of both pictureboxes. These modes are important
            // to the functionality and should not be changed.
            //picImage.SizeMode = PictureBoxSizeMode.CenterImage;
            //picZoom.SizeMode = PictureBoxSizeMode.StretchImage;

            imageBoxZoom.MouseMove += ImageBoxZoom_MouseMove;
            imageBoxZoom.MouseClick += ImageBoxZoom_MouseClick;

            zoomPopupBox1.ZoomFactorChanged += ZoomPopupBox1_ZoomFactorChanged;
        }

        private void ZoomPopupBox1_ZoomFactorChanged(object sender, int e)
        {
            imageBoxZoom.ZoomFactor = e;
        }

        private void ImageBoxZoom_MouseClick(object sender, MouseEventArgs e)
        {
            zoomPopupBox1.SetZoomedImage(imageBoxZoom.Image, e.Location);
        }

        private void ImageBoxZoom_MouseMove(object sender, MouseEventArgs e)
        {
        }

        #endregion // Constructor

        #region Private members

        /// <summary>
        /// Stores the zoomfactor of the picZoom picturebox
        /// </summary>
        private int _ZoomFactor;
        /// <summary>
        /// Stores the color used to fill any areas not covered by an image
        /// </summary>
        private Color _BackColor;
        /// <summary>
        /// Stores an instance of the originally loaded image
        /// </summary>
        private Image _OriginalImage;

        #endregion // Private members

        #region Control Event Handlers

        /// <summary>
        /// Shows an OpenFileDialog to let the user select an image to load.
        /// </summary>
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.AddExtension = false;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Filter = "Supported Image File|*.jpg;*.jpeg;*.bmp;*.png;*.dib;*.gif";
            openFileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.Multiselect = false;
            openFileDialog.ReadOnlyChecked = false;
            openFileDialog.ShowHelp = true;
            openFileDialog.ShowReadOnly = false;
            openFileDialog.SupportMultiDottedExtensions = true;
            openFileDialog.Title = "Select an image...";
            openFileDialog.ValidateNames = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _OriginalImage = Image.FromFile(openFileDialog.FileName);
                    //ResizeAndDisplayImage();
                    imageBoxZoom.Image = _OriginalImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured loading the image " +
                                    openFileDialog.FileName + "\r\n" +
                                    ex.Message +
                                    "Please ensure you select a supported image type.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }

            openFileDialog.Dispose();
        }

        /// <summary>
        /// Shows a color picker to set the background color.
        /// It will redraw the image to match the new background color.
        /// </summary>
        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            colorDialog.AllowFullOpen = true;
            colorDialog.AnyColor = true;
            colorDialog.Color = _BackColor;
            colorDialog.FullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.SolidColorOnly = false;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _BackColor = colorDialog.Color;
                //ResizeAndDisplayImage();
            }

            colorDialog.Dispose();
        }

        /// <summary>
        /// Set the _ZoomFactor value to match the trbZoomFactor control's value
        /// and display the selected value to the user
        /// </summary>
        private void trbZoomFactor_ValueChanged(object sender, EventArgs e)
        {
            imageBoxZoom.ZoomFactor = _ZoomFactor;

            zoomPopupBox1.Image = imageBoxZoom.ZoomedImage;
        }

        /// <summary>
        /// When the mouse is moved over the picImage picturebox, the picZoom
        /// picturebox must reflect the change and adjust its image to the portion
        /// of the image the mouse is over
        /// </summary>
        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            // If no picture is loaded, return
            //if (picImage.Image == null)
            //    return;

            //UpdateZoomedImage(e);
        }

        #endregion // Control Event Handlers

        #region Private Methods

       

        #endregion // Private Methods
    }
}