using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Models
{
    public class Histogram
    {
        private SeriesCollection _seriesCollection;
        public SeriesCollection SeriesCollection { get; set; }
        public ChartValues<ObservableValue> ObservableValues { get; set; }
        public Func<int, string> Formatter { get; set; }
        public Separator Separator { get; set; }
        public Separator SeparatorY { get; set; }
        public int ValuesNum { get; set; } = 256;


        public Histogram()
        {
            InitializeValues();
            SeriesCollection = new SeriesCollection()
            {
                new ColumnSeries()
                {
                    Values = ObservableValues,
                    MaxColumnWidth = double.PositiveInfinity,
                    ColumnPadding = 0,
                    LabelsPosition = BarLabelPosition.Top,
                    Fill = new SolidColorBrush(Color.FromRgb(255,0,0))
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
                ObservableValues.Add(new ObservableValue(i));
            }
        }
    }
}
