using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Models;
using MvvmFoundation.Wpf;

namespace ViewModels
{
    public class ActionsViewModel
    {
        private FilteringManager _filteringManager;
        RelayCommand _applyFilterCommand;
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

        public ActionsViewModel(FilteringManager filteringManager)
        {
            _filteringManager = filteringManager;
        }

        private void ApplyFilter()
        {
            _filteringManager.Filter();
        }
    }
}
