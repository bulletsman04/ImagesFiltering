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
        public void Execute(PixelMap pixelMap, FilteringArea filteringArea)
        {
            throw new NotImplementedException();
        }

        public CustomFunctionFilteringStrategy()
        {
            // Wstrzyknięcie customowej funkcji
        }
    }
}
