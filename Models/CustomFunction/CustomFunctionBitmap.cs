using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmFoundation.Wpf;
using PixelMapSharp;

namespace Models.CustomFunction
{
    public class CustomFunctionBitmap: ObservableObject
    {
        private PixelMap _functionPixelMap;
        public PixelMap FunctionPixelMap
        {
            get => _functionPixelMap;
            set
            {
                _functionPixelMap = value;
                RaisePropertyChanged("FunctionPixelMap");
            } }

        private int _width;
        private int _height;

        private int _xOffset;
        private int _yOffset;
        private int _yDownOffset;
        private int _xLeftOffset;
        private int _step = 35;


        private CustomFunction _customFunction;

        private List<Point> _points;
        private List<Rectangle> _pointsRectangles;
        private Point? _clickedPoint;
        private int _clickedPointIndex;

        public CustomFunctionBitmap(CustomFunction customFunction)
        {
            _customFunction = customFunction;
            _width = _height = 290;
            _xOffset = _yOffset = 34;
            _yDownOffset = 25;
            _xLeftOffset = 24;
            FunctionPixelMap = new PixelMap(_width,_height);
            InitializePoints();
            RepaintBitmap();
        }

        public void RepaintBitmap()
        {
            // ToDo: Zmienić - albo tworzyć raz albo directBitmap
            Bitmap bitmap = new Bitmap(_width,_height);
            Pen pen = new Pen(Color.LightGray, 2);
            Pen penLine = new Pen(Color.Green, 2);


            Brush brush = new SolidBrush(Color.FromArgb(89, 89, 89));
            SolidBrush drawBrush = new SolidBrush(Color.Purple);
            SolidBrush drawBrushPoint1 = new SolidBrush(Color.Red);
            SolidBrush drawBrushPoint2 = new SolidBrush(Color.Blue);


            Font drawFont = new Font("Arial", 5);

            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                gr.Clear(Color.White);

                gr.DrawLine(pen,24,9,24,_height - _yOffset + 9);
                gr.DrawLine(pen,24, _height - _yOffset + 9, _width - _xOffset + 24, _height - _yOffset + 9);
                gr.DrawString("0",drawFont, drawBrush, 9, _height - _yOffset + 10);
                gr.DrawString("255", drawFont, drawBrush, 2, 9);
                gr.DrawString("255", drawFont, drawBrush, _width - _xOffset + 14, _height - _yOffset + 10);

                // Bresenham
                LineDrawer ld = new LineDrawer(bitmap, _customFunction.FunctionTable, BitmapPointToFunctionPoint);

                for (int j = 0; j < _points.Count - 1; j++)
                {
                    ld.MyDrawLine(penLine, _points[j], _points[j + 1]);
                }

                int i = 0;
                foreach (var p in _points)
                {
                    
                    gr.FillRectangle(i%2==0?drawBrushPoint1:drawBrushPoint2,_pointsRectangles[i]);
                    i++;
                }

               
            }

            

            FunctionPixelMap = new PixelMap(bitmap);

            brush.Dispose();
            pen.Dispose();
            penLine.Dispose();
            drawFont.Dispose();
            drawBrush.Dispose();
        }

        private void InitializePoints()
        {
            _points = new List<Point>();
            _pointsRectangles = new List<Rectangle>();
            for (int i = 0; i < 256; i += _step)
            {
                Point p = FunctionPointToBitmapPoint(i, _customFunction.FunctionTable[i]);
                _points.Add(p);
                _pointsRectangles.Add(new Rectangle(p.X - 4, p.Y - 4, 8, 8));

            }
           
        }


        public void HandleMouseDown(System.Windows.Point point, double width, double height)
        {
            double scaleX = _width / width;
            double scaleY = _height / height;


            int x = (int)(point.X * scaleX);
            int y = (int)(point.Y * scaleY);

            int i = 0;
            foreach (var rectangle in _pointsRectangles)
            {
                if (rectangle.Contains((int)x, (int)y))
                {
                    _clickedPoint = _points[i];
                    _clickedPointIndex = i;
                    break;
                }

                i++;
            }
        }

        public void HandleMouseMove(System.Windows.Point point, double width, double height)
        {
            double scaleX = _width / width;
            double scaleY = _height / height;


            int x = (int)(point.X*scaleX);
            int y = (int)(point.Y*scaleY);

            if (_clickedPoint == null)
            {
                return;
            }

            if ( _clickedPointIndex== 0 || _clickedPointIndex == _points.Count - 1)
            {
                return;
            }

            bool yUp = y >= _yOffset - _yDownOffset;
            bool yDown = y <= _height - _yDownOffset;
            bool leftPoint = x > _points[_clickedPointIndex - 1].X;
            bool rightPoint = x < _points[_clickedPointIndex + 1].X;

            if (!yUp || !yDown || !leftPoint || !rightPoint)
            {
                return;
            }

            _points[_clickedPointIndex] = new Point(x,y);
            _pointsRectangles[_clickedPointIndex] = new Rectangle(x - 4, y - 4, 8, 8);

            RepaintBitmap();
        }

        public void HandleMouseUp()
        {
            _clickedPoint = null;
            _clickedPointIndex = -1;
        }

        private (int,int) BitmapPointToFunctionPoint(int x, int y)
        {
            return (x - _xLeftOffset, _height - y -  _yDownOffset);
        }

        private Point FunctionPointToBitmapPoint(int x, int y)
        {
            return new Point(x + _xLeftOffset, _height - _yDownOffset - y );
        }
    }
}
