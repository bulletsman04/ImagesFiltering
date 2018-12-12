using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Models;
using MvvmFoundation.Wpf;

namespace ViewModels
{
    public class MenuViewModel
    {
        private BitmapManager _bitmapManager;
        public MenuViewModel(BitmapManager bitmapManager)
        {
            _bitmapManager = bitmapManager;
        }

        RelayCommand _closeCommand;
        RelayCommand _minimizeCommand;
        RelayCommand _documentationCommand;

        public bool shouldInvoke { get; set; } = true;


        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(this.Close,
                        null);
                }
                return _closeCommand;
            }
        }

        public void Close()
        {
            Application.Current.MainWindow.Close();
        }
        public ICommand MinimizeCommand
        {
            get
            {
                if (_minimizeCommand == null)
                {
                    _minimizeCommand = new RelayCommand(() => Application.Current.MainWindow.WindowState = WindowState.Minimized,
                        null);
                }
                return _minimizeCommand;
            }
        }

        public ICommand DocumentationCommand
        {
            get
            {
                if (_documentationCommand == null)
                {
                    _documentationCommand = new RelayCommand(() =>
                        {
                            try
                            {
                                if (shouldInvoke)
                                    Process.Start(@"..\..\..\Dokumentacja.txt");
                            }
                            catch (Exception e)
                            {

                            }
                        },
                        null);
                }
                return _documentationCommand;
            }
        }

        RelayCommand<string> _setTextureCommand;
        public ICommand SetTextureCommand
        {
            get
            {
                if (_setTextureCommand == null)
                {
                    _setTextureCommand = new RelayCommand<string>(this.SetTexture,
                        null);
                }
                return _setTextureCommand;
            }
        }

        public void SetTexture(string index)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*"; ;

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                Image image = Image.FromFile(filename);
                _bitmapManager.SetImage(image);
            }
        }
    }
}
