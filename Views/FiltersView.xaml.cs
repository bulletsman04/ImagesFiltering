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
    /// Interaction logic for FiltesView.xaml
    /// </summary>
    public partial class FiltersView : UserControl
    {
        private FiltersViewModel _filtersViewModel;

        public FiltersView()
        {
            InitializeComponent();
            DataContextChanged += this.HandleDataContextChanged;

        }

        private void HandleDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Store a reference to the ViewModel.
            _filtersViewModel = base.DataContext as FiltersViewModel;
        }
    }
}
