using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MaterialDesignThemes.Wpf;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace PrismDialogHost.Core
{
    public class DialogHostService:DialogService,IDialogHostService
    {
        private readonly IContainerExtension containerExtension;
        public DialogHostService(IContainerExtension containerExtension) : base(containerExtension)
        {
            this.containerExtension = containerExtension;
        }
        //具体实现细节
        public new void ShowDialog(string name, IDialogParameters parameters, Action<IDialogResult> callback)
        {
            if(parameters == null)
                parameters=new DialogParameters();
            //从容器当中取出实例
            var content =containerExtension.Resolve<object>(name);
            if (!(content is FrameworkElement dialogContent))
                throw new NullReferenceException("A Dialog's content must be a FrameworkElement");
            //绑定上下文，自动查找
            if (dialogContent is FrameworkElement view && view.DataContext is null &&
                ViewModelLocator.GetAutoWireViewModel(view) is null)
                ViewModelLocator.SetAutoWireViewModel(view, true);
            //验证ViewModel
            if (!(dialogContent.DataContext is IDialogAware viewModel))
                throw new NullReferenceException("A Dialog's ViewModel must implement the IDialogAware interface");
            if(viewModel!=null) viewModel.OnDialogOpened(parameters);
            //往名为RootDialog的节点当中设置内容content
            DialogHost.Show(content,"RootDialog");
        }
    }
}
