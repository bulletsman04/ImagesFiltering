using System;
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
using ViewModels;

namespace Views
{
    /// <summary>
    /// Interaction logic for ImageView.xaml
    /// </summary>
    public partial class ImageView : UserControl
    {
        private ImageViewModel _imageViewModel;
        public ImageView()
        {
            InitializeComponent();
            DataContextChanged += this.HandleDataContextChanged;

        }

        private void HandleDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Store a reference to the ViewModel.
            _imageViewModel = base.DataContext as ImageViewModel;
        }

        private void Image_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePoint = e.GetPosition(ImageHolder);
            _imageViewModel.HandleMouseDown();
        }
        
        private void Image_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_imageViewModel.IsPreOrBrushMode())
            {
                Point mousePoint = e.GetPosition(ImageHolder);
                int delimeter = (int) Brush.Width;
                Canvas.SetLeft(Brush, mousePoint.X - delimeter / 2);
                Canvas.SetTop(Brush, mousePoint.Y - delimeter / 2);
                Point mousePointToImage = e.GetPosition(Area);

                _imageViewModel.HandleMouseMove(mousePointToImage, Area.ActualWidth, Area.ActualHeight);
            }
            else
            {
                Canvas.SetLeft(Brush, 2000);
                Canvas.SetTop(Brush, 2000);
            }
        }

        private void Image_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            Point mousePoint = e.GetPosition(ImageHolder);
        


            _imageViewModel.HandleMouseUp();
        }
    }
}
