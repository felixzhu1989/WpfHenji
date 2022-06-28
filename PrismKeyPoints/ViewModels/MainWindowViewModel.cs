using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace PrismKeyPoints.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private readonly IDialogService dialog;
        private IRegionNavigationJournal journal;//导航日志
        public DelegateCommand OpenACommand { get; }
        public DelegateCommand OpenBCommand { get; }
        public DelegateCommand GoBackCommand { get; }
        public DelegateCommand GoForwardCommand { get; }
        public DelegateCommand DialogCommand { get; }
        private string dialogResult;
        public string DialogResult
        {
            get { return dialogResult; }
            set { dialogResult = value;RaisePropertyChanged(); }
        }

        public MainWindowViewModel(IRegionManager regionManager,IDialogService dialog)
        {
            this.regionManager = regionManager;
            this.dialog = dialog;
            //向区域中注册一个页面
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
            OpenACommand = new DelegateCommand(OpenA);
            OpenBCommand = new DelegateCommand(OpenB);
            GoBackCommand = new DelegateCommand(()=>journal.GoBack());
            GoForwardCommand = new DelegateCommand(() => journal.GoForward());
            DialogCommand = new DelegateCommand(OpenDialog);
        }

        private void OpenDialog()
        {
            //传递参数
            DialogParameters param=new DialogParameters();
            param.Add("Value","TestDialog");
            dialog.ShowDialog("DialogView",param,args=>
            {
                ////接收参数
                if (args.Result == ButtonResult.OK)
                {
                    DialogResult = args.Parameters.GetValue<string>("Value");
                }
            });
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
