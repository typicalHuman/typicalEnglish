   M S B A M L   `   `   `  ����I  EtypicalEnglish, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:typicalEnglishtypicalEnglish  5   	       typicalEnglish.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:typicalEnglish     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=null:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   -   5          � Title$  typicalEnglish��5
   	   $	��450��6    $	��900��60      typicalEnglish.App   MainVM � DataContext# Z 5   	    � WindowStyle$
 None=�5   P   ���#686868 � AllowsTransparency . $��Candara Light)�5   !    � WindowState 5   	   �� *WindowState+ � 
ResizeMode 5   	   �� *
ResizeMode+ �� UpdateSourceTrigger$ PropertyChanged=���5      �� *WindowBorderThickness+$ PropertyChanged=�'  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
   	   CaptionHeight$	 0Q�5   	   
   ResizeBorderThickness$
 5q�5   	   .��5      �    PanelBackground#���   6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��40 �6   �� 5       � ColumnDefinitions 5   
   �� 5       �� 5!      �� 5"      .+�5'   
   �� $��typicalEnglish��6   
������� K� ZIndex$ 1��6=   $
��Left=�5(      $��Center=�6/   $��20(�5)      $	��5 0q�6"   ]� 5-   
   $��5��6   ���#051e3e � 	Resources 5.       �� 
TargetType �� BasedOn �� Property �� Value��%�   '��       7���� 50      " ��6   8   .�51      ��  � ��$ 3,0,7,0q�6/   �� 52       � ��$ Right=�67   �� 53       � ��$ 25��6/   �� 54       � ��$ 25��6.   55      56      .+�58      �� ���#f35f5d  CircularButton#��[ 6*   ���#ec4c45 � ToolTip$ Close��59   +     
Foreground#���  6;   .  (System.Windows.Interactivity.Interaction   Triggers 5:      /  )System.Windows.Interactivity.EventTrigger  5;         	EventName$ Click��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5<      6  0System.Windows.Interactivity.InvokeCommandAction     Command 60   �� *CloseCommand+5=      5?      �� 5B      ���#febf34#��[ 6*   ���#e8a61c$
 Hide��5C      #���  6$    5D        5E      $ Click��6%   . 5F         60   �� *MinimizeCommand+5G      5I      �� 5L      ���#01c74c#��[ 6*   ���#15b329$��Right=�5M      $ Maximize��61   #���  6D    5N        5O      $ Click��6%   . 5P         60   �� *MaximizeCommand+5Q      ��5S      �� 5T      " ��6   # [B��60    �� Triggers 5U      �� 5V       �� Binding 6*   ��  �� RelativeSource ��  �� AncestorType$ WindowL� �� Path$ WindowState� �� Value
 Normal5W   *   .a�5X   "   ��  �@�ToolTip$ Maximize��6<   5Y      �� 5Z       6*   ��  �� $ WindowL�$ WindowState� 	Maximized5[   *   .a�5\   "   ��  �@�ToolTip$ Restore Down��6<   5]      5_      5a      5c      �� 5i   
   $��Decks��6   $
��Bold"�6!     
DecksBrush#���  63   $��1��6]   $	��Top=�6j   $��17(�5j      $��Stretch=�6    $��40��6?   
������ $��0q�5k      #���  6%    5l        5m      $ Click��6!   . 5n           CommandParameter$" Scripts/Views/DecksPage.xaml��5o   8    5n   ,   �� *PageNavigateCommand+5o   8   5p      5r      �� 5v   
   $
��Test��6   $
��Bold"�6!   $��1��63     	TestBrush#���  6C   $��1��6m   $	��Top=�6z   $��17(�5w      $��Stretch=�6    $��40��6?   
������ $��0q�5x      #���  6%    5y        5z      $ Click��6!   . 5{        $! Scripts/Views/TestPage.xaml��5|   8    5{   ,   �� *PageNavigateCommand+5|   8   5}      5      �� 5�   
   $��Options��6   $
��Bold"�6#   $��3��65     OptionsBrush#���  6E   $��1��6q   $	��Top=�6~   $��17(�5�      $��Stretch=�6    $��40��6>   
������ $��0q�5�      #���  6%    5�        5�      $ Click��6!   . 5�        $$ Scripts/Views/OptionsPage.xaml��5�   8    5�   ,   �� *PageNavigateCommand+5�   8   5�      5�       � 5�   
   -   5          �Name$ Frame1��5�   0      � NavigationUIVisibility$  Hidden=�6   !  � Source$! DecksPage.xaml?�5�      $��0 5 0 0q�6(   $��2��5�      $��4��6   63   5�      5�      