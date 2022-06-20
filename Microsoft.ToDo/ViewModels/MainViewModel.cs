using Microsoft.ToDo.Common;
using Microsoft.ToDo.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ToDo.ViewModels;

public class MainViewModel:BindableBase
{
    private ObservableCollection<MenuModel> menuModels;
    public ObservableCollection<MenuModel> MenuModels
    {
        get { return menuModels; }
        set { menuModels = value;RaisePropertyChanged(); }
    }
    private MenuModel menuModel;
    public MenuModel MenuModel
    {
        get { return menuModel; }
        set { menuModel = value; RaisePropertyChanged(); }
    }
    private TaskInfo taskInfo;
    public TaskInfo TaskInfo
    {
        get { return taskInfo; }
        set { taskInfo = value; RaisePropertyChanged(); }
    }
    public DelegateCommand<MenuModel> SelectedCommand { get; set; }
    public DelegateCommand<TaskInfo> SelectedTaskCommand { get; set; }

    public MainViewModel()
    {
        MenuModels = new ObservableCollection<MenuModel>
        {
            new MenuModel(){IconFont="\xe64c",BackColor="Green",Title="我的一天",Count=3},
            new MenuModel(){IconFont="\xe600",BackColor="Red",Title="重要",Count=6},
            new MenuModel(){IconFont="\xe602",BackColor="DodgerBlue",Title="已计划日程",Count=7},
            new MenuModel(){IconFont="\xe633",BackColor="Orange",Title="分配给你",Count=5},
            new MenuModel(){IconFont="\xe60f",BackColor="LightSeaGreen",Title="任务",Count=5},
        };
        MenuModel=MenuModels[0];
        SelectedCommand = new DelegateCommand<MenuModel>(t => Select(t));
        SelectedTaskCommand = new DelegateCommand<TaskInfo>(t => SelectedTask(t));
    }

    private void SelectedTask(TaskInfo task)
    {
        TaskInfo = task;
        //Messenger.Default.Send(task, "Expand");
    }

    private void Select(MenuModel model)
    {
        MenuModel = model;
    }
    public void AddTaskInfo(string content)
    {
        MenuModel.TaskInfos=new ObservableCollection<TaskInfo>();
        MenuModel.TaskInfos.Add(new TaskInfo()
        {
            Content = content
        });
    }

}
