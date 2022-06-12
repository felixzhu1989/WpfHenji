using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDependencyProperty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Test> tests = new List<Test>();
            tests.Add(new Test() { Code = "1" });
            tests.Add(new Test() { Code = "2" });
            tests.Add(new Test() { Code = "3" });
            tests.Add(new Test() { Code = "4" });
            tests.Add(new Test() { Code = "5" });
            tests.Add(new Test() { Code = "6" });
            ic.ItemsSource = tests;
        }
    }
    public class Test
    {
        public string Code { get; set; }        
    }
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Name = "小明";
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
