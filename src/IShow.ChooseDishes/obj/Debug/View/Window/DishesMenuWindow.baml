   M S B A M L   `   `   `  ����M  IIShow.ChooseDishes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:IShow.ChooseDishes.ViewModel.Common#IShow.ChooseDishes.ViewModel.Common  5   
   .    (IShow.ChooseDishes.View.DishesMenuWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @vn1clr-namespace:IShow.ChooseDishes.ViewModel.Common     5   
     � Title$  菜牌管理��5   	   $��600.788��6   $��910.075��6'    � DataContext 5   	   �� *
DishesMenu+   ViewModelLocator �� Source# [   � 	Resources 5        TreeNodeTemplate �� DataType7   1IShow.ChooseDishes.ViewModel.Common.TreeNodeModel �� ItemsSource ��Name �� Path �� Mode	 �� 
TargetType
 �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels  TreeNodeStyle��%I  &	       7   &	 �    �� 5	   
   "  6<    6a   �� *
Children+.R�5
      �� $ TreeNodeStackPanel��6   $��2q�61   ._�5      �� $	��2,0q�5   D   ��5      �� *DishesMenu.SelectedTree+8   ��5      �� ��5      �� $
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
Selected+5(      5*      .��5+      �  � ColumnDefinitions 5,   
   �� 5-      $
��206* �6   �� 5.      $
��245* �6   .+�50   
   c� $
��Left=�6   $	��Top=�6-   $��63��6E   $	��899��6Q   $��2��6]   .@�51      �� $��新增类型��6   $��58��6$   $	��Top=�60   $��75��6H   ��6S   �� *
AddCommand+�� 52      $��选择菜品��6   $��58��6$   $	��Top=�60   $��75��6H   ��6S   �� *UpdateSelectCommand+�� 53      $��删除菜品��6   $��58��6$   $	��Top=�60   $��75��6H   ��6S   �� *DeleteCommand+�� 54      -   5        $��退出��54      $��58��63   $	��Top=�6?   $��75��6W   55      R� 56   
   -   5        $
��Left=�56      $	��500��6.   $��0,68,0,0q�6;   $	��Top=�6N   $	��222��6f   #��[ 6r   #��[ 6�   ��6�   �� *DishesMenus+6�   &   System.Windows.Controls.DataGrid  57   
      AutoGenerateColumns .     
IsReadOnly .     CanUserAddRows .  $
��Left=�6�   $��
227,68,0,0q�6�   $	��Top=�6�   $	��503��6�   $	��672��6�   $��2��6
  ��6]   �� *	DishItems+ �� SelectedItem 6�   �� *SelectedDishes+   Columns 58      4  .System.Windows.Controls.DataGridCheckBoxColumn  59      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6;      Header$ 选项��6j   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *IsSelectedMenus+6j   0  *System.Windows.Controls.DataGridTextColumn  5:       . $	 160 6Z   $ 菜谱类型��6h    68   �� *DishMenusName+6h     5;       . $	 100 6T   $ 菜品编号��6a    69   �� *DishId+6a     5<       . $ 80 6V   $ 品名��6b    69   �� *
DishName+6b     5=       . $	 100 6X   $ 规格��6e    69   �� *
DishFormat+6e     5>       . $ 80 6Z   $ 单位��6f    69   �� *DishUnitName+6f   5@      5B      5C      