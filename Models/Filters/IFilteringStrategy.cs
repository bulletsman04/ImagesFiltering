using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Filters
{
    public interface IFilteringStrategy
    {
        Color Execute(Color pixelColor);
    }
}
