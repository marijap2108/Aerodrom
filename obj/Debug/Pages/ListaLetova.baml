   M S B A M L   `   `   `  ����C  ?Aerodrom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Aerodrom.PagesAerodrom.Pages  5           Aerodrom.Pages.ListaLetova   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Aerodrom.Pages     5        N� Title$  ListaLetova��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      -   5         ��Name$
 Meni��5   )   $��0 �6   6)   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5   #   $��0��6      CanUserAddRows .  $��Stretch=�6L   $��Stretch=�6j   
������ }�.  � Cursor$ Arrow��6�    �� IsTextSearchEnabled .    CanUserReorderColumns .     CanUserResizeColumns .  	   GridLinesVisibility$	 
Horizontal=�6/  
   AlternatingRowBackground
 �	#FF2C2E36   RowBackground
 ���� ���	#FFC7C7C7$��14(�6�  ��6�   Z�  � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value �� Color��%�   '        (�� |     5   "   * SystemColors.HighlightBrushKey+)�� 5      "  6   .�5      ��  � �� �	#FFB4B42F63   �� 5       � �� �	#FF1C8E9563   5      �� 5      $ 	#FF1C8E95��5      5      5      �� 5   
   $��1��6   .+�5      �� -   5         ��Name$ ToggleButton��5      $��Moji letovi��6+   $	��Top=�6A   $��60��6Y   
������ 
������ ���	#FFC7C7C7$��	0,20,0,10q�6�   6�   �� 5      -   5        $ ActionButton��5      $��
Kupi kartu��6+   $	��Top=�6@   $��60��6X   
������ 
������ ���	#FFC7C7C7$
��0,10q�6�   6�   �� 5      -   5        $ 
EditFlight��5      $��
Izmeni let��6)   $	��Top=�6>   $��60��6V   
������ 
������ ���	#FFC7C7C7$
��0,10q�6�   6�   �� 5      -   5        $ DeleteFlight��5      $��
Obrisi let��6+   $	��Top=�6@   $��60��6X   
������ 
������ ���	#FFC7C7C7$
��0,10q�6�   6�   5      5    
   5!      