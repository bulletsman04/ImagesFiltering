using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Models;
using Models.Filtering;
using MvvmFoundation.Wpf;

namespace ViewModels
{

    public class ImageViewModel: ObservableObject
    {
        private ImageSource _imageSource;
        public ImageSource ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                RaisePropertyChanged("ImageSource");
            }
        }

        private BitmapManager _bitmapManager;
        public FilteringManager FilteringManager { get; set; }
        public PropertyObserver<BitmapManager> BitmapObserver { get; set; }

        public ImageViewModel(BitmapManager bitmapManager, FilteringManager filteringManager)
        {
            _bitmapManager = bitmapManager;
            FilteringManager = filteringManager;
            BitmapChangedHandler(_bitmapManager);
            RegisterPropertiesChanged();
        }

        public void RegisterPropertiesChanged()
        {
            BitmapObserver = new PropertyObserver<BitmapManager>(_bitmapManager)
                .RegisterHandler(n => n.PixelMap, BitmapChangedHandler);
        }

        private void BitmapChangedHandler(BitmapManager bitmapManager)
        {
            ImageSource = TypesConverters.BitmapToImageSource(bitmapManager.PixelMap.GetBitmap());
        }


        public void HandleMouseDown()
        {
            FilteringArea filteringArea = FilteringManager.FilteringArea;
            filteringArea.FilteringMode = FilteringMode.Brush;
            
        }

        public void HandleMouseMove(System.Windows.Point point, double width, double height)
        {
            FilteringArea filteringArea = FilteringManager.FilteringArea;
            float scale  = (float)(_bitmapManager.PixelMap.Width/ width);

            filteringArea.CenterX = (int)(point.X*scale );
            filteringArea.CenterY = (int)(point.Y*scale );
            filteringArea.BrushDelimeter = (int)(40 * scale);

            if(filteringArea.FilteringMode == FilteringMode.Brush)
                FilteringManager.Filter();

           
        }

        public void HandleMouseUp()
        {
            FilteringArea filteringArea = FilteringManager.FilteringArea;
            filteringArea.FilteringMode = FilteringMode.PreBrush;
            FilteringManager.HistogramsManager.RecalculateFromTemp();
        }

        public bool IsPreOrBrushMode()
        {
            return FilteringManager.FilteringArea.FilteringMode == FilteringMode.PreBrush || FilteringManager.FilteringArea.FilteringMode == FilteringMode.Brush;
        }
    }
}
