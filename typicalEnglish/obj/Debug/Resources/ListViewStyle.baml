   M S B A M L   `   `   `  ����I  EtypicalEnglish, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:typicalEnglish.ResourcestypicalEnglish.Resources  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ListViewStyle  �� 
TargetType �� Property �� Value �� 
TargetType �� Color �� Triggers P� Property P� Value ]� 
Conditions	 �� Property
 �� Value �� 
TargetName �� BasedOn �� Triggers  
Foreground �� UpdateSourceTrigger ��Name �� Padding J� SnapsToDevicePixels'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� 
TargetName �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      0local&clr-namespace:typicalEnglish.Resources  5      %�
  &	        '�� �    7���� 5      "  ��5      .�5   
   ��  �@J�SnapsToDevicePixels . 5	      �� 5
   
    �@�OverridesDefaultStyle . 5      �� 5   
    � ��$
 Auto=�5      �� 5   
    � ��$
 Auto=�5      �� 5   
    � �� . 5      �� 5   
    � ��$ Center=�5      �� 5   
    � ��$ Stretch=�67   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� $��Border��6   $��0q�5      ��5      �� 5      $ Transparent��6.   ��5      �� 5      $ Transparent��6.   ._�5       �� #��� $�6'   .��5"      �� 5#      5$       5%      P� 5&       �@��
IsGrouping . . �5(      ��  � �� .  5)      5*      ]� 5+       5,      �� 5-   "   	 � {�
 .  6B   /�5/      �� 50   "    � ��
 �����6?   �� 51   "   $ Border��6)    � �� 53   &   �� 54   *   $ Transparent��6:   56   #   59      5;      5=      5>      �� 5?      "  ��5@      8    5A   
   P� 5B       �@J�IsMouseOver . . �5C      ��  �@�Cursor$
 Hand��6+   5D      P� 5F       �@��
IsSelected . . �5G      ��  � ��
 �   �60   �� 5H       � ��$	 0.2q�64   �� 5I       � ��
 �   �6/   5J      P� 5L       �@��
IsSelected .  . �5M      ��  � ��# �  6/   5N      .�5R   
   ��  � ��$ Center=�65   �� 5S   
    � ��$ Stretch=�60   �� 5T   
    � ��$ Stretch=�67   �� 5U   
    � ��$ 17(�6%   �� 5V   
    �@J�SnapsToDevicePixels . 5W      �� 5X   
    �@��
IsSelected 6'   �� *
IsSelected+$ PropertyChanged=��� 5Y   
    �@�OverridesDefaultStyle . 5Z      �� 5[   
    � �� 5\      �� 5]      " ��6"   .R�5^      �� $ Border��6   $ 2q�5_      #��z��6   #��z��6I    . 
������  5b        5c      CommonStates��. 5d   "     
Normal��6.     5e   "   	MouseOver��6.     5f   "   Disabled��6.   5g        5h      SelectionStates��. 5i   "     
Unselected��6.     5j   "   Selected��. 5k   &   �� .��5l   *   �� $ Border��6G   $E ?(Panel.Background).                     (SolidColorBrush.Color)�5m   1   .g�5o   .     $ 0��6B   $ #e9ebec��5p   *   5q   +   5r   '   5s   #     5t   "   SelectedUnfocused��. 5u   &   �� .��5v   *   �� $ Border��6G   $E ?(Panel.Background).                     (SolidColorBrush.Color)�5w   1   .g�5y   .     $ 0��6B   $ #e9ebec��5z   *   5{   +   5|   '   5}   #   5~      ._�5�      �� #��z��6/   5�      5�      5�      5�      5�      