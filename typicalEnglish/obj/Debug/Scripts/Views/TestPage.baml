   M S B A M L   `   `   `  ����I  EtypicalEnglish, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:typicalEnglishtypicalEnglish  5      U/clr-namespace:typicalEnglish.Scripts.ViewModels!typicalEnglish.Scripts.ViewModels  5	      +    %typicalEnglish.Scripts.Views.TestPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:typicalEnglish     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=null:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      8vm/clr-namespace:typicalEnglish.Scripts.ViewModels  5	        N� Title$  TestPage��5       N� 
FontFamily$ Candara Light)�6    N� FontSize$ 20(�63      
Foreground N� 
Foreground# �   6A   .��5      � $��0 10 0 0q�6      typicalEnglish.App   
TestPageVM � DataContext# Z 6    � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      .+�5   
   �� $��Center=�6   $	��Top=�6.   
������ $��70��5      $	��150��6   $��25(�6)     ButtonBorderBrush#���  5      #���   6C   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ Click��6!   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6,   �� *StartTestCommand+5      ��5      �� 5       �� 
TargetType" ��6     InvisButton �� BasedOn# [ 6,    �� Triggers 5      �� 5        �� Binding 6&   �� *
IsDeckPage+ �� UpdateSourceTrigger$ PropertyChanged=� �� Value True5!   &   .a�5"      ��  �� Property � �� �� Value$
 Open��68   5#      �� 5$       6&   �� *
IsDeckPage+$ PropertyChanged=�	 False5%   &   .a�5&      ��  � ��$ Start��68   5'      �� 5(       6&   �� *Decks.Count+$ PropertyChanged=� 05)   &   .a�5*      ��  � {� .  6:   5+      ^� 5,       ^� 
Conditions 5-      �� 5.   "    �� Binding 6,   �� *	IsEmpty+$ PropertyChanged=� �� Value True5/   &   �� 50   "    6,   �� *
IsDeckPage+$ PropertyChanged=�	 False51   &   .0�53      ��  � {� .  6:   54      56      58      �� 5=   
   $��Right=�6   $	��5 0q�61    �� Orientation$ 
Horizontal=�6>   .+�5A      �� $��40��6   $��50��6!   $	��5 0q�6,   
������  � ToolTip$ Change language��5C   ?   #���   5D      ��5C      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Language=�   Size$ 20X���5E      �� 5F      " ��6   # [ 60    5G      �� 5H       6*   �� *
IsDeckPage+$ PropertyChanged=� True5I   *   .a�5J   "   ��  � y�$ Hidden=�6?   5K      5M       5O        5P      $ Click��6%   .	 5Q        
 60   �� *ChangeLanguageCommand+5R      5T      �� 5W      $��40��6   $��50��6!   $	��5 0q�6,   #��[ 5X      
������ $ 
Select All��5Y   @   #���   5Z      ��5Y        $ 	SelectAll=�$ 20X� 5[        5\      $ Click��6%   .	 5]        
 60   �� *SelectAllCommand+5^      5`      5b      �� 5g   
   $
��Left=�6   $��Center=�60   $ 
Horizontal=�5h      $	��5 0q�6.   .+�5j      ��  5k        5l      $ Click��6%   .	 5m        
 60   �� *BackCommand+5n      ��5p      �� 5q      " ��6     
BackButton# [ 60    5r      �� 5s       6*   �� *Source+$ PropertyChanged=� SelectDecksPage.xaml5t   *   .a�5u   "   ��  � y�$ 	Collapsed=�6?   5v      5x      5z      �� 5      $��40��6   $��50��6!   $��Right=�6,   #��[ 5�      
������ #���   6O   #���  5�      $ More option��5�   ?   ��6     $ MoreVert=�$ 20X� 5�        5�      $ Click��6%   .	 5�        
 60   �� *ChangeVisibilityCommand+5�      5�      �� 5�      $ 
Horizontal=�6   $
��10 0q�5�      y�5�   2   �� *MoreVisibility+$ PropertyChanged=�.+�5�      �� $��40��6   $��20(�6%   #���   63   #���  5�      #��[ 5�      
������ $��Select first��5�       5�        5�      $ Click��6)   .	 5�        
 64   �� *SelectFirstCommand+   CommandParameter 5�   0   ��  �� ElementName$ wordsNumber�� �� Path$
 Text�5�      5�      �� 5�      -   5        $��wordsNumber��5�   (   $��30��5�      $
��10 0q�6(    �� 	MaxLength$ 7��5�      $
��Auto��6;   $��Center=�6I   #���   5�      #���   6D   �� 5�      $��Center=�6   $	��5 0q�67   #���   6D   ��5�      �� 5�      " ��6     5�      �� 5�   "    6.   �� *Source+$ PropertyChanged=� SelectDecksPage.xaml5�   .   .a�5�   &   ��  � ��$ decks��6=   5�   #   �� 5�   "    6.   �� *Source+$ PropertyChanged=� SelectWordsPage.xaml5�   .   .a�5�   &   ��  � ��$ words��6=   5�   #   5�      5�      5�      5�       � 5�   
   -   5          �Name$ Frame2��5�   0     � NavigationUIVisibility$ Hidden=�6   $	��0 5q�5�   O   $��2��5�         � Source  5�      �� *Source+$ PropertyChanged=�5�      5�      5�      