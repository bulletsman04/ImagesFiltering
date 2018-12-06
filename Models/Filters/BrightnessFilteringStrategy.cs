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
        public void Execute(PixelMap pixelMap, FilteringArea filteringArea)
        {
            foreach (var pixelPoint in filteringArea.GetPixelsToFilter())
            {
                int brightenessAdded = 100;
                Pixel pixel = pixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];
                byte r = pixel.R;
                byte g = pixel.G;
                byte b = pixel.B;

                int rPre = r + brightenessAdded;
                int gPre = g + brightenessAdded;
                int bPre = b + brightenessAdded;


                pixel.R = TypesConverters.ConvertIntToByte(rPre);
                pixel.G = TypesConverters.ConvertIntToByte(gPre);
                pixel.B = TypesConverters.ConvertIntToByte(bPre);
                pixelMap[pixelPoint.Point.X, pixelPoint.Point.Y] = pixel;

            }
        }
    }
}
