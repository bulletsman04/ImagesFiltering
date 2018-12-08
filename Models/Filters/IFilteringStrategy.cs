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
    public interface IFilteringStrategy
    {
        void Execute(FilteringArguments filteringArguments);
    }
}
