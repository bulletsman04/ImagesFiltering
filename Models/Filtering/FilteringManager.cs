using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Filtering;
using Models.Filters;

namespace Models
{
   
    public class FilteringManager
    {
        private BitmapManager _bitmapManager;
        private IFilteringStrategy _filteringStrategy;

        public IFilteringStrategy FilteringStrategy
        {
            get => _filteringStrategy;
            set
            {
                _filteringStrategy = value;
            }
        }

        public FilteringArea FilteringArea { get; set; }

        public FilteringManager(BitmapManager bitmapManager)
        {
            _bitmapManager = bitmapManager;
            FilteringStrategy = null;
            FilteringArea = new FilteringArea(bitmapManager.PixelMap);
        }

        public void Filter()
        {
            _bitmapManager.ResetPixelMap();
            FilteringStrategy?.Execute(_bitmapManager.PixelMap, FilteringArea);
            _bitmapManager.PixelMap = _bitmapManager.PixelMap;
        }
    }
}
