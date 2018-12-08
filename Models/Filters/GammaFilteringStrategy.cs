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
                Pixel pixel = filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];
                pixel.R = (byte)(255* Math.Pow(pixel.R/255f,gamma));
                pixel.G = (byte)(255 * Math.Pow(pixel.G / 255f, gamma));
                pixel.B = (byte)(255 * Math.Pow(pixel.B / 255f, gamma));

                filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y] = pixel;

            }
        }
    }
}
