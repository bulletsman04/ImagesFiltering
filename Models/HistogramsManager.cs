using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            RHistogram = new Histogram();
            GHistogram = new Histogram();
            BHistogram = new Histogram();

        }

        public void RecalculateFromBitmap(PixelMap pixelMap)
        {
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
    }
}

