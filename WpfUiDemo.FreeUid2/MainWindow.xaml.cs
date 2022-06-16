using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfUiDemo.FreeUid2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<MenuModel> MenuModels { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            MenuModels = new ObservableCollection<MenuModel>();
            MenuModels.Add(new MenuModel() { IconFont = "\xec1e", Title = "Live scores", });
            MenuModels.Add(new MenuModel() { IconFont = "\xe621", Title = "Series", });
            MenuModels.Add(new MenuModel() { IconFont = "\xe745", Title = "Teams", });
            MenuModels.Add(new MenuModel() { IconFont = "\xeca7", Title = "Features", });
            MenuModels.Add(new MenuModel() { IconFont = "\xe637", Title = "Videos", });
            MenuModels.Add(new MenuModel() { IconFont = "\xe6d9", Title = "Stats", });
            MenuModels.Add(new MenuModel() { IconFont = "\xe660", Title = "World cup 2019", });
            MenuBar.ItemsSource=MenuModels;
        }
    }
    public class MenuModel
    {
        public string IconFont { get; set; }
        public string Title { get; set; }
    }
}
