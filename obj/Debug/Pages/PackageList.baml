   M S B A M L   `   `   `  ����C  ?Aerodrom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Aerodrom.PagesAerodrom.Pages  5           Aerodrom.Pages.PackageList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Aerodrom.Pages     5        N� Title$  PackageList��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��120 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ PackageListGrid��5   #   $��0��6      
IsReadOnly . $��Stretch=�6N   $��Stretch=�6l   
������ }�.  � Cursor$ Arrow��6�    �� IsTextSearchEnabled .    CanUserReorderColumns .     CanUserResizeColumns .     GridLinesVisibility$ 
Horizontal=�61  	   AlternatingRowBackground	 �	#FF2C2E36
   RowBackground

 ���� ���	#FFC7C7C7$��14(�6�  ��6�   Z�  � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value �� Color��%�   '        (�� |     5   "   * SystemColors.HighlightBrushKey+)�� 5      "  6   .�5      ��  � �� �	#FFB4B42F63   �� 5       � �� �	#FF1C8E9563   5      �� 5      $ 	#FF1C8E95��5      5      5      �� 5   
   $��1��6   $	��Top=�6%   .+�5      �� -   5         ��Name$ Paket��5      $��Pošalji paket��6$   $
��0,10q�6<   $��60��6J   ���	#FFC7C7C7
������ 
������ 6�   �� 5      -   5        $ Otkaži��5      $��Otkaži paket��6%   $��0,10,0,0q�6<   $��60��6N   ���	#FFC7C7C7
������ 
������ 6�   5      5      5      