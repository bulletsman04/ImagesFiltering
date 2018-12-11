using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.CustomFunction;
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
        public CustomFunctionBitmap CustomFunctionBitmap { get; set; }
        public CustomFunction CustomFunction { get; set; }
        public MainViewModel()
        {
            
            HistogramsManager = new HistogramsManager();
            BitmapManager = new BitmapManager(HistogramsManager);
            FilteringManager = new FilteringManager(BitmapManager, HistogramsManager);
            CustomFunction = new CustomFunction();
            CustomFunctionBitmap = new CustomFunctionBitmap(CustomFunction);

            MenuViewModel = new MenuViewModel();
            ImageViewModel = new ImageViewModel(BitmapManager, FilteringManager);
            FiltersViewModel = new FiltersViewModel(FilteringManager,CustomFunction);
            ActionsViewModel = new ActionsViewModel(FilteringManager);
            HistogramsViewModel = new HistogramsViewModel(HistogramsManager);
            FunctionViewModel = new FunctionViewModel(CustomFunctionBitmap);
            
        }
    }
}
