using System;
using System.Collections.Generic;
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

namespace WpfUiDemo.NetEast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitMenuList();
        }
        void InitMenuList()
        {
            List<MemuItem> list = new List<MemuItem>
            {
                new MemuItem() { Code = "&#xe693;", Name = "搜索" },
                new MemuItem() { Code = "&#xe62d;", Name = "发现音乐" },
                new MemuItem() { Code = "&#xe6ab;", Name = "MV" },
                new MemuItem() { Code = "&#xe745;", Name = "朋友" }
            };
            
        }
    }
    public class MemuItem
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
