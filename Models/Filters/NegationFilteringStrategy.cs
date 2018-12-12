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
            HistogramsManager histogramsManager = filteringArguments.HistogramsManager;
            foreach (var pixelPoint in filteringArguments.FilteringArea.GetPixelsToFilter())
            {
                Pixel pixelF = filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];
                Pixel pixelS = filteringArguments.BasicPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];

               
                Pixel prev = new Pixel(pixelF.R,pixelF.G,pixelF.B);
                
                pixelF.R = (byte)(255 - pixelS.R);
                pixelF.G = (byte)(255 - pixelS.G);
                pixelF.B = (byte)(255 - pixelS.B);

                histogramsManager.RecalculateTempFromPixel(prev,pixelF);
                

                filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y] = pixelF;

            }
            if (filteringArguments.FilteringArea.FilteringMode != FilteringMode.Brush)
                histogramsManager.RecalculateFromTemp();

        }
    }
}
