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
using System.Drawing.Imaging;
using Microsoft.ToDo.ViewModels;
using Microsoft.ToDo.Models;

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
            //点击标题区域可以移动窗体
            logo.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed) DragMove();
            };
            titleBar.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed) DragMove();
            };
            btnmin.Click += (s, e) => { WindowState = WindowState.Minimized; };
            btnmax.Click += (s, e) =>
            {
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            };
            btnclose.Click += async (s, e) =>
            {
                //var dialogResult = await _dialogHost.Question("温馨提示", $"确认退出系统吗?");
               //if (dialogResult.Result != Prism.Services.Dialogs.ButtonResult.OK) return;
                Close();
            };
        }


        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string inputValue = inputText.Text;
                if (inputValue == "") return;

                var vm = this.DataContext as MainViewModel;
                vm.AddTaskInfo(inputValue);
                inputText.Text = string.Empty;
            }
        }
        private void ExpandColumn(TaskInfo task)
        {
            var cdf = grc.ColumnDefinitions;
            if (cdf[1].Width == new GridLength(0))
            {
                cdf[1].Width = new GridLength(280);
                btnmin.Foreground = new SolidColorBrush(Colors.Black);
                btnmax.Foreground = new SolidColorBrush(Colors.Black);
                btnclose.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                cdf[1].Width = new GridLength(0);
                btnmin.Foreground = new SolidColorBrush(Colors.White);
                btnmax.Foreground = new SolidColorBrush(Colors.White);
                btnclose.Foreground = new SolidColorBrush(Colors.White);
            }
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
