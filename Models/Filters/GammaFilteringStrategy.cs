using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Filtering;
using PixelMapSharp;

namespace Models.Filters
{
    public class GammaFilteringStrategy:IFilteringStrategy
    {
        public void Execute(FilteringArguments filteringArguments)
        {
            foreach (var pixelPoint in filteringArguments.FilteringArea.GetPixelsToFilter())
            {
                float gamma = 1/2.2f;
                Pixel pixelF = filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];
                Pixel pixelS = filteringArguments.BasicPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];

                HistogramsManager histogramsManager = filteringArguments.HistogramsManager;
                Pixel prev = new Pixel(pixelF.R, pixelF.G, pixelF.B);

                pixelF.R = (byte)(255* Math.Pow(pixelS.R/255f,gamma));
                pixelF.G = (byte)(255 * Math.Pow(pixelS.G / 255f, gamma));
                pixelF.B = (byte)(255 * Math.Pow(pixelS.B / 255f, gamma));

                histogramsManager.RecalculateFromPixel(prev, pixelF);

                filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y] = pixelF;

            }
        }
    }
}
