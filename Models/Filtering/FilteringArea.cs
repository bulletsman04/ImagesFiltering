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
        PreBrush,
        Brush,
        Polygon,
        None
    }
    public class FilteringArea: ObservableObject
    {
        private PixelMap _pixelMap;
        private int _centerX;
        private int _centerY;
        public FilteringMode FilteringMode { get; set; }
        public int BrushDelimeter { get; set; }

        public int CenterX
        {
            get => _centerX;
            set
            {
                _centerX = value;
                RaisePropertyChanged("CenterX");
            }
            
        }

        public int CenterY
        {
            get => _centerY;
            set
            {
                _centerY = value;
                RaisePropertyChanged("CenterY");
            }
        }

        public float ScaleX { get; set; }
        public float ScaleY { get; set; }


        public Polygon Polygon { get; set; }

        public FilteringArea(PixelMap pixelMap)
        {
            _pixelMap = pixelMap;
            FilteringMode = FilteringMode.Bitmap;
            BrushDelimeter = 40;
            CenterX = 2000;
            CenterY = 2000;
            Polygon = null;
        }

        public IEnumerable<PixelPoint> GetPixelsToFilter()
        {
            switch (FilteringMode)
            {
                case FilteringMode.Bitmap:
                     return GetWholeBitmap();
                case FilteringMode.Brush:
                    return GetUnderBrush();
                case FilteringMode.None:
                    return null;
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

        private IEnumerable<PixelPoint> GetUnderBrush()
        {
            int startX = (int)(CenterX) - BrushDelimeter / 2;
            int startY = (int)(CenterY) - BrushDelimeter / 2;
            int endX = startX + BrushDelimeter;
            int endY = startY + BrushDelimeter;


            for (int i = startX; i < endX; i++)
            {
                for (int j = startY; j < endY; j++)
                {
                    if (Math.Sqrt(Math.Pow((CenterX - i), 2) + Math.Pow((CenterY - j), 2)) <= BrushDelimeter / 2)
                    {
                        yield return new PixelPoint(new Point(i, j), _pixelMap[i, j]);
                    }
                }
            }
        }
    }
}
