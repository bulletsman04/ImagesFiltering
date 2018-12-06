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
        public void Execute(PixelMap pixelMap, FilteringArea filteringArea)
        {
            foreach (var pixelPoint in filteringArea.GetPixelsToFilter())
            {
                Pixel pixel = pixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];
                pixel.R = (byte)(255 - pixel.R);
                pixel.G = (byte)(255 - pixel.G);
                pixel.B = (byte)(255 - pixel.B);
                pixelMap[pixelPoint.Point.X, pixelPoint.Point.Y] = pixel;

            }
        }
    }
}
