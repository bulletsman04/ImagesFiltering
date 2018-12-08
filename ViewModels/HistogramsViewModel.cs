using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ViewModels
{
    public class HistogramsViewModel
    {
        public HistogramsManager HistogramsManager { get; set; }

        public HistogramsViewModel(HistogramsManager histogramsManager)
        {
            HistogramsManager = histogramsManager;
        }
    }
}
