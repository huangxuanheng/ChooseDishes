   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      G CIShow.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:IShow.Common.ControlsIShow.Common.Controls 5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089)   #IShow.Common.Controls.BusyIndicator  �� 
TargetType �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� 	BeginTime g� Duration	 �� 
TargetName
 �� TargetProperty R� KeyTime R� Value  System.Windows.Visibility ��Name ��Name    OverlayStyle ��Name �� CornerRadius �� 
StartPoint �� EndPoint � Color � Offset � RowDefinitions    BusyContent    BusyContentTemplate    ProgressBarStyle�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      .sys&clr-namespace:System;assembly=mscorlib  5      -local#clr-namespace:IShow.Common.Controls  5      %�  '         �� 5      "    6   .�5	   
   ��  �@  BusyContent$	 ...��6(   �� 5
   
    � �� .  6&   �� 5   
    � |� .  6&   �� 5   
    �@  OverlayStyle 5      �� 5      "  ��6   .�5      ��  � ��
 �����6-   �� 5       �@J�Opacity$	 0.5Q�60   5      5      �� 5   
    �@  ProgressBarStyle 5      �� 5      "  �6   .�5      ��  �@�IsIndeterminate . 68   �� 5       � ��$ 15��6/   �� 5       � ��$ 8,0,8,8q�6/   5      5      �� 5   
    �@  DisplayAfter$ 
00:00:00.1h�6)   �� 5   
    � ��$ Stretch=�60   �� 5   
    � ��$ Stretch=�6.   �� 5    
    � ��$ Stretch=�67   �� 5!   
    � ��$ Stretch=�65   �� 5"   
    � �� 5#      �� 5$      "   6"   .R�5%      �  5&        5'      VisibilityStates��. 5(   "     
Hidden��. 5)   &   �� .��5*   *   T� $ 00:00:00X�6H   $ 00:00:00.001D�6]   $	 busycontent��6u   $
 (UIElement.Visibility)�6�   ..�5+   .   i� $ 00:00:00��6E    5,   2    5-   6   	Collapsed=�6L   5/   /   50   +   T� 51   *   $ 00:00:00X�6H   $ 00:00:00.001D�6]   $	 overlay��6u   $
 (UIElement.Visibility)�6�   ..�52   .   i� $ 00:00:00��6E    53   2    54   6   	Collapsed=�6L   56   /   57   +   58   '   59   #     5:   "   Visible��. 5;   &   �� .��5<   *   T� $ 00:00:00X�6H   $ 00:00:00.001D�6]   $	 busycontent��6u   $
 (UIElement.Visibility)�6�   ..�5=   .   i� $ 00:00:00��6E    5>   2    5?   6   Visible=�6J   5A   /   5B   +   T� 5C   *   $ 00:00:00X�6H   $ 00:00:00.001D�6]   $	 overlay��6u   $
 (UIElement.Visibility)�6�   ..�5D   .   i� $ 00:00:00��6E    5E   2    5F   6   Visible=�6J   5H   /   5I   +   5J   '   5K   #   5L        5M      BusyStatusStates��. 5N   "     Idle��. 5O   &   �� .��5P   *   T� $ 00:00:00X�6H   $ 00:00:00.001D�6]   $	 content��6u   $
 (Control.IsEnabled)�6�   ..�5Q   .   i� $ 00:00:00��6E    5R   2   ��5S   6   True��6H   5U   /   5V   +   5W   '   5X   #     5Y   "   Busy��. 5Z   &   �� .��5[   *   T� $ 00:00:00X�6H   $ 00:00:00.001D�6]   $	 content��6u   $
 (Control.IsEnabled)�6�   ..�5\   .   i� $ 00:00:00��6E    5]   2   ��5^   6   	False��6I   5`   /   5a   +   5b   '   5c   #   5d      .+�5f      �� $ content��6)   #��z��6:   #��z��6^   #��z��6�   #��z��6�   ��.  |�.  64  �� 5g      $ overlay��6$   #��z 65   �� 5h      $ busycontent��6+   ��5i      � 5j   "   $��Center=�6'   $��Center=�6D   .+�5k   &   �� 
�������$��1q�6@   $ 2��6T   ��5l   *   �� 5m   .   $ 0.5,0&�6B   $ 0.5,1&�6U   .��5n   2   � $ 	#FFA3AEB9��6?   $ 0Q�6Q   � 5o   2   $ 	#FF8399A9��6?   $ 0.375Q�6Q   � 5p   2   $ 	#FF718597��6?   $ 0.375Q�6Q   � 5q   2   $ 	#FF617584��6?   $ 1Q�6Q   5r   /   ._�5t   *   �� $	 1.5��61   $��1q�6D   ��5u   .   �� 5v   2   $ 0.5,0&�6F   $ 0.5,1&�6Y   .��5w   6   � $ 	#FFF6F8F9��6C   $
 0.02Q�6U   � 5x   6   $ 	#FFB8B8B8��6C   $ 0.996Q�6U   5y   3   ._�5{   .   � $	��150��63    5|   2   �� 5}   6   �� 5~   6   $
��Auto �6D   .+�5�   2   �� #��z 6C   #��z 6k   $��8q�6�   � 5�   2   $��1��6>   #��z 6K   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      