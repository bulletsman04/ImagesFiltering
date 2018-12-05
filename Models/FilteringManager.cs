using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Filters;

namespace Models
{
    public enum FilteringMode
    {
        Bitmap,
        Brush,
        Polygon
    }
    public class FilteringManager
    {
        private BitmapManager _bitmapManager;

        public IFilteringStrategy FilteringStrategy { get; set; }
        public FilteringMode FilteringMode { get; set; }
    }
}
