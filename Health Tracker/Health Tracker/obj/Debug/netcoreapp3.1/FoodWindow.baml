   M S B A M L   `   `   `  ����I  EHealth Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Health_TrackerHealth_Tracker  5   	       Health_Tracker.FoodWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Health_Tracker     5   	     � Title$
  Food��5   	   $	��450��6   $	��800��6#    � WindowState$ 	Maximized=�5	   	    � WindowStyle$
 None=�5
   	   .��5      �� .+�5   
   o� $	��800��6   
 �� Top$ 50��6   ���#19959F
���������5      �� 5      .R�5      $�  $� Orientation$ Vertical=�6-   5      .@�5      m� -   5        $��Exercise��5      $	��150��6)   $��Runda Light)�6T   m� 5      -   5        $��Exercise Calendar��5      $	��150��62   $��Runda Light)�6e   m� 5      -   5        $��Your Day��5      $	��150��6)   $��Runda Light)�6S   m� 5      -   5        $��
Your Goals��5      $	��150��6,   $��Runda Light)�6X   5      �� 5   
   -   5         ��Name$ 
BackButton��5      $ 10��6%    �� Left$ 10��65   
�������
�������.��5      �� $E��?C:\Users\anush\source\repos\health-tracker\Images\BackArrow.png��6   $��30��6]   5      �� 5   
   -   5        $ AddMealButton��5      $��40��6(   $��40��63   $ 50��6?   $	 410��6O   
�������$��0q�6�   .��5      �� $C��=C:\Users\anush\source\repos\health-tracker\Images\AddMeal.png��6   $��30��6[   5      �� 5    
   -   5         ��Name$ AddMealLabel��5       $��Add Meal��6&   $	 100��69   $	 400��6J   $��Runda Light)�6\   ���#19959F6u   �� 5"   
   -   5        $ ViewMealsButton��5"      $��40��6*   $��40��65   $ 50��6A   $	 815��6Q   
�������$��0q�6�   .��5#      �� $E��?C:\Users\anush\source\repos\health-tracker\Images\ViewMeals.png��6   $��30��6]   5$      �� 5%   
   -	   5        $ ViewMealsLabel��5%      $��
View Meals��6(   $ 98��6=   $	 799��6M   $��Runda Light)�6_   ���#19959F6x   �� 5'   
   -
   5        $ AddMealsTitle��5'      $��Add Meal��6'   $ 10��6:   $	 590��6J   $y�Hidden=�6\   $��Runda)�6p   $��20(�6�   ���#19959F6�   �� 5(   
   -   5        $ 	ChooseDay��5(      $
��Day:��6#   $ 50��62   $	 380��6B   $y�Hidden=�6T   $��Runda Light)�6h   �� 5)   
   -   5         ��Name$ WeekDays��5)      $��480, 57, 0, 0q�6%   .+�5*      	� -   5        	 	�Name$	 	MondayBox��5*      $��Monday��6-   $ 27��6>   $	 150��6N   $y�Hidden=�6`   $��Runda Light)�6�   	� 5+      -   5        $	 
TuesdayBox��5+      $��Tuesday��6.   $ 27��6@   $	 250��6P   $y�Hidden=�6b   $��Runda Light)�6�   	� 5,      -   5        $	 WednesdayBox��5,      $��	Wednesday��60   $ 27��6D   $	 350��6T   $y�Hidden=�6f   $��Runda Light)�6�   	� 5-      -   5        $	 ThursdayBox��5-      $��Thursday��6/   $ 27��6B   $	 450��6R   $y�Hidden=�6d   $��Runda Light)�6�   	� 5.      -   5        $	 	FridayBox��5.      $��Friday��6-   $ 27��6>   $	 550��6N   $y�Hidden=�6`   $��Runda Light)�6�   	� 5/      -   5        $	 SaturdayBox��5/      $��Saturday��6/   $ 27��6B   $	 650��6R   $y�Hidden=�6d   $��Runda Light)�6�   	� 50      -   5        $	 	SundayBox��50      $��Sunday��6-   $ 27��6>   $	 750��6N   $y�Hidden=�6`   $��Runda Light)�6�   51      �� 53   
   -   5        $ 
ChooseMeal��53      $��Meal:��6$   $	 100��64   $	 380��6E   $y�Hidden=�6W   $��Runda Light)�6l   	� 54   
   -   5        $	 BreakfastBox��54      $��	Breakfast��6,   $	 107��6@   $	 480��6Q   $y�Hidden=�6c   $��Runda Light)�6�   	� 55   
   -   5        $	 LunchBox��55      $��Lunch��6(   $	 107��68   $	 580��6I   $y�Hidden=�6[   $��Runda Light)�6�   	� 56   
   -   5        $	 	DinnerBox��56      $��Dinner��6)   $	 107��6:   $	 660��6K   $y�Hidden=�6]   $��Runda Light)�6�   	� 57   
   -   5        $	 SnackBox��57      $��Snack��6(   $	 107��68   $	 760��6I   $y�Hidden=�6[   $��Runda Light)�6�   �� 59   
   -   5        $ MealDetailsLabel��59      $��Meal Details��6*   $	 150��6A   $	 380��6R   $y�Hidden=�6d   $��Runda Light)�6x   �� 5:   
   -   5        
 ��Name$
 MealDetailsInput��5:      $	��300��6,   $	 150��68   $	 480��6I   $y�Hidden=�6[   $��Runda Light)�6o   �� 5<   
   -   5        $ OKButton��5<      $��OK��6#   $	 200��60   $	 640��6A   $y�Hidden=�6S   $��Runda Light)�6|   ���#19959F$��0q�6�   &   System.Windows.Controls.DataGrid  5>   
   -   5          Name$ 
AddedMeals��5>      $	��300��6'   $	��400��64   $	 250��6@   $	 460��6Q   $y�Hidden=�6c      AutoGenerateColumns$ False��6w   $��Runda)�6�   
�������$��0q�6�      VerticalGridLinesBrush
 �����   HorizontalGridLinesBrush �#19959F   
IsReadOnly$
 True��6     Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$	 Day��6/      
FontFamily$ Runda Light)�6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *	dayOfMeal+6Z     5A      $ * 6%   $
 Name��6/   $ Runda Light)�6Z    6=   �� *
mealName+6Z     5B      $ * 6%   $ Details��6/   $ Runda Light)�6`    6@   �� *mealDetails+6`   5D      �� 5F   
   -   5        $ ViewMealsTitle��5F      $��	All Meals��6(   $ 10��6<   $	 590��6L   $y�Hidden=�6^   $��Runda)�6r   $��20(�6�   ���#19959F6�     5H   
   -   5        $ 	MondayCol��5H      $	��500��6&   $	��150��63   $ 70��6?   $	 150��6O   $y�Hidden=�6a   $ False��6u   $��Runda)�6�   
�������$��0q�6�   
 ����� �#19959F$
 True��6   5I        5J      $ * 6%   $ Monday��6/   $ Runda Light)�6_    6?   �� *mealDetails+6_   5L        5M   
   -   5        $ 
TuesdayCol��5M      $	��500��6'   $	��150��64   $ 70��6@   $	 300��6P   $y�Hidden=�6b   $ False��6v   $��Runda)�6�   
�������$��0q�6�   
 ����� �#19959F$
 True��6   5N        5O      $ * 6%   $ Tuesday��6/   $ Runda Light)�6`    6@   �� *mealDetails+6`   5Q        5R   
   -    5        $ WednesdayCol��5R      $	��500��6*   $	��150��67   $ 70��6C   $	 450��6S   $y�Hidden=�6e   $ False��6y   $��Runda)�6�   
�������$��0q�6�   
 ����� �#19959F$
 True��6   5S        5T      $ * 6%   $ 	Wednesday��6/   $ Runda Light)�6b    6B   �� *mealDetails+6b   5V        5W   
   -!   5        $ ThursdayCol��5W      $	��500��6(   $	��150��65   $ 70��6A   $	 600��6Q   $y�Hidden=�6c   $ False��6w   $��Runda)�6�   
�������$��0q�6�   
 ����� �#19959F$
 True��6   5X        5Y      $ * 6%   $ Thursday��6/   $ Runda Light)�6a    6A   �� *mealDetails+6a   5[        5\   
   -"   5        $ 	FridayCol��5\      $	��500��6&   $	��150��63   $ 70��6?   $	 750��6O   $y�Hidden=�6a   $ False��6u   $��Runda)�6�   
�������$��0q�6�   
 ����� �#19959F$
 True��6   5]        5^      $ * 6%   $ Friday��6/   $ Runda Light)�6_    6?   �� *mealDetails+6_   5`        5a   
   -#   5        $ SaturdayCol��5a      $	��500��6(   $	��150��65   $ 70��6A   $	 900��6Q   $y�Hidden=�6c   $ False��6w   $��Runda)�6�   
�������$��0q�6�   
 ����� �#19959F$
 True��6   5b        5c      $ * 6%   $ Saturday��6/   $ Runda Light)�6a    6A   �� *mealDetails+6a   5e        5f   
   -$   5        $ 	SundayCol��5f      $	��500��6&   $	��150��63   $ 70��6?   $
 1050��6O   $y�Hidden=�6b   $ False��6v   $��Runda)�6�   
�������$��0q�6�   
 ����� �#19959F$
 True��6   5g        5h      $ * 6%   $ Sunday��6/   $ Runda Light)�6_    6?   �� *mealDetails+6_   5j      5k      5l      