   M S B A M L   `   `   `  ����J  FFusilControlLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:FusilControlLib;assembly=FusilControlLibFusilControlLib  5       FusilWPFApplication$   FusilWPFApplication.AccountsUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ecf6clr-namespace:FusilControlLib;assembly=FusilControlLib     5        � 	Resources  5         HeaderBrush �� 
StartPoint �� EndPoint � Color � Offset��%�   &	        �� 5	   
   $	 0,1&�62   $	 0,1&�6C   .��5
      � $ SkyBlue��6   $ 1Q�6+   � 5      $ 	AliceBlue��6   5      5      .��5          FusilControlLib.CustomGrid  -   5          Name$ gdAccountsUC��5       � RowDefinitions 5   
   �� 5      $	��50* �6   �� 5      $	��40* �6   .+�5   
   � $��0��6   .+�5      $   FusilControlLib.CustomGroupBox  -   5          Name$ gbHeader��5       $��Header��62   $	��500��6B   $	��Top=�6N   .��5      %   FusilControlLib.CustomWrapPanel  -   5          Name$ wpHeader��5   %   	 � Orientation$	 Vertical=�67   $	��Top=�6O   $��Center=�6g   .+�5      &    FusilControlLib.CustomStackPanel  -   5        
  Name$
 spSno��5   *    �� Orientation$ 
Horizontal=�69   $��Center=�6R   $��Center=�6m   $	��350��6�   $��40��6�   $��0,5,0,0q�6�   .+�5      !   FusilControlLib.CustomLabel  -   5          Name$ lblSno��5   )   $
��Sno*��69   $��50,0,0,0q�6H   #   FusilControlLib.CustomTextBox  5      -   5          Name$ tbSno��5   +   ��6:   �� *Sno+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5        5      -   5        $
 spName��5   *   $ 
Horizontal=�6:   $��Center=�6S   $��Center=�6n   $	��350��6�   $��40��6�   .+�5        -   5        $ lblName��5   )   $��Name*��6:   $��50,0,0,0q�6J     5      -	   5        $ tbName��5   +   ��6;   �� *Name+$ TwoWay=�$ PropertyChanged=�5        5      -
   5        $
 
spTaxClass��5   *   $ 
Horizontal=�6>   $��Center=�6W   $��Center=�6r   $	��350��6�   $��40��6�   .+�5        -   5        $ lblTaxClass��5   )   $��
Tax Class*��6>   $��50,0,0,0q�6S   $   FusilControlLib.CustomComboBox  5       -   5          Name$ comboTaxClass��5    ,    �� SelectedItem 6C   �� *
TaxClass+$ TwoWay=�$ PropertyChanged=�5!        5"      -   5        $
 spCode��5"   *   $ 
Horizontal=�6:   $��Center=�6S   $��Center=�6n   $	��350��6�   $��40��6�   .+�5#        -   5        $ lblCode��5#   )   $
��Code��6:   $��50,0,0,0q�6I     5$      -   5        $ tbCode��5$   +   ��6;   �� *Code+$ TwoWay=�$ PropertyChanged=�5%        5&      -   5        $
 spDesc��5&   *   $ 
Horizontal=�6:   $��Center=�6S   $��Center=�6n   $	��350��6�   $��40��6�   .+�5'        -   5        $ lblDesc��5'   )   $
��Desc��6:   $��50,0,0,0q�6I     5(      -   5        $ tbDesc��5(   +   ��6;   �� *Desc+$ TwoWay=�$ PropertyChanged=�5)      5*      5+      5,      � 5-   
   $��1��6   .+�5.        -   5        $ gdAccountsBodyUC��5.      #��[  66   .+�5/        -   5        $ gbBody��5/   $   $
��Body��64   $	��Top=�6B   $	��500��6[   $��0,0,0,0q�6g   .��50        -   5        $ wpBody��50   )   $	 Vertical=�69   $	��Top=�6P   $��Center=�6h   .+�51      $   FusilControlLib.CustomDataGrid  -   5          Name$ dgBody��51   ,   $	��150��6<   $	��500��6I   &	   System.Windows.Controls.DataGrid 	  AutoGenerateColumns .   	  CanUserAddRows .   	  SelectionUnit$
 Cell=�6�    	  RowHeaderTemplate 52      �� 53   "   .R�54   &   ��  ��Name$ DataGridRno��60   $��25��6E   ��6P   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType)
  #System.Windows.Controls.DataGridRow" 
  �� Path$ Header� � ContextMenu 55   "   �� 56   &    ��Name$ cmRowHeader��62   .@�57   *   m�  m�Name$ miDelete��63   $��Delete��6E   58   '   5:   '   5;   #    	  Columns 5=      4  .System.Windows.Controls.DataGridComboBoxColumn  5>   "   -   5        dgColumnTaxClass��,  &System.Windows.Controls.DataGridColumn    Header$  
Tax Class*��5>   S   !   Width5  /System.Windows.Controls.DataGridLengthConverter$	! 150 6g   "   SelectedItemBinding" 6s   �� *
TaxClass+$ TwoWay=�$ PropertyChanged=�/   )FusilControlLib.CustomDataGridTextColumns  5?   "   -   5        dgColumnTaxRate��$  Tax Rate��5?   X   $	! 150 6j   1  +System.Windows.Controls.DataGridBoundColumn#   Binding# 6v   �� *	TaxRate+$ TwoWay=�$ PropertyChanged=�  5@   "   -   5        dgNarration��$  	Narration��5@   T   $	! 150 6g   # 6s   �� *	Narration+$ TwoWay=�$ PropertyChanged=�5B      5C      5D      5E      5F      5G      5H      