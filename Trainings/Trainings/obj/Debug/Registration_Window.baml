   M S B A M L   `   `   `  ����D  @Trainings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Trainings	Trainings  5   	   #    Trainings.Registration_Window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Trainings     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  	Trainings��5	   	   $	��570��5
   	   $	��350��6    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��Stretch=�6   $��Stretch=�5      $
��0 10q�5      .��5      �� $	��Top=�5      $��Center=�5      .+�5      �� $��Регистрация��6   $��18(�5      $��Center=�5      $	��125��64   '  !MaterialDesignThemes.Wpf.PackIcon  5      �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ AccountPlus=�6*   $��25��5   *   $��25��5   *   $��Center=�5   *   �� 5       -   5         ��Name$ 	Login_reg��5       $��
20 10 20 2q�5!      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��5"      $	��180��5#      $��25��6)   $	��180��5$      $��25��6)    �� 	MaxLength$ 25��5%      ��6)   �� *Login+ �� UpdateSourceTrigger$ PropertyChanged=�G� 5'      -   5         G�Name$ Password_reg��5'      $ Пароль��5(      $	��180��5)      $��25��6-   $	��180��5*      $��25��6)   	 G� 	MaxLength$	 25��5+      G� 5.      -   5        $ Password2_reg��5.      $��
20 2 20 10q�5/      $# Проверка пароля��50      $	��180��51      $��25��6)   $	��180��52      $��25��6)   $	 25��53      �� 56      -   5        $ 	Sname_reg��56      $��
20 10 20 2q�57      $ Фамилия��58      $	��180��59      $��25��6)   $	��180��5:      $��25��6)   $ 25��5;      ��6N   �� *Sname+$ PropertyChanged=��� 5=      -   5        $ Name_reg��5=      $
��20 2q�5>      $ Имя��5?      $	��180��5@      $��25��6)   $	��180��5A      $��25��6)   $ 25��5B      ��6N   �� *Name+$ PropertyChanged=��� 5D      -   5        $ Telephon_reg��5D      $
��20 2q�5E      $, &Телефон (375ХХХХХХХХХ)��5F      $	��180��5G      $��25��6(   $	��180��5H      $��25��6)   
 � ToolTip$8
 2Формат записи: 375 ХХ ХХХХХХХ��5I      $ 11��5J      ��6N   �� *
Telephon+$ PropertyChanged=��� 5L      -   5        $ Age_reg��5L      $��
20 2 20 10q�5M      $ Возраст��5N      $	��180��5O      $��25��6)   $	��180��5P      $��25��6)   $ 2��5Q      ��6M   �� *Age+$ PropertyChanged=�	� 5S      -   5         	� 	GroupName$ 	GenderReg��5S       d� 	IsChecked$
 TrueY�5T      $��
20 10 20 2q�5U      $��мужской��5V      5W      	� 5X      -	   5        $ 	GenderReg��5X      $��
20 2 20 10q�5Y      $��женский��5Z      5[      �� 5]      -
   5        $ 
Height_reg��5]      $��
20 10 20 2q�5^      $ Рост��5_      $	��180��5`      $��25��6)   $	��180��5a      $��25��6)   $ 3��5b      ��6M   �� *Height+$ PropertyChanged=��� 5d      -   5        $ 
Weight_reg��5d      $
��20 2q�5e      $ Вес��5f      $	��180��5g      $��25��6)   $	��180��5h      $��25��6)   $ 3��5i      $+
 %Введите целое число!��5j      ��69   �� *Weight+$ PropertyChanged=��� 5l      -   5        $ 	Param_reg��5l      $��
20 0 20 20q�5m      $# Параметры (90/60/90)��5n      $	��180��5o      $��25��5p      $	��180��5q      $��25��5r      $ 11��5s      $G
 AОбъём груди/объём талии/объём бёдер��5t      ��6H   �� *Param+$ PropertyChanged=��� 5v      -   5         ��Name$ button_create_user��5x      $#��Создать профиль��5v      $��20 10 20 10q�5w      5y      5z      5{      5~      5      