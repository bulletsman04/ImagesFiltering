using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Properties;
using MvvmFoundation.Wpf;
using PixelMapSharp;


namespace Models
{
    public class BitmapManager: ObservableObject
    {
        private PixelMap _pixelMap;
        private Bitmap _startingBitmap;
        public PixelMap PixelMap
        {
            get => _pixelMap;
            set
            {
                _pixelMap = value;
                RaisePropertyChanged("PixelMap");
            }}
        public int Width { get; set; }
        public int Height { get; set; }


        public BitmapManager()
        {
            Width = 450;
            Height = 600;
            SetImage(Resources.landscape);
        }

        public void SetImage(Image image)
        {
            _startingBitmap = new System.Drawing.Bitmap(image, Width, Height);
            PixelMap = PixelMap.SlowLoad(_startingBitmap);
        }

        public void ResetPixelMap()
        {
            PixelMap = PixelMap.SlowLoad(_startingBitmap);
        }
       
    }
}
