   M S B A M L   `   `   `  ����I  EHealth Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Health_TrackerHealth_Tracker  5   	   +    %Health_Tracker.ExerciseCalendarWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Health_Tracker     5   	     � Title$  ExerciseCalendar��5   	   $	��450��6"   $	��800��6/    � WindowState$ 	Maximized=�5	   	    � WindowStyle$
 None=�5
   	   .��5      �� .+�5   
   o� $	��800��6   
 �� Top$ 50��6   ���#19959F
���������5      �� 5      .R�5      $�  $� Orientation$ Vertical=�6-   5      .@�5      m� -   5        $
��Food��5      $	��150��6%   $��Runda Light)�6L   m� 5      -   5        $��Exercise��5      $	��150��6)   $��Runda Light)�6T   m� 5      -   5        $��Your Day��5      $	��150��6)   $��Runda Light)�6S   m� 5      -   5        $��
Your Goals��5      $	��150��6+   $��Runda Light)�6W   5      �� 5   
   -   5         ��Name$ 
BackButton��5      $ 10��6%    �� Left$ 10��65   
�������
�������.��5      �� $E��?C:\Users\anush\source\repos\health-tracker\Images\BackArrow.png��6   $��30��6]   5      �� 5   
   -   5         ��Name$ 	MonthName��5      $ 10��6#   $	 530��63   $��Runda)�6E   $��40(�6X   ���#19959F6f   � 5   
   -   5         �Name$ CalendarGrid��5      $	��910��6%   $	��600��61   $ 75��6>   $	 170��6N   	 � ShowGridLines$	 False��6`   
 � ColumnDefinitions
 5      �� 5       $��* �6#   �� 5!      $��* �6#   �� 5"      $��* �6#   �� 5#      $��* �6#   �� 5$      $��* �6#   �� 5%      $��* �6#   �� 5&      $��* �6#    � RowDefinitions 5(      �� 5)      $��* �6    �� 5*      $��* �6    �� 5+      $��* �6    �� 5,      $��* �6    �� 5-      $��* �6    �� 5.      $��* �6    50      � 52   
   -   5         �Name$ ExerciseDetailsPopup��52      $	��200��6.   $	 100��6:   $	 100��6K   $��False��6]    � AllowsTransparency$
 True��6l   $��Center=�6�   53      54      