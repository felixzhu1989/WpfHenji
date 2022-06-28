using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace PrismDialogHost.ViewModels
{
    public class ShowViewModel:BindableBase,IDialogAware
    {
        public string Title { get; set; }
        public event Action<IDialogResult>? RequestClose;
        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged();}
        }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public ShowViewModel()
        {
            SaveCommand = new DelegateCommand(() =>
            {
                if (DialogHost.IsDialogOpen("RootDialog"))
                {
                    DialogParameters param = new DialogParameters();
                    DialogHost.Close("RootDialog", new DialogResult(ButtonResult.OK, param));
                }
            });
            CancelCommand = new DelegateCommand(() =>
            {
                if (DialogHost.IsDialogOpen("RootDialog"))
                    DialogHost.Close("RootDialog", new DialogResult(ButtonResult.No));
            });
        }
        public bool CanCloseDialog()
        {
            return true;
        }
        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("Title"))
                Title=parameters.GetValue<string>("Title");
            if (parameters.ContainsKey("Content"))
                Content=parameters.GetValue<string>("Content");
        }
        public void OnDialogClosed()
        {
        }
    }
}
