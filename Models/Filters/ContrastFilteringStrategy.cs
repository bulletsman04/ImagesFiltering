using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Filtering;
using PixelMapSharp;

namespace Models.Filters
{
    public class ContrastFilteringStrategy: IFilteringStrategy
    {
        public void Execute(FilteringArguments filteringArguments)
        {
            foreach (var pixelPoint in filteringArguments.FilteringArea.GetPixelsToFilter())
            {
                int contrast = 4;
                Pixel pixel = filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];
                byte r = pixel.R;
                byte g = pixel.G;
                byte b = pixel.B;

                int rPre = (r - 128) * contrast + 128;
                int gPre = (g - 128) * contrast + 128;
                int bPre = (b - 128) * contrast + 128;

                
                pixel.R = TypesConverters.ConvertIntToByte(rPre);
                pixel.G = TypesConverters.ConvertIntToByte(gPre);
                pixel.B = TypesConverters.ConvertIntToByte(bPre);
                filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y] = pixel;

            }
        }

     
    }
}
