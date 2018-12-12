using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Filtering;
using PixelMapSharp;

namespace Models.Filters
{
    public class ContrastFilteringStrategy: FilteringStrategyBase, IFilteringStrategy
    {
        public void Execute(FilteringArguments filteringArguments)
        {

            Func<Pixel, Pixel> calculate = (pixelS) =>
            {
                Pixel pixelF = new Pixel();

                int contrast = 2;
                byte r = pixelS.R;
                byte g = pixelS.G;
                byte b = pixelS.B;

                int rPre = (r - 128) * contrast + 128;
                int gPre = (g - 128) * contrast + 128;
                int bPre = (b - 128) * contrast + 128;

                pixelF.R = TypesConverters.ConvertIntToByte(rPre);
                pixelF.G = TypesConverters.ConvertIntToByte(gPre);
                pixelF.B = TypesConverters.ConvertIntToByte(bPre);

                return pixelF;
            };

            base.IterateAndApply(filteringArguments,calculate );


        }

     
    }
}
