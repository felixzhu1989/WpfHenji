using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace PrismKeyPoints.ViewModels
{
    public class DialogViewModel:BindableBase,IDialogAware
    {
        public string Title { get; set; }
        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged();}
        }
        public event Action<IDialogResult>? RequestClose;
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public DialogViewModel()
        {
            SaveCommand = new DelegateCommand(() =>
            {
                DialogParameters param=new DialogParameters();
                param.Add("Value", Content);
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK, param));
            });
            CancelCommand = new DelegateCommand(() =>
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.No));
            });
        }
        public bool CanCloseDialog()
        {
            return true;
        }
        public void OnDialogClosed()
        {
        }
        /// <summary>
        /// 打开窗口时传递参数
        /// </summary>
        /// <param name="parameters"></param>
        public void OnDialogOpened(IDialogParameters parameters)
        {
           Title= parameters.GetValue<string>("Value");
        }
    }
}
