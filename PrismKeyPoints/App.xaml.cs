using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Regions;
using PrismKeyPoints.ViewModels;
using PrismKeyPoints.Views;

namespace PrismKeyPoints
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
            //注册导航页面
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();
            //注册对话组件
            containerRegistry.RegisterDialog<DialogView,DialogViewModel>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            //初始化时注册区域适配器
            regionAdapterMappings.RegisterMapping(typeof(StackPanel),Container.Resolve<StackPanelRegionAdapter>());
        }
    }
}
