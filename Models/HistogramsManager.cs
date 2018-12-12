using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using MvvmFoundation.Wpf;
using PixelMapSharp;

namespace Models
{
    public class HistogramsManager
    {
        public Histogram RHistogram { get; set; }
        public Histogram GHistogram { get; set; }
        public Histogram BHistogram { get; set; }
        private int[] _rTemp;
        private int[] _gTemp;
        private int[] _bTemp;


        public HistogramsManager()
        {
            RHistogram = new Histogram(new SolidColorBrush(Color.FromRgb(255, 0, 0)));
            GHistogram = new Histogram(new SolidColorBrush(Color.FromRgb(0, 255, 0)));
            BHistogram = new Histogram(new SolidColorBrush(Color.FromRgb(0, 0, 255)));
            _rTemp = new int[256];
            _gTemp = new int[256];
            _bTemp = new int[256];


        }

        public void RecalculateFromBitmap(PixelMap pixelMap)
        {
            RHistogram.ResetValues();
            GHistogram.ResetValues();
            BHistogram.ResetValues();
            for (int i = 0; i < pixelMap.Width; i++)
            {
                for (int j = 0; j < pixelMap.Height; j++)
                {
                    Pixel pixel = pixelMap[i, j];
                    RHistogram.ObservableValues[pixel.R].Value++;
                    GHistogram.ObservableValues[pixel.G].Value++;
                    BHistogram.ObservableValues[pixel.B].Value++;

                }

               
            }
            RecalculateYLabels();
        }

        public void RecalculateTempFromPixel(Pixel prev, Pixel next)
        {
            _rTemp[prev.R]--;
            _gTemp[prev.G]--;
            _bTemp[prev.B]--;

            _rTemp[next.R]++;
            _gTemp[next.G]++;
            _bTemp[next.B]++;

        }

        public void RecalculateFromTemp()
        {
            for (int i = 0; i < 256; i++)
            {

                RHistogram.ObservableValues[i].Value += _rTemp[i];
                GHistogram.ObservableValues[i].Value += _gTemp[i];
                BHistogram.ObservableValues[i].Value += _bTemp[i];

                _rTemp[i] = 0;
                _gTemp[i] = 0;
                _bTemp[i] = 0;

            }


            RecalculateYLabels();
        }

        public void RecalculateYLabels()
        {
            foreach (var histogram in new []{RHistogram,GHistogram,BHistogram})
            {
                int maxvalue = 0;

                foreach (ObservableValue val in histogram.SeriesCollection[0].Values)
                {
                    if (val.Value > maxvalue)
                    {
                        maxvalue = (int)val.Value;
                    }
                }

                histogram.SeparatorY = new Separator()
                {
                    Step = (int)(maxvalue / 3)
                };
            }
        }
    }
}

