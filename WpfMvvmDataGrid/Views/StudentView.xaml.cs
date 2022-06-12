using System.Windows;
using WpfMvvmDataGrid.Models;
namespace WpfMvvmDataGrid.Views
{
    /// <summary>
    /// StudentView.xaml 的交互逻辑
    /// </summary>
    public partial class StudentView : Window
    {
        public StudentView(Student student)
        {
            InitializeComponent();
            DataContext = new { Model = student};
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
