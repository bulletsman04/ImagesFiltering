using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Filtering;
using PixelMapSharp;

namespace Models.Filters
{
    public class BrightnessFilteringStrategy:IFilteringStrategy
    {
        public void Execute(FilteringArguments filteringArguments)
        {
            foreach (var pixelPoint in filteringArguments.FilteringArea.GetPixelsToFilter())
            {
                int brightenessAdded = 100;
                Pixel pixelF = filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];
                Pixel pixelS = filteringArguments.BasicPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];

                HistogramsManager histogramsManager = filteringArguments.HistogramsManager;
                Pixel prev = new Pixel(pixelF.R, pixelF.G, pixelF.B);
                byte r = pixelS.R;
                byte g = pixelS.G;
                byte b = pixelS.B;

                int rPre = r + brightenessAdded;
                int gPre = g + brightenessAdded;
                int bPre = b + brightenessAdded;


                pixelF.R = TypesConverters.ConvertIntToByte(rPre);
                pixelF.G = TypesConverters.ConvertIntToByte(gPre);
                pixelF.B = TypesConverters.ConvertIntToByte(bPre);

                histogramsManager.RecalculateFromPixel(prev, pixelF);

                filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y] = pixelF;

            }
        }
    }
}
