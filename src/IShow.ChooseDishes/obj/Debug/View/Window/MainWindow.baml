   M S B A M L   `   `   `  ����M  IIShow.ChooseDishes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:IShow.ChooseDishes.ViewModelIShow.ChooseDishes.ViewModel  5   	   (    "IShow.ChooseDishes.View.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9vn*clr-namespace:IShow.ChooseDishes.ViewModel     5   	     � Title$  MasterWindow��5   	   $	��600��6   $	��800��6+    � DataContext 5   	   �� *Master+   ViewModelLocator �� Source# [  .��5      � .+�5   
   a� $
��Left=�6   $	��100��62   $	��Top=�6?   $	��792��6W    �� Orientation$ 
Horizontal=�6c   .+�5	      �� $��Button��6   $
��Left=�6&   $	��127��6A   $��98��6M   ��6Y   �� *StartPageCommand+�� 5
      $��Button��6   $	��100��6&   $	��Top=�63   $	��138��6K   ��6W   �� *ServicePageCommand+5      �� 5   
   $
��Left=�63   $	��455��6O   $��0,77,0,0q�6\   $	��Top=�6n   $	��792��6�   ��6   �� *Pages+5      �� 5   
   $
��Left=�6   $��43��6/   $��
0,532,0,-5q�6;   $	��Top=�6O   $	��792��6g   5      5      