using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using Prism.Regions;

namespace PrismKeyPoints.ViewModels
{
    //public class ViewAViewModel : BindableBase, INavigationAware
    public class ViewAViewModel : BindableBase, IConfirmNavigationRequest
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        /// <summary>
        /// 导航完成前接收用户传递的参数，以及是否允许导航等控制
        /// </summary>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //接收导航时传递的参数
            Name=  navigationContext.Parameters.GetValue<string>("Value");
        }
        /// <summary>
        /// 导航离开当前页时触发
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
        /// <summary>
        /// 离开时提醒
        /// </summary>
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool result = true;
            if(MessageBox.Show("确认导航","温馨提示",MessageBoxButton.YesNo)==MessageBoxResult.No)result=false;
            continuationCallback(result);
        }
    }
}
