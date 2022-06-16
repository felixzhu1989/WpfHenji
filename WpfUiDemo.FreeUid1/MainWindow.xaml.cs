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

namespace WpfUiDemo.FreeUid1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<User> Users { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Users = new ObservableCollection<User>()
            {
                new User(){ImagePath="/user.jpg",UserName="Felix",Country="China",LoginTime="30 Mins"},
                new User(){ImagePath="/user.jpg",UserName="Felix2",Country="China",LoginTime="3 Days"},
                new User(){ImagePath="/user.jpg",UserName="Felix3",Country="China",LoginTime="30 Weeks"},
                new User(){ImagePath="/user.jpg",UserName="Felix4",Country="China",LoginTime="30 years"},
                new User(){ImagePath="/user.jpg",UserName="Felix5",Country="China",LoginTime="50 Mins"},
                new User(){ImagePath="/user.jpg",UserName="Felix6",Country="China",LoginTime="60 Mins"},
            };
            this.UserList.ItemsSource=Users;
        }
        


    }
   public class User
    {
        public string ImagePath { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public string LoginTime { get; set; }
    }
}
