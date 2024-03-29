﻿using System;
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
    /// Interaction logic for HistogramsView.xaml
    /// </summary>
    public partial class HistogramsView : UserControl
    {
        private HistogramsViewModel _histogramsViewModel;

        public HistogramsView()
        {
            InitializeComponent();
            DataContextChanged += this.HandleDataContextChanged;

        }

        private void HandleDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Store a reference to the ViewModel.
            _histogramsViewModel = base.DataContext as HistogramsViewModel;
        }
    }
}
