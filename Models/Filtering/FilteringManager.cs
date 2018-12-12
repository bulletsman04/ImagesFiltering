using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Filtering;
using Models.Filters;
using PixelMapSharp;

namespace Models
{
   
    public class FilteringManager
    {
        private BitmapManager _bitmapManager;
        private FilteringArguments _filteringArguments;
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
        public HistogramsManager HistogramsManager { get; set; }

        public FilteringManager(BitmapManager bitmapManager, HistogramsManager histogramsManager, FilteringArea filteringArea)
        {
            _bitmapManager = bitmapManager;
            HistogramsManager = histogramsManager;
            FilteringArea = filteringArea;

            FilteringStrategy = null;
            _filteringArguments = new FilteringArguments()
            {
                FilteredPixelMap = _bitmapManager.PixelMap,
                BasicPixelMap =  _bitmapManager.StartingPixelMap,
                FilteringArea =  FilteringArea,
                HistogramsManager = HistogramsManager

            };
        }

        public void Filter()
        { 
            _filteringArguments.FilteredPixelMap = _bitmapManager.PixelMap;
            _filteringArguments.BasicPixelMap = _bitmapManager.StartingPixelMap;

            if (FilteringStrategy != null)
            {
                FilteringStrategy.Execute(_filteringArguments);
            }
            else
            {
                ResetFiltering();
            }

        _bitmapManager.PixelMap = _bitmapManager.PixelMap;
            HistogramsManager.RecalculateYLabels();
        }

        private void ResetFiltering()
        {
            _bitmapManager.PixelMap = new PixelMap(_bitmapManager.StartingPixelMap);
            HistogramsManager.RecalculateFromBitmap(_bitmapManager.PixelMap);
        }
    }
}
