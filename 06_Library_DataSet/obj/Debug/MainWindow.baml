   M S B A M L   `   `   `  ����E  A06_Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:_06_Library_06_Library  5   	       _06_Library.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:_06_Library     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��200 �6   �� 5      .+�5   
   �� -   5         ��Name$ 
tabControl��5   %   $��1��6   6j   � 5   
   $��0��6   
������� � RowDefinitions 5      �� 5      $
��105* �6    �� 5      $	��30* �6    �� 5      $
��105* �6    .+�5      �� -   5         ��Name$ btn_del��5      $��Search and delete��6&   $	��120��6X   $��50��6d   �� 5      $��1��6    �� Orientation$ 
Horizontal=�6&   .+�5      �� -   5         ��Name$ lbl_placeholder��5      $��	Enter ID:��61   $��5q�6E   �� 5      -   5         ��Name$ tb_id��5      $
��Left=�6)   $	��120��6D   $��40��6P   5      �� 5!      -   5        $��3��5!      $��Save to xml��6"   $	��120��6O   $��50��6[   5&      5(      5)      