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

namespace Views
{
    /// <summary>
    /// Interaction logic for ActionsView.xaml
    /// </summary>
    public partial class ActionsView : UserControl
    {
        private bool _isColor1 = true;
        public ActionsView()
        {
            InitializeComponent();
        }

        private void BrushButton_OnClick(object sender, RoutedEventArgs e)
        {
            var color1 = new SolidColorBrush(Color.FromRgb(221,221,221));
            var color2 = new SolidColorBrush(Color.FromRgb(100, 100, 100));

            if (_isColor1)
            {
                BrushButton.Background = color2;
                _isColor1 = false;
            }
            else
            {
                BrushButton.Background = color1;
                _isColor1 = true;
            }
        }
    }
}
