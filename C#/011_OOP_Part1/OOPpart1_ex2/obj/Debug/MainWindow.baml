   M S B A M L   `   `   `  ����G  COOPpart1_ex2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:OOPpart1_ex2OOPpart1_ex2  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       OOPpart1_ex2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:OOPpart1_ex2     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$  Банк «А»��5	   	   $	��220��6   $	��800��6'   $	��800��63   $	��220��6B   $	��800��6R   $	��220��6a   $��Times New Roman)�6q   $��Center=�6�   $��Center=�6�   $��Center=�6�   $��Center=�6�    � WindowStartupLocation$ CenterScreen=�6   � WindowState$ Normal=�61   � 	Resources 5
         fontSize  
fontFamily��%U   &	        &	      X�5   
   12Q�6*   *�5   
   Times New Roman)�69   5      .��5      �  � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $��15 �6   �� 5      $��5 �6   �� 5      $��15 �6   �� 5      $��5 �6   �� 5      $��15 �6   �� 5      $��5 �6   �� 5      $��15 �6   �� 5      $��5 �6   �� 5      $��15 �6   �� 5      $��5 �6   �� 5      $��15 �6   �� 5      $��* �6   �� 5      $��15 �6   �� 5      $��5 �6   �� 5       $��15 �6   �� 5!      $��10 �6    � ColumnDefinitions 5#   
   �� 5$      $��10 �6   �� 5%      $��* �6   �� 5&      $��5 �6   �� 5'      $	��135 �6   �� 5(      $��5 �6   �� 5)      $	��120 �6   �� 5*      $��10 �6   .+�5,   
   �� $%��Данные о клиенте:��6   $��3��5-      $��1��6    $��3��6-   #��[ 5.      $��Center=�5/      $��Center=�50      $��0,0,0,0q�51      #��[  52      �� 54   
   $��Фамилия:��6   $��3��55      $��3��6    $��0,0,0,0q�56      #��[ 57      #��[  58      �� 5:   
   $��Имя:��6   $��3��5;      $��5��6    $��0,0,0,0q�5<      #��[ 5=      #��[  5>      �� 5@   
   $��Отчество:��6   $��3��5A      $��7��6    $��0,0,0,0q�5B      #��[ 5C      #��[  5D      �� 5F   
   $"��Номер телефона:��6   $��3��5G      $��9��6    $��0,0,0,0q�5H      #��[ 5I      #��[  5J      �� 5L   
   $0��*Серия и номер паспорта:��6   $��3��5M      $��11��6    $��0,0,0,0q�5N      #��[ 5O      #��[  5P      �� 5R   
   -   5         ��Name$ 
TbxSurname��5R      $�� ��5S       �� TextWrapping$
 Wrap=�5T      $��5��5U      $��3��6"   #��[ 5V      #��[  5W      �� 5Y   
   -   5        $ TbxName��5Y      $�� ��5Z      $
 Wrap=�5[      $��5��5\      $��5��6"   #��[ 5]      #��[  5^      �� 5`   
   -   5        $ TbxPatronymic��5`      $�� ��5a      $
 Wrap=�5b      $��5��5c      $��7��6"   #��[ 5d      #��[  5e      �� 5g   
   -   5        $ TbxPhoneNumber��5g      $�� ��5h      $
 Wrap=�5i      $��5��5j      $��9��6"   #��[ 5k      #��[  5l      �� 5n   
   -   5        $ TbxIdPassport��5n      $�� ��5o      $
 Wrap=�5p      $��5��5q      $��11��6"   #��[ 5r      #��[  5s      �� 5v   
   $��3��6   $��13��6&   $��3��64   .+�5w      	� -   5         	�Name$ RbtnConsultant��5w      $��Консультант��5x      $��0,0,0,0q�5y      5{      	� 5|      -   5        $ RbtnManager��5|      $��Менеджер��5}      $��0,5,0,0q�5~      6'   5      �� 5�   
   -   5        	 ��Name$	 btnRedactor��5�      $ ��Редактировать��5�      $��5��5�      $��13��6!   $��0,0,0,0q�5�      $��15��6?   $��Center=�6K   �� 5�   
   -	   5        $	 btnAdd��5�      $��Добавить��5�      $��5��5�      $��14��6!   $��0,0,0,0q�5�      $��0,5,0,0q�6:   $��2��6K   �� 5�   
   -
   5        
 ��Name$
 
clientList��5�      $��1��5�      $��1��6#   $��15��60    �� View 5�      �� 5�       �� AllowsColumnReorder .  .P�5�      �� $��Фамилия��6%    �� Width$ 85��5�   N    �� DisplayMemberBinding 6%   �� *	Surname+6N   �� 5�      $��Имя��6%   $ 85��5�   K    6%   �� *Name+6K   �� 5�      $��Отчество��6%   $ 85��5�   Q    6%   �� *
Patronymic+6Q   �� 5�      $!��Номер телефона��6%   $	 100��5�   R    6%   �� *PhoneNumber+6R   �� 5�      $/��)Серия и номер паспорта��6%   $	 135��5�   Q    6%   �� *
IdPassport+5�      5�      5�      5�      5�      