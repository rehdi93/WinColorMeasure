using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gma.System.MouseKeyHook;
using ColorMesure;
using ColorMesure.Wpf.Extensions;


namespace ColorMesureUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WpfPixelGetter pixelGetter;
        IKeyboardMouseEvents mouseEvents;
        Color currentColor;
        bool beeingMoved;

        public MainWindow()
        {
            InitializeComponent();
            //this.MouseLeftButtonUp += MainWindow_MouseLeftButtonUp;
            this.PreviewMouseLeftButtonUp += MainWindow_PreviewMouseLeftButtonUp;

            mouseEvents = Hook.GlobalEvents();
            mouseEvents.MouseMove += GlobalMouse_Move;

            pixelGetter = new WpfPixelGetter();

            var bmf = BitmapFrame.Create(pixelGetter.GetDesktopImageStream());
            previewImage.Source = bmf;

            DragMove();
        }

        private void MainWindow_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            beeingMoved = false;

        }

        void ColorUpdate(Color color)
        {
            var br = new SolidColorBrush(color);
            if (br == colorPreviewRect.Fill)
                return;

            currentColor = color;
            colorPreviewRect.Fill = br;

            colorInfoText.Text = 
                $"R:   {color.R}\n\nG:   {color.G}\n\nB:   {color.B}\n\nHex: {color.ToHexString()}";
        }


        private void GlobalMouse_Move(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.WindowState == WindowState.Minimized || beeingMoved)
            {
                return;
            }

            var color = pixelGetter.GetPixelColor(new Point(e.X, e.Y));
            ColorUpdate(color);

            statusMousePos.Text = $"({e.X}, {e.Y})";
        }

        protected override void OnClosed(EventArgs e)
        {
            mouseEvents.MouseMove -= GlobalMouse_Move;
            mouseEvents.Dispose();

            base.OnClosed(e);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            beeingMoved = true;
            base.OnLocationChanged(e);
        }

        private void MainWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            beeingMoved = false;
        }


        //protected override void OnPreviewMouseMove(MouseEventArgs e)
        //{
        //    if (this.WindowState == WindowState.Minimized)
        //    {
        //        return;
        //    }

        //    var position = e.GetPosition(this);
        //    var color = pixelGetter.GetPixelColor(position);
        //    ColorUpdate(color);

        //    statusMousePos.Text = $"({position.X}, {position.Y})";

        //    base.OnPreviewMouseMove(e);
        //}
    }
}
