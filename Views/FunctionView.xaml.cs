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
    /// Interaction logic for FunctionView.xaml
    /// </summary>
    public partial class FunctionView : UserControl
    {
        private FunctionViewModel _functionViewModel;

        public FunctionView()
        {
            InitializeComponent();
            DataContextChanged += this.HandleDataContextChanged;

        }

        private void HandleDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Store a reference to the ViewModel.
            _functionViewModel = base.DataContext as FunctionViewModel;
        }

        private void CustomFunction_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePoint = e.GetPosition(sender as Image);
            Image chart = sender as Image;
            
            _functionViewModel.HandleMouseDown(mousePoint,CustomFunctionR.ActualWidth,CustomFunctionR.ActualHeight,chart.Name);

        }

        private void CustomFunction_OnMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = e.GetPosition(sender as Image);
            Image chart = sender as Image;
            _functionViewModel.HandleMouseMove(mousePoint,CustomFunctionR.ActualWidth, CustomFunctionR.ActualHeight, chart.Name);
        }

        private void CustomFunction_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            Image chart = sender as Image;
            _functionViewModel.HandleMouseUp(chart.Name);
        }
    }
}
