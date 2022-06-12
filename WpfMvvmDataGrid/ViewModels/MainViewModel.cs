using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WpfMvvmDataGrid.Db;
using WpfMvvmDataGrid.Models;
using WpfMvvmDataGrid.Views;

namespace WpfMvvmDataGrid.ViewModels;

public class MainViewModel: BindableBase
{
    LocalDb localDb;
    private ObservableCollection<Student> gridModelList;
    public ObservableCollection<Student> GridModelList
    {
        get { return gridModelList; }
        set { gridModelList = value; RaisePropertyChanged(); }
    }
    private string search=string.Empty;
    public string Search
    {   
        get { return search; }
        set { search = value; RaisePropertyChanged(); }
    }

    #region Command
    public DelegateCommand QueryCommand { get;}
    public DelegateCommand ResetCommand { get;}
    public DelegateCommand AddCommand { get;}
    //DataContext是整个页面的上下文，然后是查找绑定
    public DelegateCommand<int?> EditCommand { get; }
    public DelegateCommand<int?> DeleteCommand { get; }

    #endregion

    public MainViewModel()
    {
        localDb = new LocalDb();
        gridModelList = new ObservableCollection<Student>();
        Query();
        QueryCommand=new DelegateCommand(Query);
        ResetCommand = new DelegateCommand(() => { Search = string.Empty; Query(); });
        AddCommand = new DelegateCommand(Add);
        EditCommand = new DelegateCommand<int?>(Edit);
        DeleteCommand=new DelegateCommand<int?>(Delete);
    }

    private void Add()
    {
        Student model = new Student();
        StudentView view = new StudentView(model);
        var result = view.ShowDialog();
        if (result.Value)
        {
            model.Id = GridModelList.Max(x => x.Id) + 1;
            localDb.AddStudent(model);
            GridModelList.Add(model);
        }
    }

    private void Delete(int? id)
    {
        var model = localDb.GetStudentById(id);
        if (model != null)
        {
            var result=MessageBox.Show($"确定要删除学员{model.Name}吗？","删除询问",MessageBoxButton.YesNo,MessageBoxImage.Question);
           if (result==MessageBoxResult.Yes)
            {
                localDb.DeleteStudent(id);
                var newModel = GridModelList.FirstOrDefault(x => x.Id.Equals(model.Id));
                if (newModel != null)
                {
                    GridModelList.Remove(newModel);
                }
            }
        }
    }

    private void Edit(int? id)
    {
        var model=localDb.GetStudentById(id);
        if (model != null)
        {
            StudentView view = new StudentView(model);
            var result = view.ShowDialog();
            if (result.Value)
            {
                localDb.EditStudent(model);
                var newModel= GridModelList.FirstOrDefault(x => x.Id.Equals(model.Id));
                if (newModel != null)
                {
                    newModel.Name = model.Name;
                }
            }
        }
    }

    public void Query()
    {
        var models = localDb.GetStudentsByName(Search);
        gridModelList.Clear();
        if (models != null)
        {
            models.ForEach(x => gridModelList.Add(x));
        }
    }
    
}
