   M S B A M L   `   `   `  ����J  FFusilControlLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:FusilControlLib;assembly=FusilControlLibFusilControlLib  5       FusilWPFApplication'   !FusilWPFApplication.VehicleReport   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ecf6clr-namespace:FusilControlLib;assembly=FusilControlLib     5      .��5	          FusilControlLib.CustomGrid  -   5           Name$  gdVehicleReport��5	       � RowDefinitions 5
   
   �� 5      $��30 �6   �� 5      $
��auto �6   .+�5   
   � $��0��6   .+�5      #   FusilControlLib.CustomTextBox  -   5          Name$ tbFilter��5      $��5,0,0,0q�61   ��6B   �� *Filter+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5      � 5   
   $��1��6   .+�5   
   %   FusilControlLib.CustomWrapPanel  -   5          Name$ wpAccountReport��5      .+�5      $   FusilControlLib.CustomDataGrid  -   5          Name$ dgVehicleReport��5       &   System.Windows.Controls.DataGrid   CanUserAddRows .     AutoGenerateColumns .  	   SelectionUnit$
	 Cell=�6l   $	��500��6�   
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        
dgName��,  &System.Windows.Controls.DataGridColumn   Header$
 Name��5   :   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *Name+$ TwoWay=�$ PropertyChanged=�  5      -   5        dgModel��$ Model��5   :    6I   �� *Model+$ TwoWay=�$ PropertyChanged=�  5      -   5        
dgRate��$ 	Last Name��5   :    6M   �� *Rate+$ TwoWay=�$ PropertyChanged=�  5      -   5        	dgTax��$	 Tax��5   9    6F   �� *Tax+$ TwoWay=�$ PropertyChanged=�  5      -	   5        	dgAcc��$	 Acc��5   9    6F   �� *Acc+$ TwoWay=�$ PropertyChanged=�  5      -
   5        dgTotal��$ Total��5   ;    6J   �� *Total+$ TwoWay=�$ PropertyChanged=�  5      -   5        
dgDisc��$
 Disc��5   :    6H   �� *Disc+$ TwoWay=�$ PropertyChanged=�  5      -   5        
dgDiscRate��$ DiscRate��5   =    6O   �� *
DiscRate+$ TwoWay=�$ PropertyChanged=�  5      -   5        dgFinal��$ Final��5   ;    6J   �� *Final+$ TwoWay=�$ PropertyChanged=�5      5       5!      5"      5#      