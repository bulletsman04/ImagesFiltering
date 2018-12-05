using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Models;
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
        public PropertyObserver<BitmapManager> BitmapObserver { get; set; }

        public ImageViewModel(BitmapManager bitmapManager)
        {
            _bitmapManager = bitmapManager;
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
            ImageSource = LibrariesConverters.BitmapToImageSource(bitmapManager.PixelMap.GetBitmap());
        }
    }
}
