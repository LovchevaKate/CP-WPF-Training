   M S B A M L   `   `   `  ����D  @Trainings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Trainings	Trainings  5   	        Trainings.Sportsman_Window   5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Trainings     5   	   -   5          � Title$  	Trainings��5
   	   $	��460��5   	   $	��600��5   	   ���	#FF310C1E���	#FF9AE1D4 � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��295* �6   �� 5      $
��126* �6    � ColumnDefinitions 5   
   �� 5      $
��305* �6   �� 5      $
��289* �6   .+�5   
   &   System.Windows.Controls.Calendar  -   5          Name$ calendar��5      $��0��5      $
��Left=�5       $	��Top=�5!      $��	10,10,0,0q�5"      $	��356��5#      $	��278��5$      $��2��5%      �� 5'   
   -   5        $��0��5'      $��1��5(      $��Bottom=�5)      $
��Left=�5*      $��	10,0,0,10q�5+      $��80��5,      $��
Выход��5-      5.      �� 50   
   -   5        $��0��50      $��Дневник��51      $��1��52      $��30��53      $��Bottom=�54      $��Center=�55      $��10q�56      $��90��57   =   �� 59   
   $��Тренировки��6   $��Center=�5:      $��16(�5;      $	��Top=�5<      $��1��5=      $��31��5>      $��98��5?      $��
91,0,100,0q�6   &   System.Windows.Controls.DataGrid  5A   
   -   5        $��TrainingsDataGrid��5A      $��Center=�5B      $	��250��5C      $	��200��5D      $��1��5E      $��0��5F      $��Center=�5G      ���	#FFFAFAFA   AutoGenerateColumns .     CanUserAddRows .  ��5I      ��    Columns 5L      0  *System.Windows.Controls.DataGridTextColumn  5N      -   5        
DateColumn��,  &System.Windows.Controls.DataGridColumn	   Header$#	 Дата тренировки��5P   %   
   
IsReadOnly
 .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5R   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5O   %   �� *Date+ �� NotifyOnSourceUpdated .  �� StringFormat$ 	{0:dd/MM}��5R   %   ��5U      �� 5V       �� Color$ 	#FFE91E63��6"    �� Opacity$	 0.2Q�64   5X      5Y      5[      