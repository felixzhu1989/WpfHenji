using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;
using System.Windows.Controls;
namespace WpfExtension;
/// <summary>
/// 验证行为类,可以获得附加到的对象,用于监听处理View的错误事件
/// </summary>
public class ValidationExceptionBehavior : Behavior<FrameworkElement>
{
    /// <summary>
    /// 错误计数器
    /// </summary>
    private int _validationExceptionIndex = 0;
    /// <summary>
    /// 附加对象时
    /// </summary>
    protected override void OnAttached()
    {
        base.OnAttached();
        //附加对象时，给对象增加一个监听验证错误事件的能力，注意该事件是冒泡的
        AssociatedObject.AddHandler(Validation.ErrorEvent, new EventHandler<ValidationErrorEventArgs>(OnValidationError));
    }
    /// <summary>
    /// 验证事件
    /// </summary>    
    private void OnValidationError(object sender, ValidationErrorEventArgs e)
    {
        //获取对象
        IValidationExceptionHandler handler = null;
        if (AssociatedObject.DataContext is IValidationExceptionHandler)
        {
            handler=AssociatedObject.DataContext as IValidationExceptionHandler;
        }
        if (handler == null) return;
        //判断错误消息
        var element = e.OriginalSource as UIElement;
        if (element == null) return;
        //获取值，看是否产生错误
        if (e.Action==ValidationErrorEventAction.Added)
        {
            _validationExceptionIndex++;
        }
        else if (e.Action==ValidationErrorEventAction.Removed)
        {
            _validationExceptionIndex--;
        }
        handler.IsValid=_validationExceptionIndex==0;
    }
    protected override void OnDetaching()
    {
        base.OnDetaching();
        AssociatedObject.RemoveHandler(Validation.ErrorEvent, new EventHandler<ValidationErrorEventArgs>(OnValidationError));
    }
}
