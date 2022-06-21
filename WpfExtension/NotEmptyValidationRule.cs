using System.Globalization;
using System.Windows.Controls;
namespace WpfExtension;
public class NotEmptyValidationRule : ValidationRule
{   
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        //验证器，验证数据是否为空，为空就报错，不为空则返回正常
        return string.IsNullOrWhiteSpace((value??"").ToString()) ? new ValidationResult(false, "数据不能为空") : ValidationResult.ValidResult;        
    }
}
