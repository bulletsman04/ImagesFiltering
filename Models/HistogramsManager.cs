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

        public HistogramsManager()
        {
            RHistogram = new Histogram(new SolidColorBrush(Color.FromRgb(255, 0, 0)));
            GHistogram = new Histogram(new SolidColorBrush(Color.FromRgb(0, 255, 0)));
            BHistogram = new Histogram(new SolidColorBrush(Color.FromRgb(0, 0, 255)));

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

        public void RecalculateFromPixel(Pixel prev, Pixel next)
        {
            RHistogram.ObservableValues[prev.R].Value--;
            GHistogram.ObservableValues[prev.G].Value--;
            BHistogram.ObservableValues[prev.B].Value--;

            RHistogram.ObservableValues[next.R].Value++;
            GHistogram.ObservableValues[next.G].Value++;
            BHistogram.ObservableValues[next.B].Value++;
            
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

