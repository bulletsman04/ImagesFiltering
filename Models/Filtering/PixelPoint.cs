using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixelMapSharp;

namespace Models.Filtering
{
    public struct PixelPoint
    {
        public Point Point { get; set; }
        public Pixel Pixel { get; set; }

        public PixelPoint(Point point, Pixel pixel)
        {
            Point = point;
            Pixel = pixel;
        }
    }
}
