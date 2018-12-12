using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Filtering;
using PixelMapSharp;

namespace Models.Filters
{
    public class BrightnessFilteringStrategy: FilteringStrategyBase, IFilteringStrategy
    {
        public void Execute(FilteringArguments filteringArguments)
        {
            Func<Pixel, Pixel> calculate = (pixelS) =>
            {
                Pixel pixelF = new Pixel();

                int brightenessAdded = 100;
                byte r = pixelS.R;
                byte g = pixelS.G;
                byte b = pixelS.B;

                int rPre = r + brightenessAdded;
                int gPre = g + brightenessAdded;
                int bPre = b + brightenessAdded;


                pixelF.R = TypesConverters.ConvertIntToByte(rPre);
                pixelF.G = TypesConverters.ConvertIntToByte(gPre);
                pixelF.B = TypesConverters.ConvertIntToByte(bPre);

                return pixelF;
            };

            base.IterateAndApply(filteringArguments, calculate);

            
        }
    }
}
