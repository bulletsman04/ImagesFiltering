using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Filtering;
using PixelMapSharp;

namespace Models.Filters
{
    public class FilteringStrategyBase
    {
        public void IterateAndApply(FilteringArguments filteringArguments,Func<Pixel, Pixel> calculate)
        {
            HistogramsManager histogramsManager = filteringArguments.HistogramsManager;
            foreach (var pixelPoint in filteringArguments.FilteringArea.GetPixelsToFilter())
            {
               
                Pixel pixelF = filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];
                Pixel pixelS = filteringArguments.BasicPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];

                Pixel prev = new Pixel(pixelF.R, pixelF.G, pixelF.B);

                pixelF = calculate(pixelS);
                histogramsManager.RecalculateTempFromPixel(prev, pixelF);
                filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y] = pixelF;

            }
            if (filteringArguments.FilteringArea.FilteringMode != FilteringMode.Brush)
                histogramsManager.RecalculateFromTemp();
        }
    }
}
