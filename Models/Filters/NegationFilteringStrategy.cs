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
    public class NegationFilteringStrategy:FilteringStrategyBase, IFilteringStrategy
    {
        public void Execute(FilteringArguments filteringArguments)
        {
            Func<Pixel, Pixel> calculate = (pixelS) =>
            {
                Pixel pixelF = new Pixel();

                pixelF.R = (byte)(255 - pixelS.R);
                pixelF.G = (byte)(255 - pixelS.G);
                pixelF.B = (byte)(255 - pixelS.B);

                return pixelF;
            };

            base.IterateAndApply(filteringArguments, calculate);
        }
    }
}
