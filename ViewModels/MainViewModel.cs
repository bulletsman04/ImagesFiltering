using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ViewModels
{
    public class MainViewModel
    {
        public MenuViewModel MenuViewModel { get; set; }
        public ImageViewModel ImageViewModel { get; set; }
        public BitmapManager BitmapManager { get; }
        public MainViewModel()
        {
            BitmapManager = new BitmapManager();

            MenuViewModel = new MenuViewModel();
            ImageViewModel = new ImageViewModel(BitmapManager);
        }
    }
}
