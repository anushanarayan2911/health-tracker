   M S B A M L   `   `   `  ����I  EHealth Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Health_TrackerHealth_Tracker  5   	   #    Health_Tracker.ExerciseWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Health_Tracker     5   	     � Title$  Exercise��5   	   $	��450��6   $	��800��6'    � WindowState$ 	Maximized=�5	   	    � WindowStyle$
 None=�5
   	   .��5      �� .+�5   
   o� $	��800��6   
 �� Top$ 50��6   ���#19959F
���������5      �� 5      .R�5      $�  $� Orientation$ Vertical=�6-   5      .@�5      m� -   5        $
��Food��5      $	��150��6%   $��Runda Light)�6L   m� 5      -   5        $��Exercise Calendar��5      $	��150��62   $��Runda Light)�6e   m� 5      -   5        $��Your Day��5      $	��150��6)   $��Runda Light)�6S   m� 5      -   5        $��
Your Goals��5      $	��150��6+   $��Runda Light)�6W   5      �� 5   
   -   5         ��Name$ 
BackButton��5      $ 10��6%    �� Left$ 10��65   
�������
�������.��5      �� $E��?C:\Users\anush\source\repos\health-tracker\Images\BackArrow.png��6   $��30��6]   5      �� 5   
   -   5         ��Name$ Title��5      $��Exercise��6   $ 10��62   $	 590��6B   $��Runda)�6T   $��25(�6g   ���#19959F6u   �� 5   
   -   5        $ TimeInputInfo��5      $%��Enter time information as HH:MM��6'   $ 50��6Q   $	 550��6a   $��Runda Light)�6s   �� 5    
   -   5        $ ExerciseTitleLabel��5       $��Exercise Title:��6,   $ 70��6F   $	 350��6V   $��Runda Light)�6h   �� 5!   
   -	   5         ��Name$ ExerciseTitleInput��5!      $	��150��6.   $ 75��6:   $	 450��6J   $��Runda Light)�6\   �� 5#   
   -
   5        $ ExerciseDetailsLabel��5#      $��Exercise Details:��6.   $	 105��6J   $	 350��6[   $��Runda Light)�6m   �� 5$   
   -   5        $ ExerciseDetailsInput��5$      $	��400��60   $	 110��6<   $	 450��6M   $��Runda Light)�6_   �� 5&   
   -   5        $ FrequencyLabel��5&      $��
Frequency:��6(   $	 140��6=   $	 350��6N   $��Runda Light)�6`   �� 5'   
   -   5        	 ��Name$	 FrequencyDropDownMenu��5'      $	��100��62   $	 145��6>   $	 450��6O   $��Runda Light)�6�   .@�5(      �� -   5        
 ��Name$
 DailyOption��5(      $��Daily��60   �� 5)      -   5        $
 WeeklyOption��5)      $��Weekly��61   �� 5*      -   5        $
 CustomOption��5*      $��Custom��61   5+      �� 5-   
   -   5         ��Name$ DaysOfWeekButton��5-      $	 145��6-   $	 600��6>   $y�Hidden=�6P   .+�5.      	� -   5        $��Monday��5.      $��Runda Light)�6A   	� 5/      -   5        $��Tuesday��5/      $��Runda Light)�6B   	� 50      -   5        $��	Wednesday��50      $��Runda Light)�6D   	� 51      -   5        $��Thursday��51      $��Runda Light)�6C   	� 52      -   5        $��Friday��52      $��Runda Light)�6A   	� 53      -   5        $��Saturday��53      $��Runda Light)�6C   	� 54      -   5        $��Sunday��54      $��Runda Light)�6A   55      �� 57   
   -   5        $ DaysOfWeekCheckbox��57      $	 145��6/   $	 600��6@   $y�Hidden=�6R   .+�58      �� -   5        $��Monday��58      $��Runda Light)�6C   �� 59      -   5        $��Tuesday��59      $��Runda Light)�6D   �� 5:      -   5        $��	Wednesday��5:      $��Runda Light)�6F   �� 5;      -   5        $��Thursday��5;      $��Runda Light)�6E   �� 5<      -   5        $��Friday��5<      $��Runda Light)�6C   �� 5=      -   5        $��Saturday��5=      $��Runda Light)�6E   �� 5>      -    5        $��Sunday��5>      $��Runda Light)�6C   5?      �� 5A   
   -!   5        $ StartTimeLabel��5A      $��
Start Time��6(   $	 175��6=   $	 350��6N   $��Runda Light)�6`   �� 5B   
   -"   5        $ ExerciseStartTimeInput��5B      $	��100��62   $	 180��6>   $	 450��6O   $��Runda Light)�6a   �� 5D   
   -#   5        $ EndTimeLabel��5D      $��End Time��6&   $	 175��69   $	 630��6J   $��Runda Light)�6\   �� 5E   
   -$   5        $ ExerciseEndTimeInput��5E      $	��100��60   $	 180��6<   $	 730��6M   $��Runda Light)�6_   �� 5G   
   -%   5        $ StartDateLabel��5G      $��
Start Date��6(   $	 210��6=   $	 350��6N   $��Runda Light)�6`   (  "System.Windows.Controls.DatePicker  5H   
   -&   5          Name$ ExerciseStartDateInput��5H      $	 215��65   $	 450��6F   $��Runda Light)�6X   �� 5J   
   -'   5        $ EndDateLabel��5J      $��End Date��6&   $	 210��69   $	 630��6J   $��Runda Light)�6\     5K   
   -(   5        $ ExerciseEndDateInput��5K      $	 215��63   $	 730��6D   $��Runda Light)�6V   �� 5M   
   -)   5        $ OKButton��5M      $��OK��6$   $��30��61   $	 250��6<   $	 620��6M   ���#19959F$��0q�6�   $��Runda Light)�6�   &   System.Windows.Controls.DataGrid  5O   
   -*   5          Name$ AddedExercises��5O      $	��100��6+   $	��750��68   $	 290��6D   $	 250��6U      AutoGenerateColumns$ False��6g   $��Runda)�6�   
�������$��0q�6�      VerticalGridLinesBrush
 �����   HorizontalGridLinesBrush �#19959F   
IsReadOnly$
 True��6�      Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      -+   5        ExerciseName��,  &System.Windows.Controls.DataGridColumn   Header$
 Name��5Q   ;      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6I      
FontFamily$ Runda Light)�6t   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6S   �� *exerciseName+6t     5R      -,   5        ExerciseDetails��$ Details��5R   >   $ * 6O   $ Runda Light)�6~    6Y   �� *exerciseDetails+6~     5S      --   5        	Frequency��$ 	Frequency��5S   8   $ * 6K   $ Runda Light)�6|    6U   �� *exerciseFrequency+6|     5T      -.   5        Time��$
 Time��5T   3   $ * 6A   $ Runda Light)�6m    6K   �� *exerciseTime+6m     5U      -/   5        Date��$
 Date��5U   3   $ * 6A   $ Runda Light)�6m    6K   �� *exerciseDate+6m   5W      5X      5Y      