using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Filtering;
using PixelMapSharp;

namespace Models.Filters
{
    public class GammaFilteringStrategy:FilteringStrategyBase, IFilteringStrategy
    {
        public void Execute(FilteringArguments filteringArguments)
        {
            Func<Pixel, Pixel> calculate = (pixelS) =>
            {
                Pixel pixelF = new Pixel();

                float gamma = 1 / 2.2f;

                pixelF.R = (byte)(255 * Math.Pow(pixelS.R / 255f, gamma));
                pixelF.G = (byte)(255 * Math.Pow(pixelS.G / 255f, gamma));
                pixelF.B = (byte)(255 * Math.Pow(pixelS.B / 255f, gamma));

                return pixelF;
            };

            IterateAndApply(filteringArguments, calculate);

           
        }
    }
}
