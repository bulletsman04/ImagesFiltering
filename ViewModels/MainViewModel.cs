using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Filters;

namespace ViewModels
{
    public class MainViewModel
    {
        public MenuViewModel MenuViewModel { get; set; }
        public ImageViewModel ImageViewModel { get; set; }
        public FiltersViewModel FiltersViewModel { get; set; }

        public BitmapManager BitmapManager { get; }
        public FilteringManager FilteringManager { get; }
        public MainViewModel()
        {
            BitmapManager = new BitmapManager();
            FilteringManager = new FilteringManager(BitmapManager);

            MenuViewModel = new MenuViewModel();
            ImageViewModel = new ImageViewModel(BitmapManager);
            FiltersViewModel = new FiltersViewModel(FilteringManager);
        }
    }
}
