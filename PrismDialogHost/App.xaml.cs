using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism.DryIoc;
using Prism.Ioc;
using PrismDialogHost.Core;
using PrismDialogHost.ViewModels;
using PrismDialogHost.Views;

namespace PrismDialogHost
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
           return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //注册对话组件
            containerRegistry.RegisterDialog<ShowView,ShowViewModel>();
            //注册自定义IDialogHostService,Dialog对话服务
            containerRegistry.Register<IDialogHostService,DialogHostService>();
        }
    }
}
