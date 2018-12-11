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
                int contrast = 2;
                Pixel pixelF = filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];
                Pixel pixelS = filteringArguments.BasicPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];

                HistogramsManager histogramsManager = filteringArguments.HistogramsManager;
                Pixel prev = new Pixel(pixelF.R, pixelF.G, pixelF.B);

                byte r = pixelS.R;
                byte g = pixelS.G;
                byte b = pixelS.B;

                int rPre = (r - 128) * contrast + 128;
                int gPre = (g - 128) * contrast + 128;
                int bPre = (b - 128) * contrast + 128;

                
                pixelF.R = TypesConverters.ConvertIntToByte(rPre);
                pixelF.G = TypesConverters.ConvertIntToByte(gPre);
                pixelF.B = TypesConverters.ConvertIntToByte(bPre);

                histogramsManager.RecalculateFromPixel(prev, pixelF);

                filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y] = pixelF;

            }
        }

     
    }
}
