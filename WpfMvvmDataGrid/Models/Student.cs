using Prism.Mvvm;
namespace WpfMvvmDataGrid.Models;
public class Student:BindableBase
{
    private int id;
    public int Id
    {
        get { return id; }
        set { id = value; RaisePropertyChanged(); }
    }
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value;RaisePropertyChanged(); }
    }

}
