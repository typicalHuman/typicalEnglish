   M S B A M L   `   `   `  ����I  EtypicalEnglish, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:typicalEnglishtypicalEnglish  5      U/clr-namespace:typicalEnglish.Scripts.ViewModels!typicalEnglish.Scripts.ViewModels  5      k:clr-namespace:typicalEnglish.Scripts.ViewModels.Converters,typicalEnglish.Scripts.ViewModels.Converters  5      +    %typicalEnglish.Scripts.Views.DeckPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:typicalEnglish     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=null:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      _ [ICSharpCode.AvalonEdit, Version=6.0.1.278, Culture=neutral, PublicKeyToken=9cc39be6723703107av.http://icsharpcode.net/sharpdevelop/avalonedit  5	      a ]GongSolutions.WPF.DragDrop, Version=2.0.0.0, Culture=neutral, PublicKeyToken=91f1945125b7a587ddurn:gong-wpf-dragdrop  5      8vm/clr-namespace:typicalEnglish.Scripts.ViewModels  5      Ccv:clr-namespace:typicalEnglish.Scripts.ViewModels.Converters  5        N� Title$  DeckPage��5         typicalEnglish.App   DeckVM � DataContext# Z 6    N� 
FontFamily$ Candara Light)�5         
Foreground N� 
Foreground# �   6"    � 	Resources 5      J   DtypicalEnglish.Scripts.ViewModels.Converters.InverseBooleanConverter  BooleanInverse��%   &	         5   
   6>   5      .��5      � $��0 10 0 0q�6    � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      .+�5   
   ��   
BackButton#��[ 6   .  (System.Windows.Interactivity.Interaction   Triggers 5       /  )System.Windows.Interactivity.EventTrigger  5!         	EventName$ Click��6!   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5"      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6,   �� *BackCommand+5#      5%      �� 5)   
   $��Center=�6   $	��Top=�6.   
������ $��70��5*      $	��150��6   $��25(�6)   $��New word��5+      #���   6$     InvisButton#��[ 5,       5-        5.      $ Click��6!   .	 5/        
 6,   �� *AddWordCommand+50      52      �� 57   
   $
��Auto=�6   $��1��6:   $��0 0 0 25q�6G   .��58      �� -   5         ��Name$ words��59   0   )  #GongSolutions.Wpf.DragDrop.DragDrop   IsDropTarget . $��Stretch=�6   ��58   <   �� *Words+ 5;       �� 
TargetType �� BasedOn  
NoneBorder �� Property �� Value �� RelativeSource �� AncestorType �� Path �� 	Converter �� Triggers ^� 
Conditions �� Binding �� Value.  (MaterialDesignThemes.Wpf.TextFieldAssist��%�  &	       7��7  �� 5<      " ��6   8   .�5>      ��  �@��
IsReadOnly 67   ��  �� $
 GridL�$ DataContext.IsEditing�8   5@      ^� 5A       5B   "   �� 5C   &    60   ��  �� $
 GridL�$ DataContext.IsEditing� True5D   &   0�5F   "   �� 5G   &    �@ UnderlineBrush �#03a9f46Z   �� 5H   &    � �� �#03a9f46D   5J      ^� 5K       5L   "   �� 5M   &    60   ��  �� $
 GridL�$ DataContext.IsEditing�	 False5N   &   0�5P   "   �� 5Q   &    �@ UnderlineBrush
 ���� 6Z   �� 5R   &    � ��
 ���� 6D   5T      5V      5X      ��5[      �� 5\      " ��6   .�5]      ��  � ��$ Stretch=�6@   6R   5^      ��5b      �� 5c      .R�5d      �� $��Stretch=�6%   .+�5f      �  �Name$ wordGrid��6<   
������  � ContextMenu 5h   "   �� 5i   &   $
��Auto��62   .@�5j   *   m� ���#f35f5d��5k   .   �� 5l   2    �� Orientation$ 
Horizontal=�6=   .+�5m   6   '	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind$ Delete=�6B   #���   6P   �� 5n   6   $��Delete word��6@   $��4 0 0 0q�6S   #���   6d   5o   3    5q   .     5r   2   $ Click��6A   .	 5s   6     
 5t   -   ��  �� Source %
  System.Windows.Markup.Reference
  *words+$# DataContext.DeleteWordCommand�   CommandParameter 5v   5   �� 5w   3   5y   +   5z   '   .+�5~   "   �� $��Center=�6-   .+�5�   &   �� $��already exists��60   $��Center=�6F   ���#f52d0b$��Center=�5�   E   $��15(�6b   ��5�   *   �� 5�   .   " ��64    5�   2   �� 5�   6    �� Binding 6B   �� *IsAlreadyExists+  �� UpdateSourceTrigger$  PropertyChanged=�! �� Value	! False5�   B   .a�5�   :   ��  � y�$ 	Collapsed=�6W   5�   7   5�   /   5�   '   �� 5�   &   $��Italic$�6H   $��30(�5�   (   #��[ 66   $��Center=�6Z   $��20��5�   .   " �� 	MaxLength$" 60��6<   # �� TextAlignment$# Center=�6K   ��5�   .   �� *
Spelling+5�   K   �� 5�   *   $��15(�5�   ,   $��Center=�6:   #��[ 6W   $" 90��6{   $# Center=�5�   .   ��5�   2   �� $ �� StringFormat$$ [{0}]��$ Transcription�5�   .   5�   #   �� 5�   "   $
��Left=�6K   
������ $��0q�5�   ;   
������ #���   5�   )   ��5�   )   0  *MaterialDesignThemes.Wpf.PackIconExtension  %   Kind$
% More=� 5�   &     5�   *   $ Click��69   .	 5�   .     
 5�   -   �� *ShowInfoCommand+5�   +   5�   #   �� 5�   &   #���   6-   $��Right=�6X   
������ $��0q�5�   ;   
������  5�   *     5�   .   $ Click��6=   .	 5�   2     
 5�   -   �� *EditCommand+5�   /   ��5�   *   �� 5�   .   " ��64   # [B��6H    5�   2   �� 5�   6    6B   �� *	IsEditing+$  PropertyChanged=�! True6�   .a�5�   :   ��  � �� 6T     $% Close=�5�   7   �� 5�   6    6B   �� *	IsEditing+$  PropertyChanged=�	! False6�   .a�5�   :   ��  � �� 6T     $
% Edit=�5�   7   5�   /   5�   '   5�      � 5�      y�6#   �� *MoreVisibility+ 5�   "     	addButton  ButtonBorderBrush��%�  &	       7  �� 5�   &   " ��6,   8   .�5�   *   ��  � ��# �   6G   �� 5�   *    � ��# �  6H   �� 5�   *    � ��$	 7 0q�6C    5�   *   �� 5�   .    6:   ��  �� $
 GridL�$ DataContext.IsEditing�! True6�   .a�5�   2   ��  � y�$ Visible=�6O   5�   /   �� 5�   .    6:   ��  �� $
 GridL�$ DataContext.IsEditing�	! False6�   .a�5�   2   ��  � y�$ 	Collapsed=�6O   5�   /   5�   '   5�   #   .+�5�   "   �� .+�5�   &   �� & ��Name$& speakBtn��5�   )   $��Center=�5�   -   #��[ 6J   
������ #���   5�   ;   $
��0 10q�6e   ��5�   B     $% Speakerphone=�'   Size$' 23X�( � ToolTip( 5�   *   _� 5�   .     PanelBackground#���  66   #���   6e   $��Pronunciation��6�   $��14(�6�   $��Candara)�5�   2    5�   *     5�   .   $ Click��6=   .	 5�   2     
 5�   -   �� *SpeakCommand+5�   /    5�   *   �� 5�   .   $
��Auto��6:   .@�5�   2   m� #���  6;   ��5�   6   �� 5�   :   $ 
Horizontal=�6E   .+�5�   >   	  $ FileEdit=�6J   #���   6Z   �� 5�   >   $��Change sound��6H   $��4 0 0 0q�6\   #���   6m   5�   ;    5�   6     5�   :   $ Click��6I   .	 5�   >     
 5�   -   �� *ChangeSoundFileCommand+5�   ;   5�   3   5�   /   5�   '   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� $�� Translations:��64   $��25(�6J   �� 5�   *   $��Add Translation��61   
������ #��[ 6d    5�   .     5�   2   $ Click��6A   .	 5�   6     
 5   -   �� *AddTranslationCommand+5  3   5  +   5  '   �� 5  &   $ translations��5  /   ��5  3   �� *Translations+$  PropertyChanged=���5  *   �� 5	  .   .R�5
  2   �� $��20(�5  :   #��[ 6H   $	��5 0q�6l   $" 70��5  :   )  #MaterialDesignThemes.Wpf.HintAssist)   Hint$
) Word��5  6   ��5
  :   �� $ Value�$  PropertyChanged=�.��5  P    5  6   �� 5  :   $
��Auto��6F   .@�5  >   m� ���#f35f5d��5  B   �� 5  F   $ 
Horizontal=�6Q   .+�5  J   	  $ Delete=�6V   #���   6d   �� 5  J   $��Delete��6T   $��4 0 0 0q�6b   #���   6s   5  G    5  B     5  F   $ Click��6U   .	 5  J     
 5  I   ��  
  *translations+$* $DataContext.DeleteTranslationCommand� 5  8   �� 5  G   5  ?   5   ;   .��5!  K   5"  3   5#  /   ��5%  *   �� 5&  .   .R�5'  2   � * � Orientation$* 
Horizontal=�6<   + K� IsItemsHost+ . 5(  3   5)  /   5+  '   �� 5.  &   $ 
Horizontal=�61   .+�5/  *   �� $��
 Examples:��64   $��25(�6F   �� 50  *   $��Add Example��61   
������ #��[ 6`    52  .     53  2   $ Click��6A   .	 54  6     
 55  -   �� *AddExampleCommand+56  3   58  +   59  '   �� 5:  &   $ examples��6y   ��63   �� *
Examples+$  PropertyChanged=���5;  *   �� 5<  .   .R�5=  2   �� .+�5>  6   �� $
��tBox��5?  Q   $y�	Collapsed=�6:   ��5>  >   �� *Value+$  PropertyChanged=�.��5?  ]    5@  :     5A  >   $ Loaded��6M   .	 5B  B     
 5C  A   ��  �� $
 GridL�$( "DataContext.InitializeValueCommand�5E  ?   .��5F  R   5G  7   6   0typicalEnglish.Scripts.ViewModels.MvvmTextEditor  5H  6   $	��5 0q�6H   $	��600��6U   $
��Left=�6d   #���   6   $��23(�5K  [   
������ $��Disabled=�5N  @   $��Disabled=�5O  @   $��Italic$�6t   ,   Text, 5I  C   �� - �� ElementName$
- tBox��$
 Text�$  PropertyChanged=�.   
Colorizing. 5J  D   ��  �� " ��$ DataContext.Colorizing�'  !ICSharpCode.AvalonEdit.TextEditor/   
IsReadOnly/ 5L  Y   ��  �� $
 GridL�$ DataContext.IsEditing�# [ ., 5O  �   0   	Behaviors0 5P  :   ;   5typicalEnglish.Scripts.ViewModels.AvalonEditBehaviour  5Q  >   1   GiveMeTheText1 6U   �� *Value+2 �� Mode$2 TwoWay=�$  PropertyChanged=�., 5R  S   ��5S  :   �� 5T  >   " ��6D    5U  B   ^� 5V  F    5W  J   �� 5X  N    6X   ��  �� $
 GridL�$ DataContext.IsEditing�# [ 	 False5Y  y   0�5[  J   �� 5\  N    � ��$ Candara)�6k   5^  G   5`  ?   ., 5a  S    5b  :   �� 5c  >   $
��Auto��6J   .@�5d  B   m� ���#f35f5d��5e  F   �� 5f  J   $ 
Horizontal=�6U   .+�5g  N   	  $ Delete=�6Z   #���   6h   �� 5h  N   $��Delete��6X   $��4 0 0 0q�6f   #���   6w   5i  K    5k  F     5l  J   $ Click��6Y   .	 5m  N     
 5n  I   ��  
  *
examples+$&  DataContext.DeleteExampleCommand� 5o  8   �� 5p  K   5r  C   5s  ?   ., 5t  Y   5u  7   5v  3   5w  /   5y  '   5{  #   5|     5~     5     5�     5�     5�     5�     