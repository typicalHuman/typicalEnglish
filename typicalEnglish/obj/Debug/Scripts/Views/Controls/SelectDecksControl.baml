   M S B A M L   `   `   `  ����I  EtypicalEnglish, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:typicalEnglishtypicalEnglish  5      U/clr-namespace:typicalEnglish.Scripts.ViewModels!typicalEnglish.Scripts.ViewModels  5	      k:clr-namespace:typicalEnglish.Scripts.ViewModels.Converters,typicalEnglish.Scripts.ViewModels.Converters  5
      >    8typicalEnglish.Scripts.Views.Controls.SelectDecksControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:typicalEnglish     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=null:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      8vm/clr-namespace:typicalEnglish.Scripts.ViewModels  5	      Ccv:clr-namespace:typicalEnglish.Scripts.ViewModels.Converters  5
        � 	Resources  5      F   @typicalEnglish.Scripts.ViewModels.Converters.ColorBrushConverter   
ColorBrush��%   &	          5   
   66   5      .��5      � .+�5   
   �� -   5         ��Name$ decks��5         typicalEnglish.App   DecksVM � DataContext# Z 5      $	��Top=�5   	   $��1��6?   ��6!   �� *Decks+��5      �� 5      .R�5      �  � Orientation$ 
Horizontal=�6     K� IsItemsHost . 5      5      ��5      �� 5      .R�5      �� $��10 10q�6"   .+�5      �� $��Center=�6#   -  'MaterialDesignThemes.Wpf.CheckBoxAssist   CheckBoxSize$ 40Q�5    #    d� 	IsChecked 6G   �� *
IsSelected+ �� UpdateSourceTrigger$ PropertyChanged=�  5"        MaterialDesignCheckBoxOff	 �� Color��%+   &	       �� 5$   "   $	 #03a9f4��6T   5%      .  (System.Windows.Interactivity.Interaction
   Triggers
 5&      /  )System.Windows.Interactivity.EventTrigger  5'   "      	EventName$ Checked��61   .  (System.Windows.Interactivity.TriggerBase   Actions. 5(   &   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6<   ��  �� RelativeSource ��  �� AncestorType$
 PageL� �� Path$&  DataContext.CheckedChangeCommand�5*   #     5+   "   $ 	Unchecked��61   . 5,   &      6<   ��  �� $
 PageL�$&  DataContext.CheckedChangeCommand�5.   #   50      �� 51      $	��220��6!   $	��150��6.   $
��Bold"�57   E   $��Candara)�6W   ��52   !   �� *
Background+$ PropertyChanged=� �� 	Converter# [  ��54      �� *BorderColor+$ PropertyChanged=�# [  ��56   !   �� *
Foreground+$ PropertyChanged=�# [  .��58      �� $	��Top=�6)   .+�5:   "   A� $��75��6*   $��75��65   $	��Top=�6A   $
��0 10q�6Y   ��5;   &   �� 5<   *    �� ImageSource 65   �� *ImageSource+5>   #   �� 5A   "   $
��0 10q�5B   ,   $��Center=�6:   $��20(�6W   ��5A   ,   ��  �� StringFormat$ 
Words: {0}��$ 
WordsCount�5B   W   �� 5E   "   $��20��6@   $��17(�6N    �� 
IsReadOnly .  �� 
CaretBrush �#03a9f4$��Bottom=�5F   >   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Name��6Y    �� TextWrapping$
 Wrap=�5G   *    �� TextAlignment$ Center=�6>   ��5E   *   �� *Name+��5H   *   �� *BorderColor+$ PropertyChanged=�# [  .	  (MaterialDesignThemes.Wpf.TextFieldAssist 	  UnderlineBrush 5I   E   �� *UnderlineColor+$ PropertyChanged=�# [  5L      5M      5N      5P      5S      5U      5V      