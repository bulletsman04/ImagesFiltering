using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using MvvmFoundation.Wpf;

namespace Models
{
    public class Histogram: ObservableObject
    {
        private SeriesCollection _seriesCollection;
        private Separator _separatorY;
        public SeriesCollection SeriesCollection { get; set; }
        public ChartValues<ObservableValue> ObservableValues { get; set; }
        public Func<int, string> Formatter { get; set; }
        public Separator Separator { get; set; }
        public Separator SeparatorY
        {
            get => _separatorY;
            set
            {
                _separatorY = value;
                RaisePropertyChanged("SeparatorY");
            } }
        public int ValuesNum { get; set; } = 256;


        public Histogram(SolidColorBrush solidColor)
        {
            InitializeValues();
            SeriesCollection = new SeriesCollection()
            {
                new ColumnSeries()
                {
                    Values = ObservableValues,
                    MaxColumnWidth = 2,
                    ColumnPadding = 0,
                    LabelsPosition = BarLabelPosition.Top,
                    Fill = solidColor
                }
            };
            Separator = new Separator()
            {
                Step = 50
            };
            SeparatorY = new Separator()
            {
                Step = 1000
            };
        }

        private void InitializeValues()
        {
            ObservableValues = new ChartValues<ObservableValue>();
            for (int i = 0; i < ValuesNum; i++)
            {
                ObservableValues.Add(new ObservableValue(0));
            }
        }

        public void ResetValues()
        {
            for (int i = 0; i < ValuesNum; i++)
            {
                ObservableValues[i].Value = 0;
            }
        }
    }
}
