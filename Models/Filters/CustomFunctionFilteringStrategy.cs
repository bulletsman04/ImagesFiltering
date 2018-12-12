using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Filtering;
using PixelMapSharp;

namespace Models.Filters
{
    public class CustomFunctionFilteringStrategy:FilteringStrategyBase, IFilteringStrategy
    {
        private CustomFunction.CustomFunction _customFunction;
        public void Execute(FilteringArguments filteringArguments)
        {
            Func<Pixel, Pixel> calculate = (pixelS) =>
            {
                Pixel pixelF = new Pixel();

                pixelF.R = (byte)_customFunction.FunctionTable[pixelS.R];
                pixelF.G = (byte)_customFunction.FunctionTable[pixelS.G];
                pixelF.B = (byte)_customFunction.FunctionTable[pixelS.B];

                return pixelF;
            };

            base.IterateAndApply(filteringArguments, calculate);
            
        }

        public CustomFunctionFilteringStrategy(CustomFunction.CustomFunction custom)
        {
            _customFunction = custom;
        }
    }
}
