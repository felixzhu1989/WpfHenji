using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace WpfAnimation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BtnStart(object sender, RoutedEventArgs e)
        {
            Storyboard sb=new Storyboard();
            sb.Children.Add(CreateDoubleAnimation(sample1,false, new RepeatBehavior(1), "Width",30));
            sb.Children.Add(CreateDoubleAnimation(sample2,false, new RepeatBehavior(5), "Height",30));
            sb.Children.Add(CreateDoubleAnimation(sample3,true, RepeatBehavior.Forever, "Width",30));
            sb.Children.Add(CreateDoubleAnimation(sample4,true, RepeatBehavior.Forever, "Height", 30 ));
            sb.Begin();
        }
        /// <summary>
        /// 封装的DoubleAnimation动画
        /// </summary>        
        private Timeline CreateDoubleAnimation(UIElement element,bool autoReverse, RepeatBehavior repeat,string property,double by,bool opacity=false)
        {
            DoubleAnimation da = new()
            {
                //From=0,//动画起始值
                //To=100,//动画结束值
                By=by,//原始基础上增加范围
                Duration=TimeSpan.FromSeconds(2),//动画持续时间
                RepeatBehavior=repeat,//动画无限次播放
                AutoReverse=autoReverse //是否倒序播放
            };
            if (opacity) da.From=0;//如果是透明度，则需要设置起始透明度为0
            Storyboard.SetTarget(da, element);
            Storyboard.SetTargetProperty(da, new PropertyPath(property));
            return da;
        }
        private void BtnRotateStart(object sender, RoutedEventArgs e)
        {
            Storyboard sb = new Storyboard();

            sb.Children.Add(CreateDoubleAnimation(sample2_1,false, new RepeatBehavior(1), "(UIElement.RenderTransform).(TranslateTransform.X)", 30));//位移动画
            sb.Children.Add(CreateDoubleAnimation(sample2_2,false, new RepeatBehavior(5), "(UIElement.RenderTransform).(TranslateTransform.Y)", 30));//位移动画
            sb.Children.Add(CreateDoubleAnimation(sample2_3,false, RepeatBehavior.Forever, "(UIElement.RenderTransform).(RotateTransform.Angle)", 360));//旋转动画
            sb.Children.Add(CreateDoubleAnimation(sample2_4, true, RepeatBehavior.Forever, "(UIElement.RenderTransform).(TranslateTransform.X)", 30));//位移动画
            sb.Begin();
        }
        private void BtnOpacityStart(object sender, RoutedEventArgs e)
        {
            Storyboard sb = new Storyboard();
            sb.Children.Add(CreateDoubleAnimation(sample3_1, false, new RepeatBehavior(1), "Opacity",1,true));
            sb.Children.Add(CreateDoubleAnimation(sample3_2, false, new RepeatBehavior(5), "Opacity",1,true));
            sb.Children.Add(CreateDoubleAnimation(sample3_3, true, RepeatBehavior.Forever, "Opacity",1,true));
            sb.Children.Add(CreateDoubleAnimation(sample3_4, true, RepeatBehavior.Forever, "Opacity",1,true));
            sb.Begin();
        }
    }
}
