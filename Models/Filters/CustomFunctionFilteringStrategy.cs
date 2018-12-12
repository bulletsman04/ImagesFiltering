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
        private CustomFunction.CustomFunctionManager _customFunctionManager;
        public void Execute(FilteringArguments filteringArguments)
        {
            Func<Pixel, Pixel> calculate = (pixelS) =>
            {
                Pixel pixelF = new Pixel();

                pixelF.R = (byte)_customFunctionManager.RChart.Function.FunctionTable[pixelS.R];
                pixelF.G = (byte)_customFunctionManager.GChart.Function.FunctionTable[pixelS.G];
                pixelF.B = (byte)_customFunctionManager.BChart.Function.FunctionTable[pixelS.B];

                return pixelF;
            };

            base.IterateAndApply(filteringArguments, calculate);
            
        }

        public CustomFunctionFilteringStrategy(CustomFunction.CustomFunctionManager customManager)
        {
            _customFunctionManager = customManager;
        }
    }
}
