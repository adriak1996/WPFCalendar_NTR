   M S B A M L   `   `   `  ����N  JWPFCalendarKotowski, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:WPFCalendarKotowski.ViewModelWPFCalendarKotowski.ViewModel  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   $    WPFCalendarKotowski.View.PopUp   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :vm+clr-namespace:WPFCalendarKotowski.ViewModel     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	     � Title$  Visual Settings��5	   	   $	��300��6!   $	��300��6.    � DataContext 5      5   /WPFCalendarKotowski.ViewModel.CalendarViewModel  5   
   .��5      �  � 	Resources 5   
    �� 
TargetType �� Property �� Value �� Mode��%P  '��       '�� 5    �� 5      " ��6   .�5      ��  � ��$ 0.5,0.5,0.5,0.5q�6+   �� 5       � ��
 �����60   �� 5       �@��CornerRadius$ 15,15,15,15��68   �� 5       � �� 6.   �� *	FontStyle+$ OneWay=��� 5       � �� 6/   �� *ButtonColor+$ OneWay=�5      �� 5      " ��6   .�5      ��  � ��$ 0.5,0.5,0.5,0.5q�6+   �� 5       � ��$ 1q�64   �� 5       � ��$ Center=�6?   �� 5       � ��$ Center=�6=   �� 5       � �� 6.   �� *	FontStyle+$ OneWay=�5      5        � ColumnDefinitions 5"   
   �� 5#      $��1* �6   �� 5$      $��2* �6   �� 5%      $��2* �6   �� 5&      $��2* �6   �� 5'      $��1* �6    � RowDefinitions 5*   
   �� 5+      $
��0.5* �6   �� 5,      $��1* �6   �� 5-      $��1* �6   �� 5.      $
��0.5* �6   �� 5/      $��1* �6   �� 50      $��1* �6   �� 51      $
��0.5* �6   .+�54   
   �� $"��Set color style for calendar��6   $��1��67   $��1��6G   $��0,0,0,1q�6T   $��3��6e   6{   �� 55   
   $��Azure��6   $��1��6!   $��2��61   
�������$��0,0,0,1q�6Q   ��6b   �� *GetAzureCSS+6�   �� 56   
   $
��Gold��6   $��2��6    $��2��60   
��� ���$��0,0,0,1q�6O   ��6`   �� *
GetGoldCSS+6�   �� 57   
   $��
LightGreen��6   $��3��6&   $��2��66   
������$��0,0,0,1q�6[   ��6l   �� *GetGreenCSS+6�   �� 59   
   $!��Set font style for calendar��6   $��1��66   $��4��6F   $��0,0,0,1q�6S   $��3��6e   6{   �� 5:   
   -   5        	 ��Name$	 b1��5:      $��Normal��6   $��1��6.   $��5��6>   $��Normal$�6K   $��0,0,0,1q�6^   ��6o   �� *	GetNormal+6�   �� 5;   
   -   5        $	 b2��5;      $��Italic��6   $��2��6.   $��5��6>   $��Italic$�6K   $��0,0,0,1q�6^   ��6o   �� *
GetItalics+6�   �� 5<   
   -   5        $	 b3��5<      $��Oblique��6   $��3��6/   $��5��6?   $��Oblique$�6L   $��0,0,0,1q�6`   ��6q   �� *
GetOblique+6�   5>      5?      