using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Filtering;
using PixelMapSharp;

namespace Models.Filters
{
    public class CustomFunctionFilteringStrategy: IFilteringStrategy
    {
        private CustomFunction.CustomFunction _customFunction;
        public void Execute(FilteringArguments filteringArguments)
        {
            foreach (var pixelPoint in filteringArguments.FilteringArea.GetPixelsToFilter())
            {
                Pixel pixelF = filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];
                Pixel pixelS = filteringArguments.BasicPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];

                HistogramsManager histogramsManager = filteringArguments.HistogramsManager;
                Pixel prev = new Pixel(pixelF.R, pixelF.G, pixelF.B);

                pixelF.R = (byte)_customFunction.FunctionTable[pixelS.R];
                pixelF.G = (byte)_customFunction.FunctionTable[pixelS.G];
                pixelF.B = (byte)_customFunction.FunctionTable[pixelS.B];

                histogramsManager.RecalculateFromPixel(prev, pixelF);


                filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y] = pixelF;

            }
        }

        public CustomFunctionFilteringStrategy(CustomFunction.CustomFunction custom)
        {
            _customFunction = custom;
        }
    }
}
