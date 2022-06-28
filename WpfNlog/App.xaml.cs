using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Prism.DryIoc;
using Prism.Ioc;

namespace WpfNlog
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
            
        }
        //重写容器创建的过程
        protected override IContainerExtension CreateContainerExtension()
        {
            var serviceCollection = new ServiceCollection();
            //配置日志服务
            serviceCollection.AddLogging(configure =>
            {
                configure.ClearProviders();
                configure.SetMinimumLevel(LogLevel.Trace);
                configure.AddNLog();
            });
            return new DryIocContainerExtension(new Container(CreateContainerRules()).WithDependencyInjectionAdapter(serviceCollection));
        }
    }
}
