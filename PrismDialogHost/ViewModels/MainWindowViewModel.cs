using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DryIoc;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using PrismDialogHost.Core;
using PrismDialogHost.Views;

namespace PrismDialogHost.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IDialogHostService dialog;
        public DelegateCommand ShowCommand { get; }
        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged(); }
        }

        public MainWindowViewModel(IDialogHostService dialog)
        {
            this.dialog = dialog;
            ShowCommand = new DelegateCommand(Show);
        }

        private void Show()
        {
            DialogParameters param = new DialogParameters();
            param.Add("Title", "TestDialog");
            param.Add("Content",Content);
            dialog.ShowDialog(nameof(ShowView), param, arg =>
            {
                if (arg.Result == ButtonResult.OK && arg.Parameters.ContainsKey("Content"))
                {
                    Content= arg.Parameters.GetValue<string>("Content");
                }
            });
        }
    }
}
