using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ToDo.Models;
public class MenuModel : BindableBase
{
    public string IconFont { get; set; }
    public string BackColor { get; set; }
    public string Title { get; set; }
    public int Count { get; set; }
    public bool Display { get; set; }=true;
    private ObservableCollection<TaskInfo> taskInfos;
    /// <summary>
    /// 任务列表
    /// </summary>
    public ObservableCollection<TaskInfo> TaskInfos
    {
        get { return taskInfos; }
        set { taskInfos = value; RaisePropertyChanged(); }
    }
}
