using Prism.Commands;
using Prism.Mvvm;

namespace WpfExtension;
/// <summary>
/// ViewModel继承IValidationExceptionHandler , 用于接收前端的验证结果。
/// </summary>
public class MainViewModel:BindableBase, IValidationExceptionHandler
{
    private bool isValid;
    public bool IsValid
    {
        get { return isValid; }
        set { isValid = value; RaisePropertyChanged(); }
    }
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; RaisePropertyChanged(); }
    }
    public DelegateCommand SaveCommand { get; set; }
    public MainViewModel()
    {
        //ViewModel 通过实现 IValidationExceptionHandler 来获取前端的验证结果
        SaveCommand=new DelegateCommand(() =>
        {
            if (!IsValid) return;//不通过则返回
            //进行正常业务逻辑

        });
    }
}
