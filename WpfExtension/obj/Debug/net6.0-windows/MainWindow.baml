   M S B A M L   `   `   `  ����G  CWpfExtension, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfExtensionWpfExtension  5   	       WpfExtension.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfExtension     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a:behavior+http://schemas.microsoft.com/xaml/behaviors  5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
MainWindow��5   	   $	��800��5	   	   $
��1080��5
   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	   $��微软雅黑)�5   	    � DataContext 5          WpfExtension.MainViewModel  5   
   *  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5      .   (WpfExtension.ValidationExceptionBehavior  5   
    � 	Resources 5      #   WpfExtension.DisplayConverter 	 discv(   "WpfExtension.DisplayMultiConverter  dismulcv��%:   &	       &	        5   
   6!     5   
   6&   5      .��5      �  � RowDefinitions 5    
   �� 5!      $
��auto �6   �� 5"      $
��auto �6   �� 5#      $
��auto �6   �� 5$      $
��auto �6   �� 5%      $
��auto �6   �� 5&      .+�5)   
   �� -   5         ��Name$ MyPanel��5)      $��10q�5*       �� Orientation$ 
Horizontal=�5+      $��Center=�5,      $
��Left=�5-      .+�5.      �� -   5        	 ��Name$	 MyButton��5.      $	��200��5/      $��40��50      $��10q�51      �� 52      $	��200��6   $��40��53      $��10q�54      �� 55      $��	/user.jpg��6   $��40��56      $��40��57      58      �� 59   
   $ 
Horizontal=�6   $��Right=�5:      .+�5;      �� -   5        $	��150��5;      $��40��5<      $��添加装饰效果��5=      $��10q�5?      �� 5@      -   5        $	��150��5@      $��40��5A      $��移除装饰效果��5B      $��10q�5D      5E      � 5G   
   $��1��6   $
��20,0q�5H      
 � ColumnDefinitions
 5I      �� 5J      �� 5K      .+�5M      �� .+�5N      � .+�5O      �� -   5        $��t1��5P       $��0��5O       $��30(�5Q       �� 5R      $��30(�5S       $��Right=�5T       ��5R       ��  �� ElementName$ t1�� �� Path$
 Text� �� 	Converter# [ 5T       5U      � 5V      .+�5W      �� -   5        $��t2��5X       $��1��5W       $��30(�5Y       �� 5Z      $��30(�5[       $��Right=�5\       ��5Z       �� $ t2��$
 Text�# [ 5\       5]      5^      �� 5_      $��1��6   $ 
Horizontal=�5`      $��Center=�5a      $��Center=�5b      .+�5c      F� ��5d      @� 5e       @� Center$ 40,40&�6*    @� RadiusX$ 20Q�5f   *    @� RadiusY$ 20Q�5g   *   ��5i      `� 5j       `� 	Converter# [ 6'   .1�5k      �� $ sliderR��6&   $ Value�5l   &   �� 5m      $ sliderG��6&   $ Value�5n   &   �� 5o      $ sliderB��6&   $ Value�5p   &   5q      5s      �� 5t      .+�5u      �� -   5         ��Name$ sliderR��5u       � Minimum$ 0Q�5v       � Maximum$	 255Q�5w      $	��400��5x      $��5q�5y      �� 5z      -   5        $ sliderG��5z      $ 0Q�5{      $	 255Q�5|      $	��400��5}      $��5q�5~      �� 5      -	   5        $ sliderB��5      $ 0Q�5�      $	 255Q�5�      $	��400��5�      $��5q�5�      5�      5�      5�      �� 5�   
   $��2��6   $ 
Horizontal=�5�      $��Center=�5�      $��5q�5�      .+�5�      �� $��	Behaviors��6   $��Center=�5�      $��10q�5�       5�      !   WpfExtension.EffectBehavior  5�      5�   4   �� 5�      $��	Behaviors��6   $	��200��5�      $��35��5�       5�        5�      5�      5�      �� 5�   
   $��3��6   $ 
Horizontal=�5�      $��Center=�5�      $��5q�5�      .+�5�      �� $	��200��6   $��40��5�       % !MaterialDesignFloatingHintTextBox#��[ 5�      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	登录名��5�      .��6;   ��5�      �� 5�      $
 Name�6    �� NotifyOnValidationError$
 True��5�       �� UpdateSourceTrigger$ PropertyChanged=�5�       �� ValidationRules 5�      )	   #WpfExtension.NotEmptyValidationRule	  5�      ,
  &System.Windows.Controls.ValidationRule 
  ValidatesOnTargetUpdated$
 True��6;   5�      .��5�       5�      �� 5�      $��提交��6   $��30��5�      $
��10,0q�5�      ��5�      �� *SaveCommand+5�      5�      5�      5�      