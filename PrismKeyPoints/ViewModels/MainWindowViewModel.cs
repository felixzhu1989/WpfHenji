using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismKeyPoints.Views;

namespace PrismKeyPoints.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private IRegionNavigationJournal journal;//导航日志
        public DelegateCommand OpenACommand { get; }
        public DelegateCommand OpenBCommand { get; }
        public DelegateCommand GoBackCommand { get; }
        public DelegateCommand GoForwardCommand { get; }
        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            //向区域中注册一个页面
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
            OpenACommand = new DelegateCommand(OpenA);
            OpenBCommand = new DelegateCommand(OpenB);
            GoBackCommand = new DelegateCommand(()=>journal.GoBack());
            GoForwardCommand = new DelegateCommand(() => journal.GoForward());
        }
        private void OpenB()
        {
            //区域名称和页面名称
            regionManager.RequestNavigate("ContentRegion", "ViewB", arg =>
            {
                journal = arg.Context.NavigationService.Journal;
            });
        }

        private void OpenA()
        {
            //NavigationParameters param=new NavigationParameters();
            //param.Add("Value","Felix");//键值对的方式传递参数
            //regionManager.RequestNavigate("ContentRegion", "ViewA",param);
            //或者直接使用Http请求书写方式传递参数
            regionManager.RequestNavigate("ContentRegion", $"ViewA?Value=Felix", arg =>
            {
                journal = arg.Context.NavigationService.Journal;
            });
        }
    }
}
