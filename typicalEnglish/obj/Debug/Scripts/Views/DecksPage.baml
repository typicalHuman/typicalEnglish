   M S B A M L   `   `   `  ����I  EtypicalEnglish, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:typicalEnglishtypicalEnglish  5      U/clr-namespace:typicalEnglish.Scripts.ViewModels!typicalEnglish.Scripts.ViewModels  5      k:clr-namespace:typicalEnglish.Scripts.ViewModels.Converters,typicalEnglish.Scripts.ViewModels.Converters  5      ,    &typicalEnglish.Scripts.Views.DecksPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:typicalEnglish     5      >vm/clr-namespace:typicalEnglish.Scripts.ViewModels     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      a ]GongSolutions.WPF.DragDrop, Version=2.0.0.0, Culture=neutral, PublicKeyToken=91f1945125b7a587ddurn:gong-wpf-dragdrop  5
      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=null:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      Ccv:clr-namespace:typicalEnglish.Scripts.ViewModels.Converters  5        N� Title$  	DecksPage��5         typicalEnglish.App   DecksVM � DataContext# Z 6    N� 
FontFamily$ Candara Light)�6D    � 	Resources 5      F   @typicalEnglish.Scripts.ViewModels.Converters.ColorBrushConverter   
ColorBrush��%   &	          5   
   66   5      .��5      �   PanelBackground#���  6   .+�5   
   � $��0 10 0 0q�6   #���  6"   .+�5      �� $��Center=�6   $	��Top=�62   $��70��5      $	��150��6   
������ $��New Deck��5      $��25(�6$     
Foreground#���  62     InvisButton#��[ 5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ Click��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 60   �� *
AddCommand+5      5      �� 5!      -   5        	 ��Name$	 decks��5#      )  #GongSolutions.Wpf.DragDrop.DragDrop
   IsDragSource
 . $��0 70 0 0q�5!   6      IsDropTarget . $	��Top=�5"   *   ��6B   �� *Decks+��5$      �� 5%      .R�5&      �  � Orientation$ 
Horizontal=�6$    K� IsItemsHost . 5'      5(      ��5+      �� 5,      .R�5-      �� $	��220��6!   $	��150��6.   $
��Bold"�52   E   $��Candara)�6W   ��5-   :   �� *
Background+ �� UpdateSourceTrigger$ PropertyChanged=� �� 	Converter# [  ��5/      �� *BorderColor+$ PropertyChanged=�# [  ��51   !   �� *
Foreground+$ PropertyChanged=�# [   � ContextMenu 54      �� 55   "   $
��Auto��6.   .@�56   &   m� #���  6/   ��57   *   �� 58   .    �� Orientation$ 
Horizontal=�69   
������ .+�59   2   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
Paintbrush=�6>   #���  6P   �� 5:   2   $��Customization��6<   $��4 0 0 0q�6Q   #���  6b   5;   /    5=   *     5>   .   $ Click��6=   . 5?   2      6H   ��  �� Source %	  System.Windows.Markup.Reference	  *decks+ �� Path$. (DataContext.OpenDeckCustomizationCommand�   CommandParameter 5A   8   �� 5B   /   5D   '   m� 5E   &   ���#f35f5d��5F   *   �� 5G   .   $ 
Horizontal=�69   .+�5H   2     $ Delete=�6>   #���  6L   �� 5I   2   $��Delete��6<   $��4 0 0 0q�6J   #���  6[   5J   /    5L   *     5M   .   $ Click��6=   . 5N   2      6H   ��  	  *decks+$ DataContext.DeleteCommand� 5P   8   �� 5Q   /   5S   '   5T   #   .��5W      �� $	��Top=�6)   .+�5Y   "   A� $��75��6*   $��75��65   $	��Top=�6A   $
��0 10q�6Y   ��5Z   &   �� 5[   *    �� BitmapScalingMode$
 Fant=�6Y    �� ImageSource 65   �� *ImageSource+6Y   5]   #   �� 5`   "   $
��0 10q�5a   ,   $��Center=�6:   $��20(�6W   ��5`   ,   ��  �� StringFormat$ 
Words: {0}��$ 
WordsCount�5a   W   �� 5d   "   $��20��6@   $��17(�6N    �� TextWrapping$
 Wrap=�6\    �� 
CaretBrush �#03a9f4$��Bottom=�5e   >   )
  #MaterialDesignThemes.Wpf.HintAssist 
  Hint$
 Name��6Y    �� TextAlignment$ Center=�5h   E    �� 	MaxLength$ 20��6\   ��5d   *   �� *Name+��5f   +   �� *BorderColor+$ PropertyChanged=�# [  .  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush 5g   E   �� *UnderlineColor+$ PropertyChanged=�# [  5h   \   5j       5k        5l   "   $ MouseDoubleClick��61   . 5m   &      6<   ��  �� RelativeSource ��   �� AncestorType"  ��$! DataContext.OpenDeckCommand� 5o   8   �� 5p   #   5r      5s      5v      5x      5y      5{      