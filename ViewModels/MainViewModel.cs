using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class MainViewModel
    {
        public MenuViewModel MenuViewModel { get; set; }
        public ImageViewModel ImageViewModel { get; set; }
        public MainViewModel()
        {
            MenuViewModel = new MenuViewModel();
            ImageViewModel = new ImageViewModel();
        }
    }
}
