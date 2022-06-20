using System.Windows;
using System.Windows.Documents;

namespace WpfExtension
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //获取装饰层
            //var layer = AdornerLayer.GetAdornerLayer(MyButton);
            //将自定义装饰添加到装饰层
            //layer.Add(new TestAdorner(MyButton));
            foreach (UIElement item in MyPanel.Children)
            {
                var layer = AdornerLayer.GetAdornerLayer(item);
                layer.Add(new CornerAdorner(item));
            }                
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (UIElement item in MyPanel.Children)
            {
                //获取装饰层
                var layer = AdornerLayer.GetAdornerLayer(item);
                //先获取装饰层所有的装饰，然后移除装饰
                var arry = layer.GetAdorners(item);
                if (arry!=null)
                {
                    for (int i = 0; i < arry.Length; i++)
                    {
                        layer.Remove(arry[i]);
                    }
                }
            }                    
        }
    }
}
