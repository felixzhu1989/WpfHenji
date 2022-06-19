using Microsoft.ToDo.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ToDo.ViewModels;

public class MainViewModel
{
    private ObservableCollection<MenuItem> menuItems;
    public ObservableCollection<MenuItem> MenuItems
    {
        get { return menuItems; }
        set { menuItems = value; }
    }
    public MainViewModel()
    {
        MenuItems = new ObservableCollection<MenuItem>
        {
            new MenuItem(){Icon="\xe64c",BackColor="Green",Name="我的一天",Count=1},
            new MenuItem(){Icon="\xe600",BackColor="Red",Name="重要",Count=3},
            new MenuItem(){Icon="\xe602",BackColor="DodgerBlue",Name="已计划日程",Count=4},
            new MenuItem(){Icon="\xe633",BackColor="Orange",Name="分配给你",Count=8},
            new MenuItem(){Icon="\xe60f",BackColor="LightSeaGreen",Name="任务",Count=2},
        };
    }
}
