   M S B A M L   `   `   `  ����I  EHealth Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Health_TrackerHealth_Tracker  5   	   "    Health_Tracker.YourDayWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Health_Tracker     5   	     � Title$  YourDay��5   	   $	��450��6   $	��800��6&    � WindowState$ 	Maximized=�5	   	    � WindowStyle$
 None=�5
   	   .��5      �� .+�5   
   o� $	��800��6   
 �� Top$ 50��6   ���#19959F
���������5      �� 5      .R�5      $�  $� Orientation$ Vertical=�6-   5      .@�5      m� -   5        $
��Food��5      $	��150��6%   $��Runda Light)�6L   m� 5      -   5        $��Exercise��5      $	��150��6)   $��Runda Light)�6T   m� 5      -   5        $��ExerciseCalendar��5      $	��150��61   $��Runda Light)�6d   m� 5      -   5        $��
Your Goals��5      $	��150��6+   $��Runda Light)�6W   5      �� 5   
   -   5         ��Name$ 
BackButton��5      $ 10��6%    �� Left$ 10��65   
�������
�������.��5      �� $E��?C:\Users\anush\source\repos\health-tracker\Images\BackArrow.png��6   $��30��6]   5      �� 5   
   -   5         ��Name$ YourDayTitleLabel��5      $��Your Day��6+   $ 10��6>   $	 580��6N   $��Runda)�6`   $��25(�6s   ���#19959F6�   �� 5   
   -   5        $ MealsTitleLabel��5      $��
Your Meals��6)   $ 75��6>   $	 300��6N   $��Runda Light)�6`   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ BreakfastCol��5      $	��125��6)   $ 75��65   $	 400��6E   	   AutoGenerateColumns$	 False��6W   $��Runda)�6s   
�������$��0q�6�   
   VerticalGridLinesBrush

 �����   HorizontalGridLinesBrush �#19959F   
IsReadOnly$
 True��6�      Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Breakfast��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 68      
FontFamily$ Runda Light)�6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *mealDetails+6b   5#        5$   
   -	   5        $ LunchCol��5$      $	��125��6%   $ 75��61   $	 525��6A   $	 False��6S   $��Runda)�6o   
�������$��0q�6�   

 ����� �#19959F$
 True��6�    5%        5&      $ Lunch��6%   $ * 64   $ Runda Light)�6^    6>   �� *mealDetails+6^   5(        5)   
   -
   5        $ 	DinnerCol��5)      $	��125��6&   $ 75��62   $	 650��6B   $	 False��6T   $��Runda)�6p   
�������$��0q�6�   

 ����� �#19959F$
 True��6�    5*        5+      $ Dinner��6%   $ * 65   $ Runda Light)�6_    6?   �� *mealDetails+6_   5-        5.   
   -   5        $ SnackCol��5.      $	��125��6%   $ 75��61   $	 775��6A   $	 False��6S   $��Runda)�6o   
�������$��0q�6�   

 ����� �#19959F$
 True��6�    5/        50      $ Snack��6%   $ * 64   $ Runda Light)�6^    6>   �� *mealDetails+6^   52      �� 54   
   -   5        $ ExerciseTitleLabel��54      $��	Exercises��6,   $	 200��6@   $	 300��6Q   $��Runda Light)�6c     55   
   -   5        $ ExercisesTable��55      $	��500��6+   $	 200��67   $	 400��6H   $	 False��6Z   $��Runda)�6v   
�������$��0q�6�   

 ����� �#19959F$
 True��6�    56        57      $
 Name��6%   $ * 63   $ Runda Light)�6^    6=   �� *exerciseName+6^     58      $ Details��6%   $ * 66   $ Runda Light)�6d    6@   �� *exerciseDetails+6d     59      $
 Time��6%   $ * 63   $ Runda Light)�6^    6=   �� *exerciseTime+6^   5;      5=      5>      