using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Models;
using Models.Filtering;
using MvvmFoundation.Wpf;

namespace ViewModels
{
    public class ActionsViewModel
    {
        private FilteringManager _filteringManager;
        RelayCommand _applyFilterCommand;
        RelayCommand _brushCommand;
        public ICommand ApplyFilterCommand
        {
            get
            {
                if (_applyFilterCommand == null)
                {
                    _applyFilterCommand = new RelayCommand(this.ApplyFilter,
                        null);
                }
                return _applyFilterCommand;
            }
        }

        public ICommand BrushCommand
        {
            get
            {
                if (_brushCommand == null)
                {
                    _brushCommand = new RelayCommand(this.TurnOnBrush,
                        null);
                }
                return _brushCommand;
            }
        }

        public ActionsViewModel(FilteringManager filteringManager)
        {
            _filteringManager = filteringManager;
        }

        private void ApplyFilter()
        {
            if (_filteringManager.FilteringArea.FilteringMode == FilteringMode.Bitmap)
            {
                _filteringManager.Filter();
            }
        }
        private void TurnOnBrush()
        {
            if (_filteringManager.FilteringArea.FilteringMode == FilteringMode.PreBrush)
            {
                _filteringManager.FilteringArea.FilteringMode = FilteringMode.Bitmap;
            }
            else
            {
                _filteringManager.FilteringArea.FilteringMode = FilteringMode.PreBrush;
            }
        }
    }
}
