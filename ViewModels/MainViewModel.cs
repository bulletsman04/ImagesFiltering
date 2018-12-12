using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.CustomFunction;
using Models.Filtering;
using Models.Filters;

namespace ViewModels
{
    public class MainViewModel
    {
        public MenuViewModel MenuViewModel { get; set; }
        public ImageViewModel ImageViewModel { get; set; }
        public FiltersViewModel FiltersViewModel { get; set; }
        public ActionsViewModel ActionsViewModel { get; set; }
        public HistogramsViewModel HistogramsViewModel { get; set; }
        public FunctionViewModel FunctionViewModel { get; set; }

        public BitmapManager BitmapManager { get; }

        public HistogramsManager HistogramsManager { get; }
        public FilteringManager FilteringManager { get; }
        public CustomFunctionManager CustomFunctionManager { get; set; }
        public FilteringArea FilteringArea { get; set; }
        public MainViewModel()
        {
            
            HistogramsManager = new HistogramsManager();
            BitmapManager = new BitmapManager(HistogramsManager);
            FilteringArea = new FilteringArea(BitmapManager.PixelMap);
            FilteringManager = new FilteringManager(BitmapManager, HistogramsManager,FilteringArea);
            CustomFunctionManager = new CustomFunctionManager();

            MenuViewModel = new MenuViewModel(BitmapManager);
            ImageViewModel = new ImageViewModel(BitmapManager, FilteringManager);
            FiltersViewModel = new FiltersViewModel(FilteringManager,CustomFunctionManager);
            ActionsViewModel = new ActionsViewModel(FilteringManager);
            HistogramsViewModel = new HistogramsViewModel(HistogramsManager);
            FunctionViewModel = new FunctionViewModel(CustomFunctionManager);
            
        }
    }
}
