   M S B A M L   `   `   `  ����I  EHealth Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Health_TrackerHealth_Tracker  5   	   $    Health_Tracker.YourGoalsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Health_Tracker     5   	     � Title$  	YourGoals��5   	   $	��450��6   $	��800��6(    � WindowState$ 	Maximized=�5	   	    � WindowStyle$
 None=�5
   	   .��5      �� .+�5   
   o� $	��800��6   
 �� Top$ 50��6   ���#19959F
���������5      �� 5      .R�5      $�  $� Orientation$ Vertical=�6-   5      .@�5      m� -   5        $
��Food��5      $	��150��6%   $��Runda Light)�6L   m� 5      -   5        $��Exercise��5      $	��150��6)   $��Runda Light)�6T   m� 5      -   5        $��Exercise Calendar��5      $	��150��62   $��Runda Light)�6e   m� 5      -   5        $��Your Day��5      $	��150��6)   $��Runda Light)�6S   5      �� 5   
   -   5         ��Name$ 
BackButton��5      $ 10��6%    �� Left$ 10��65   
�������
�������.��5      �� $E��?C:\Users\anush\source\repos\health-tracker\Images\BackArrow.png��6   $��30��6]   5      �� 5   
   -   5         ��Name$ YourGoalsLabel��5      $��
Your Goals��6(   $ 10��6=   $	 560��6M   $��Runda)�6_   $��25(�6r   ���#19959F6�   �� 5   
   -   5        $ AddGoalLabel��5      $��Add Goal��6&   $ 50��69   $	 500��6I   $��Runda Light)�6[   �� 5   
   -   5         ��Name$ AddGoalInput��5      $	��300��6(   $ 55��64   $	 600��6D   $��Runda Light)�6V   �� 5   
   -	   5        $ AchieveByLabel��5      $��Achieve By:��6(   $	 100��6>   $	 500��6O   $��Runda Light)�6a   (  "System.Windows.Controls.DatePicker  5    
   -
   5        	  Name$	 AchieveByDate��5       $	��200��6,   $	 105��68   $	 600��6I   $��Runda Light)�6[   �� 5"   
   -   5        $ OKButton��5"      $��OK��6#   $��30��60   $	 160��6;   $	 625��6L   $��Runda Light)�6t   ���#19959F$��0q�6�   &   System.Windows.Controls.DataGrid  5$   
   -   5        
  Name$
 
GoalsTable��5$      $	��600��6'   $	 200��63   $	 350��6D      AutoGenerateColumns$ False��6V   $��Runda)�6r   
�������$��0q�6�      VerticalGridLinesBrush
 �����   HorizontalGridLinesBrush �#19959F   
IsReadOnly$
 True��5%   =      Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      -   5        GoalCol��,  &System.Windows.Controls.DataGridColumn   Header$
 Goal��5'   6      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6N   �� *
GoalInfo+  5(      -   5        AchieveByCol��$ 
Achieve By��5(   ;   $ * 6O    6Y   �� *	AchieveBy+4  .System.Windows.Controls.DataGridTemplateColumn  5)      -   5        	StatusCol��$ Status��5)   <   $ * 6L      CellTemplate 5*      �� 5+      .R�5,      �� $ StatusButton��6%   -   5        $��View Status��5,   ;   $��Runda Light)�6k   ���#19959F��6�   Z� 6�   5-      5/      51      � 53   
   -   5         �Name$ StatusPopup��53      $	��150��6%   $	��300��62   $	 100��6>   $	 100��6O   $��Center=�6a    � AllowsTransparency$ False��6t   $��False��6�   �� 55   
   -   5        $ ViewCompletedGoalsButton��55      $��View Completed Goals��63   $	��150��6R   $	 336��6^   $	 575��6o   $��Runda Light)�6�   ���#19959F$��0q�6�   � 56   
   -   5        $ ViewCompletedGoalsPopup��56      $	��300��61   $	��300��6>   $	 100��6J   $	 100��6[   $��Center=�6m   $ False��6�   $��False��6�   .��57      �� 
�������.+�58      �� -   5        $ CloseCompletedGoalsButton��58      $��15��6<   $��15��6H   $ 0��6S    �� Right$ 0��6b   $��0q�6�   ��6�   Z� .��59      �� $F��@C:\Users\anush\source\repos\health-tracker\Images\ClosePopup.png��6   5:        5;      -   5        $
 CompletedGoalsTable��5;      $	��300��68   $	��300��6E   $ 15��6Q   $ False��6a   $��Runda)�6}   
�������$��0q�6�    �#19959F �#19959F$
 True��6�    5<        5=      -   5        CompletedGoalsList��$ * 5=   I   $ Completed Goals��6S      
FontFamily$ Runda Light)�6�    6l   �� *
GoalInfo+6�   5?      5@      5C      5D      5E      