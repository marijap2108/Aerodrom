   M S B A M L   `   `   `  ����C  ?Aerodrom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Aerodrom.WindowsAerodrom.Windows  5   	   !    Aerodrom.Windows.PistaZakup   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Aerodrom.Windows     5   	     � Title$  
PistaZakup��5   	   $	��350��6   $	��450��6)    � WindowStartupLocation$ CenterScreen=�65   .��5	      � ���	#FF23242A � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��70 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6   $��Rezerviši pistu��6-   $��24(�6G   ���	#FF1C8E956U   �� 5   
   $��2��6   $��1��6   $��Odaberi pistu��6-   $��Center=�6E   ���	#FFC7C7C76`   �� 5   
   -   5         ��Name$ 
PistaLista��5   0   $��2��6   $��2��6    $	��200��6D   $��25��6P   $
��Left=�6\   6w   �� 5   
   $��3��6   $��1��6   $#��Odaberi datum početka zakupa��6-   $��Center=�6T   ���	#FFC7C7C76o   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ Pocetak��5      $��3��6&   $��2��63   $	��120��6C   $��30��6O   $
��Left=�6[   ��6v   Z�  � 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property	 �� Value��%[   '        �� 5      "  6   .�5       ��  �@��
IsReadOnly	 . 63   5!      5"      5#      �� 5$   
   $��4��6   $��1��6   $ ��Odaberi datum kraja zakupa��6-   $��Center=�6R   ���	#FFC7C7C76m     5%   
   -   5        $
 Kraj��5%      $��4��6#   $��2��60   $	��120��6@   $��30��6L   $
��Left=�6X   ��6s   Z�  5&      ��%[   '        �� 5'      "  6   .�5(      ��  �@��
IsReadOnly	 . 63   5)      5*      5+      �� 5,   
   -   5        
 ��Name$
 Zakupi��5,      $��5��6!   $��2��6.   $��Zakupi��6>   $	��100��6O   $��40��6[   $
��Left=�6g   ���	#FF1C8E95$
��Bold"�6�   $��14(�6�   ���	#FFB4B42F���	#FFB4B42F6�   5-      5.      