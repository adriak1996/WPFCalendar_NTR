   M S B A M L   `   `   `  ����N  JWPFCalendarKotowski, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:WPFCalendarKotowski.ViewWPFCalendarKotowski.View  5   	   M+clr-namespace:WPFCalendarKotowski.ViewModelWPFCalendarKotowski.ViewModel  5   	   1    +WPFCalendarKotowski.View.UpdateDeleteWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:WPFCalendarKotowski.View     5   	   :vm+clr-namespace:WPFCalendarKotowski.ViewModel     5   	     � Title$  Event Explorer��5	   	   $	��400��6    $	��350��6-    � DataContext 5      5   /WPFCalendarKotowski.ViewModel.CalendarViewModel  5   
   .��5      � -   5         �Name$# CalendarViewControlEditRemove��5       � 	Resources 5   
    �� 
TargetType �� Property �� Value �� Mode��%P  '��       '�� 5    �� 5      " ��6   .�5      ��  � ��$ 0.5,0.5,0.5,0.5q�6+   �� 5       � ��
 �����60   �� 5       �@��CornerRadius$ 15,15,15,15��68   �� 5       � �� 6.   �� *	FontStyle+$ OneWay=��� 5       � �� 6/   �� *ButtonColor+$ OneWay=�5      �� 5      " ��6   .�5      ��  � ��$ 0.5,0.5,0.5,0.5q�6+   �� 5       � ��$ 1q�64   �� 5       � ��$ Center=�6?   �� 5       � ��$ Center=�6=   �� 5        � �� 6.   �� *	FontStyle+$ OneWay=�5!      5"       � RowDefinitions 5$   
   �� 5%      $
��0.5* �6   �� 5&      $��1* �6   �� 5'      $��1* �6   �� 5(      $��1* �6   �� 5)      $��1* �6   �� 5*      $��1* �6   �� 5+      $��1* �6   �� 5,      $��1* �6   �� 5-      $��1* �6   �� 5.      $��1* �6   �� 5/      $��1* �6   �� 50      $
��0.5* �6   	 � ColumnDefinitions	 53   
   �� 54      $��1* �6   �� 55      $��4* �6   �� 56      $��1* �6   .+�59   
   �� $��1��6   $��1��6    $��0.5,0.5,0.5,0.5q�6-   .��6F   Edit the beginning (HH:mm)6b   �� 5:   
   $��1��6   $��3��6    $��0.5,0.5,0.5,0.5q�6-   .��6F   Edit the the end (HH:mm)6`   �� 5;   
   $��1��6   $��5��6    $��0.5,0.5,0.5,0.5q�6-   .��6F   Edit title of the event6_   �� 5<   
   $��1��6   $��7��6    $��0.5,0.5,0.5,0.5q�6-   .��6F   Your attendance6W   �� 5=   
   $��1��6C   $��2��6S   $��0.5,0.5,0.5,0.5q�6`   ��6   �� *ChosenEvent.Start+$ TwoWay=�6{   �� 5>   
   $��1��6A   $��4��6Q   $��0.5,0.5,0.5,0.5q�6^   ��6   �� *ChosenEvent.End+$ TwoWay=�6y   �� 5?   
   $��1��6G   $��6��6W   $��0.5,0.5,0.5,0.5q�6d   ��6   �� *ChosenEvent.EventName+$ TwoWay=�6   �� 5@   
   $��1��6   $��8��6#   $��0.5,0.5,0.5,0.5q�6N   
 �� Text
 61   �� *
Attendance+.@�5A      �� 
 � Tag$	 YES��6   .��6%   YES6*   �� 5B      $ NO��6   .��6$   NO6(   5C      �� 5D   
   $��1��6   $��9��6�   $��0.5,0.5,0.5,0.5q�6�   ��6!   �� *EditEventCommand+��6G   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" �.��6�   UPDATE EVENT6�   �� 5E   
   $��1��6   $��10��6�   $��0.5,0.5,0.5,0.5q�6�   ��6"   �� *DeleteEventCommand+��6J   ��  �� $ FindAncestor=�" �.��6�   REMOVE EVENT6�   5G      5H      