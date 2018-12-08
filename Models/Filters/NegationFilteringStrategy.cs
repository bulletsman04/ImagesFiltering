using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Filtering;
using PixelMapSharp;

namespace Models.Filters
{
    public class NegationFilteringStrategy: IFilteringStrategy
    {
        public void Execute(FilteringArguments filteringArguments)
        {
            foreach (var pixelPoint in filteringArguments.FilteringArea.GetPixelsToFilter())
            {
                Pixel pixelF = filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];
                Pixel pixelS = filteringArguments.BasicPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];

                HistogramsManager histogramsManager = filteringArguments.HistogramsManager;
                Pixel prev = new Pixel(pixelF.R,pixelF.G,pixelF.B);
                
                pixelF.R = (byte)(255 - pixelS.R);
                pixelF.G = (byte)(255 - pixelS.G);
                pixelF.B = (byte)(255 - pixelS.B);

                histogramsManager.RecalculateFromPixel(prev,pixelF);
                

                filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y] = pixelF;

            }
        }
    }
}
