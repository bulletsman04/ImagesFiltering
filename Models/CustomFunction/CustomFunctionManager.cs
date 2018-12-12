using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmFoundation.Wpf;

namespace Models.CustomFunction
{
    public class CustomFunctionManager:ObservableObject
    {
        private bool _allSame;
        public CustomFunctionBitmap RChart { get; set; }
        public CustomFunctionBitmap GChart { get; set; }
        public CustomFunctionBitmap BChart { get; set; }

        public bool AllSame
        {
            get => _allSame;
            set
            {
                _allSame = value;
                RaisePropertyChanged("AllSame");
                MakeAllSame();
            }
        }

        public CustomFunctionManager()
        {
            RChart = new CustomFunctionBitmap(new CustomFunction());
            GChart = new CustomFunctionBitmap(new CustomFunction());
            BChart = new CustomFunctionBitmap(new CustomFunction());

        }

        private void MakeAllSame()
        {
            GChart.SetPoints(RChart.Points);
            BChart.SetPoints(RChart.Points);

        }
    }
}
