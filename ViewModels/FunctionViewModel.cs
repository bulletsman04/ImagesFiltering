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
        public CustomFunctionManager CustomFunctionManager { get; set; }
        private ImageSource _imageSourceR;
        private ImageSource _imageSourceG;
        private ImageSource _imageSourceB;

        public ImageSource ImageSourceR
        {
            get { return _imageSourceR; }
            set
            {
                _imageSourceR = value;
                RaisePropertyChanged("ImageSourceR");
            }
        }
        public ImageSource ImageSourceG
        {
            get { return _imageSourceG; }
            set
            {
                _imageSourceG = value;
                RaisePropertyChanged("ImageSourceG");
            }
        }
        public ImageSource ImageSourceB
        {
            get { return _imageSourceB; }
            set
            {
                _imageSourceB = value;
                RaisePropertyChanged("ImageSourceB");
            }
        }

        public PropertyObserver<CustomFunctionBitmap> BitmapRObserver { get; set; }
        public PropertyObserver<CustomFunctionBitmap> BitmapGObserver { get; set; }
        public PropertyObserver<CustomFunctionBitmap> BitmapBObserver { get; set; }


        public FunctionViewModel(CustomFunctionManager customFunctionManager)
        {
            CustomFunctionManager = customFunctionManager;
            RegisterPropertiesChanged();
            BitmapChangedHandlerR(CustomFunctionManager.RChart);

            BitmapChangedHandlerG(CustomFunctionManager.GChart);

            BitmapChangedHandlerB(CustomFunctionManager.BChart);
        }

        public void RegisterPropertiesChanged()
        {
            BitmapRObserver = new PropertyObserver<CustomFunctionBitmap>(CustomFunctionManager.RChart)
                .RegisterHandler(n => n.FunctionPixelMap, BitmapChangedHandlerR);
            BitmapGObserver = new PropertyObserver<CustomFunctionBitmap>(CustomFunctionManager.GChart)
                .RegisterHandler(n => n.FunctionPixelMap, BitmapChangedHandlerG);
            BitmapBObserver = new PropertyObserver<CustomFunctionBitmap>(CustomFunctionManager.BChart)
                .RegisterHandler(n => n.FunctionPixelMap, BitmapChangedHandlerB);
        }

        private void BitmapChangedHandlerR(CustomFunctionBitmap CustomFunctionBitmap)
        {
            ImageSourceR = TypesConverters.BitmapToImageSource(CustomFunctionBitmap.FunctionPixelMap.GetBitmap());
        }
        private void BitmapChangedHandlerG(CustomFunctionBitmap CustomFunctionBitmap)
        {
            ImageSourceG = TypesConverters.BitmapToImageSource(CustomFunctionBitmap.FunctionPixelMap.GetBitmap());
        }
        private void BitmapChangedHandlerB(CustomFunctionBitmap CustomFunctionBitmap)
        {
            ImageSourceB = TypesConverters.BitmapToImageSource(CustomFunctionBitmap.FunctionPixelMap.GetBitmap());
        }


        public void HandleMouseDown(System.Windows.Point point, double width, double height, string chartName)
        {
            CustomFunctionBitmap bitmapManager = GetBitmapManager(chartName);
            bitmapManager.HandleMouseDown(point,width,height);
        }

        public void HandleMouseMove(System.Windows.Point point, double width, double height, string chartName)
        {
            CustomFunctionBitmap bitmapManager = GetBitmapManager(chartName);
            bitmapManager.HandleMouseMove(point, width, height);
        }

        public void HandleMouseUp(string chartName)
        {
            CustomFunctionBitmap bitmapManager = GetBitmapManager(chartName);
            bitmapManager.HandleMouseUp();
        }

        private CustomFunctionBitmap GetBitmapManager(string chartName)
        {
            switch (chartName)
            {
                case "CustomFunctionR":
                    return CustomFunctionManager.RChart;
                case "CustomFunctionG":
                    return CustomFunctionManager.GChart;
                case "CustomFunctionB":
                    return CustomFunctionManager.BChart;
                default:
                    return null;
            }
        }
    }
}
