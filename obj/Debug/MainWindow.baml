   M S B A M L   `   `   `  ����C  ?Aerodrom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AerodromAerodrom  5   	       Aerodrom.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Aerodrom     5   	     � Title$  
MainWindow��5	   	   $	��520��6   $	��800��6)    � WindowStyle$
 None=�65   $	��800��6H   $	��520��6W    � WindowStartupLocation$ CenterScreen=�6g   .��5
      � ���	#FF23242A$	��640��6"   $	��360��61    � ColumnDefinitions 5   
   �� 5      $	��120 �6   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� ���	#FFB4B42F$��Aerodrom��6'   $��Stretch=�6:   $��Stretch=�6X   $��Century Gothic)�6t   $��20(�6�   $
��Bold"�6�   ���	#FF1C8E95$��Center=�6�   $��Center=�6�   �� 5   
   -   5         ��Name$ Naslov��5      $��0��6    $��2��6-   $��Početna strana��6=   ���	#FF1C8E95$��Center=�6m   $��18(�6�   �� 5   
   -   5         ��Name$
 Menu��5      ���	#FF2C2E36$��0��6:   $��1��6J   $��3��6W   $��Disabled=�6h   $��Disabled=�6�   .+�5      �� -   5         ��Name$ PSButton��5      $��Početna strana��6'   $��60��6@   
������ 
������ ���	#FFC7C7C7$��0,20,0,0q�6�   $��1,0,0,1q�6�   �� 5      -   5        $ LLButton��5      $��Lista letova��6'   $��60��6>   
������ 
������ ���	#FFC7C7C76�   �� 5      -   5        $ IButton��5      $��Izlaz��6&   $��60��66   
������ 
������ ���	#FFC7C7C76�   5      �� 5   
   -   5        $ SignUpButton��5   .   $��2��6   $��0��6!   $��Sign up��6D   $��Right=�6V   $	��111��6r   $��30��6~   
������ 
������ ���	#FF1C8E95$��Italic$�6�    � 5    
   -   5          �Name$ _NavigationFrame��5    -   $��2��6   $��2��6   	  � NavigationUIVisibility$	 Hidden=�6G   $��Stretch=�6g   $��Stretch=�6�   $��Visible=�6�   ��. 6�   5!      5"      