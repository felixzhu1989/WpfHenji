using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Services.Dialogs;

namespace PrismDialogHost.Core
{
    public interface IDialogHostService : IDialogService
    {
        //使用new覆盖IDialogService中的ShowDialog方法
        new void ShowDialog(string name,IDialogParameters parameters,Action<IDialogResult> callback);
    }
}
