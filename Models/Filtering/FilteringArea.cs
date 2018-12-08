using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmFoundation.Wpf;
using PixelMapSharp;

namespace Models.Filtering
{
    public enum FilteringMode
    {
        Bitmap,
        Brush,
        Polygon
    }
    public class FilteringArea: ObservableObject
    {
        private PixelMap _pixelMap;
        public FilteringMode FilteringMode { get; set; }
        public int? BrushRadius { get; set; }
        public Point? BrushCenter { get; set; }
        public Polygon Polygon { get; set; }

        public FilteringArea(PixelMap pixelMap)
        {
            _pixelMap = pixelMap;
            FilteringMode = FilteringMode.Bitmap;
            BrushRadius = null;
            BrushCenter = null;
            Polygon = null;
        }

        public IEnumerable<PixelPoint> GetPixelsToFilter()
        {
            switch (FilteringMode)
            {
                case FilteringMode.Bitmap:
                     return GetWholeBitmap();
                default:
                    return null;
            }

        }

        private IEnumerable<PixelPoint> GetWholeBitmap()
        {
            for (int i = 0; i < _pixelMap.Width; i++)
            {
                for (int j = 0; j < _pixelMap.Height; j++)
                {
                    yield return new PixelPoint(new Point(i,j),_pixelMap[i, j]);
                }
            }
        }
    }
}
