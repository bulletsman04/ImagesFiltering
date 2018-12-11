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
        private HistogramsManager _histogramsManager;

        public PixelMap PixelMap
        {
            get => _pixelMap;
            set
            {
                _pixelMap = value;
                RaisePropertyChanged("PixelMap");
            }
        }

        public PixelMap StartingPixelMap { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }


        public BitmapManager(HistogramsManager histogramsManager)
        {
            _histogramsManager = histogramsManager;
            SetImage(Resources.landscape);
        }

        public void SetImage(Image image)
        {
            Bitmap  bitmap = new System.Drawing.Bitmap(image);
            Width = image.Width;
            Height = image.Height;
            PixelMap = PixelMap.SlowLoad(bitmap);
            StartingPixelMap = new PixelMap(PixelMap);

            _histogramsManager.RecalculateFromBitmap(PixelMap);
        }
    }
}
