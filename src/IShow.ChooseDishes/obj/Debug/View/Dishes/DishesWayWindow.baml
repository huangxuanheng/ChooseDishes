   M S B A M L   `   `   `  ����M  IIShow.ChooseDishes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:IShow.ChooseDishes.ViewModel.Common#IShow.ChooseDishes.ViewModel.Common  5   	   4    .IShow.ChooseDishes.View.Dishes.DishesWayWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Clocal1clr-namespace:IShow.ChooseDishes.ViewModel.Common     5   	     � Title$  菜品做法��5   	   $	��400��6   $	��600��6#    � DataContext 5   	   �� *	DishesWay+   ViewModelLocator �� Source# [   � 	Resources 5        TreeNodeTemplate �� DataType7   1IShow.ChooseDishes.ViewModel.Common.TreeNodeModel �� ItemsSource ��Name �� Path �� Mode	 �� 
TargetType
 �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels  TreeNodeStyle��%H  &	       7   &	 �    �� 5	   
   "  6<    6d   �� *
Children+.R�5
      �� $ TreeNodeStackPanel��6   $��2q�61   ._�5      �� $	��2,0q�5   D   ��5      �� *DishesWay.SelectedTree+8   ��5      �� ��5      �� $
 Text�$ OneTime=� 5      ���� 5      '��       "	 ��6    .�5      �� 
 �@�Cursor$
 Hand��67   �� 5      
 � ��
 �   �6;   �� 5      
 � �� 5   "   �� 5   &   " ��66   .R�5   *   �� ._�5   .   �� $ contentPresenter��6?   #��z��5      #��z��5      ��. # z 5      #��z��5      5   +   5   '   5      5       5!      5"      5#      5$      �� 5%   
   "	 Q�6&   .�5&      �� 
 �@Q�
IsExpanded 6+   �� *
Expanded+�� 5'      
 �@Q�
IsSelected 6+   �� *
Selected+5(      5*      .��5+      �  � RowDefinitions 5,   
   �� 5-      $��63 �6   �� 5.      $
��100* �6   .+�51   
   o� $
��auto��6   $
��auto��6   $
��Left=�6*   .@�52      m� $
��auto��6   $��60��6&   $��0��61    m� Command 6>   �� *Add+��53      �� 54       �� Orientation$ Vertical=�6!   .+�55      �� $<��6/IShow.ChooseDishes;component/Image/Login/americal.png��6    $��40��6`   �� 56      $��新增��6$   $
��auto��6.   $��Center=�6;   $��Center=�6V   57      59      m� 5:      $
��auto��6   $��60��6%    60   �� *UpdateDishesWayMenu+��5;      �� 5<      $ Vertical=�6!   .+�5=      �� $<��6/IShow.ChooseDishes;component/Image/Login/americal.png��6    $��40��6`   �� 5>      $��修改��6$   $
��auto��6.   $��Center=�6;   $��Center=�6V   5?      5A      m� 5B      $
��auto��6   $��60��6%    60   �� *DeleteDishesWayMenu+��5C      �� 5D      $ Vertical=�6!   .+�5E      �� $<��6/IShow.ChooseDishes;component/Image/Login/americal.png��6    $��40��6`   �� 5F      $��删除��6$   $
��auto��6.   $��Center=�6;   $��Center=�6V   5G      5I      m� 5J      $
��auto��6   $
��auto��6%    62   �� *DishesWayTypeMenu+��5K      �� 5L      $ Vertical=�6!   .+�5M      �� $<��6/IShow.ChooseDishes;component/Image/Login/americal.png��6    $��40��6`   �� 5N      $��做法类型��6$   $
��auto��60   $��Center=�6=   $��Center=�6X   5O      5Q      m� 5R      $
��auto��6   $
��auto��6%    62   �� *PingYingMenu+��5S      �� 5T      $ Vertical=�6!   .+�5U      �� $<��6/IShow.ChooseDishes;component/Image/Login/americal.png��6    $��40��6`   �� 5V      $��生成拼音简码��6$   $
��auto��62   $��Center=�6?   $��Center=�6Z   5W      5Y      m� 5Z      $
��auto��6   $
��auto��6%    62   �� *RefreshMenu+��5[      �� 5\      $ Vertical=�6!   .+�5]      �� $<��6/IShow.ChooseDishes;component/Image/Login/americal.png��6    $��40��6`   �� 5^      $��刷新��6$   $
��auto��6.   $��Center=�6;   $��Center=�6V   5_      5a      m� 5b      $
��auto��6   $
��auto��6%    62   �� *PrintedMenu+��5c      �� 5d      $ Vertical=�6!   .+�5e      �� $<��6/IShow.ChooseDishes;component/Image/Login/americal.png��6    $��40��6`   �� 5f      $��打印��6$   $
��auto��6.   $��Center=�6;   $��Center=�6V   5g      5i      m� 5j      -   5        $
��auto��5j      $
��auto��6%   ��5k      �� 5l      $ Vertical=�6!   .+�5m      �� $<��6/IShow.ChooseDishes;component/Image/Login/americal.png��6    $��40��6`   �� 5n      $��退出��6$   $
��auto��6.   $��Center=�6;   $��Center=�6V   5o      5q      5r      � 5s   
   $��1��6    � ColumnDefinitions 5t      �� 5u      $��2* �6#   �� 5v      $��8* �6#   .+�5x      R� $��0��6   $	��Top=�6'   #��[ 5y      #��[ 5z      $	��503��5{   ;   ��6   �� *FirstGeneration+5|      &   System.Windows.Controls.DataGrid  5}         AutoGenerateColumns .  $
��Left=�6_   $��2,2,0,0q�6z   $��1��6�   $	��Top=�6�   $	��310��6�   $
��auto��6�      CanUserAddRows .  ��63   �� *DishesWayTableItems+ �� SelectedItem 6�   �� *DishesWaySelectedItem+   Columns 5~      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6M      Header$ 行号��6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� $ 
LineNumber�6Z     5�      $
 auto 6H   $ 编码��6W    6)   �� $
 Code�6W     5�      $
 auto 6H   $ 做法说明��6V    6)   �� $
 Name�6V     5�      $
 auto 6R   $ 类型��6`    6)   �� $ DischesWayName�6`     5�      $
 auto 6L   $ 拼音简码��6Z    6)   �� $ PingYing�6Z     5�      $
 auto 6L   $ 加价��6Z    6)   �� $ AddPrice�6Z   4  .System.Windows.Controls.DataGridCheckBoxColumn  5�      $
 auto 6V   $ 按数量加价��6c      
IsReadOnly .  6-   �� $ addPriceByNum�6r   5�      5�      5�      5�      