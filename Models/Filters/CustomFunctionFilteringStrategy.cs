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
            HistogramsManager histogramsManager = filteringArguments.HistogramsManager;
            foreach (var pixelPoint in filteringArguments.FilteringArea.GetPixelsToFilter())
            {
                Pixel pixelF = filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];
                Pixel pixelS = filteringArguments.BasicPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y];

                Pixel prev = new Pixel(pixelF.R, pixelF.G, pixelF.B);

                pixelF.R = (byte)_customFunction.FunctionTable[pixelS.R];
                pixelF.G = (byte)_customFunction.FunctionTable[pixelS.G];
                pixelF.B = (byte)_customFunction.FunctionTable[pixelS.B];
                histogramsManager.RecalculateTempFromPixel(prev, pixelF);
                filteringArguments.FilteredPixelMap[pixelPoint.Point.X, pixelPoint.Point.Y] = pixelF;

            }
            if (filteringArguments.FilteringArea.FilteringMode != FilteringMode.Brush)
                histogramsManager.RecalculateFromTemp();
        }

        public CustomFunctionFilteringStrategy(CustomFunction.CustomFunction custom)
        {
            _customFunction = custom;
        }
    }
}
