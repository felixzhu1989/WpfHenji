using LiveCharts;
using LiveCharts.Geared;
using LiveCharts.Wpf;
using System.Windows;
namespace WpfLiveChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //数据源
        public SeriesCollection series { get; set; }
        public SeriesCollection series1 { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChartValues<double> arr = new ChartValues<double>();
            for (int i = 0; i < 1000; i++)
            {
                arr.Add(i);
            }
            series =new SeriesCollection();
            series.Add(new LineSeries() { Values=arr });
            //绑定数据源
            c1.Series=series;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GearedValues<double> arr = new GearedValues<double>();
            for (int i = 0; i < 1000; i++)
            {
                arr.Add(i);
            }
            series =new SeriesCollection();
            series.Add(new GLineSeries() { Values=arr });
            //绑定数据源
            c2.Series=series;
        }
    }
}
