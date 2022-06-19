using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Resources;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.Collections;
using System.Windows.Baml2006;
using System.IO;
using System.Windows.Markup;
using System.Diagnostics;
using System.Reflection;
using System.Drawing;

namespace Microsoft.ToDo
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
            DirectoryInfo folder = new DirectoryInfo(@"C:\Program Files (x86)\HuyaLive\HuyaCient\Net45");
            foreach (var file in folder.GetFiles("*.dll"))
            {
                try
                {
                    //获取所有的图片资源
                    var assembly = Assembly.LoadFile(file.FullName);
                    var resourcesName = $"{assembly.GetType().Assembly.GetName().Name}.g";
                    var manager = new ResourceManager(resourcesName, assembly.GetType().Assembly);
                    var resourceSet = manager.GetResourceSet(CultureInfo.CurrentCulture, true, true);
                    var dictonaryEntries = resourceSet.OfType<DictionaryEntry>().ToList();
                    dictonaryEntries.ForEach(entry =>
                    {
                        if (entry.Key.ToString().Contains("png"))
                        {
                            Bitmap bitmap = new Bitmap((Stream)entry.Value);
                            string saveFilePath = @$"{AppDomain.CurrentDomain.BaseDirectory}Image\{Guid.NewGuid().ToString()}.png";
                            bitmap.Save(saveFilePath);
                        }
                    //Baml2006Reader reader = new Baml2006Reader((Stream)entry.Value);
                    //var win = XamlReader.Load(reader) as Window;
                    //Debug.Print(win.Name);
                });
                }
                catch
                {

                }
            }
        }
    }
}
