using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ToDo.Models;
/// <summary>
/// 任务模块
/// </summary>
public class TaskItem:BindableBase
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Date { get; set; }
    public string Desc { get; set; }
    private string background;
    /// <summary>
    /// 背景颜色
    /// </summary>
    public string Background
    {
        get { return background; }
        set { background = value;RaisePropertyChanged(); }
    }

    private ObservableCollection<TaskInfo> taskList;
    /// <summary>
    /// 任务列表
    /// </summary>
    public ObservableCollection<TaskInfo> TaskList
    {
        get { return taskList; }
        set { taskList = value;RaisePropertyChanged(); }
    }

}
