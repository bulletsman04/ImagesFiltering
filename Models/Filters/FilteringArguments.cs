using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Filtering;
using PixelMapSharp;

namespace Models.Filters
{
    public struct FilteringArguments
    {
        public PixelMap BasicPixelMap { get; set; }
        public PixelMap FilteredPixelMap { get; set; }
        public FilteringArea FilteringArea { get; set; }
        public HistogramsManager HistogramsManager { get; set; }

    }
}
