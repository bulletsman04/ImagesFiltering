using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Models;
using Models.CustomFunction;
using MvvmFoundation.Wpf;

namespace ViewModels
{
    public class FunctionViewModel: ObservableObject
    {
        public CustomFunctionBitmap CustomFunctionBitmap { get; set; }
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

        public PropertyObserver<CustomFunctionBitmap> FunctionBitmapObserver { get; set; }

        public FunctionViewModel(CustomFunctionBitmap customFunctionBitmap)
        {
            CustomFunctionBitmap = customFunctionBitmap;
            RegisterPropertiesChanged();
            BitmapChangedHandler(CustomFunctionBitmap);
        }

        public void RegisterPropertiesChanged()
        {
            FunctionBitmapObserver = new PropertyObserver<CustomFunctionBitmap>(CustomFunctionBitmap)
                .RegisterHandler(n => n.FunctionPixelMap, BitmapChangedHandler);
        }

        private void BitmapChangedHandler(CustomFunctionBitmap customFunctionBitmap)
        {
            ImageSource = TypesConverters.BitmapToImageSource(customFunctionBitmap.FunctionPixelMap.GetBitmap());
        }


        public void HandleMouseDown(System.Windows.Point point, double width, double height)
        {
            CustomFunctionBitmap.HandleMouseDown(point,width,height);
        }

        public void HandleMouseMove(System.Windows.Point point, double width, double height)
        {
            CustomFunctionBitmap.HandleMouseMove(point, width, height);
        }

        public void HandleMouseUp()
        {
            CustomFunctionBitmap.HandleMouseUp();
        }
    }
}
