   M S B A M L   `   `   `  ����J  FFusilControlLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:FusilControlLib;assembly=FusilControlLibFusilControlLib  5       FusilWPFApplication*   $FusilWPFApplication.AccountsReportUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ecf6clr-namespace:FusilControlLib;assembly=FusilControlLib     5      .��5	          FusilControlLib.CustomGrid  -   5           Name$  gdAccountsReport��5	       � RowDefinitions 5
   
   �� 5      $��30 �6   �� 5      $
��auto �6   .+�5   
   � $��0��6   .+�5      #   FusilControlLib.CustomTextBox  -   5          Name$ tbFilter��5      $��5,0,0,0q�61   ��6B   �� *Filter+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5      � 5   
   $��1��6   .+�5   
   %   FusilControlLib.CustomWrapPanel  -   5          Name$ wpAccountReport��5      .+�5      $   FusilControlLib.CustomDataGrid  -   5          Name$ dgAccountsReport��5       &   System.Windows.Controls.DataGrid   CanUserAddRows .     AutoGenerateColumns .  	   SelectionUnit$
	 Cell=�6m   $	��500��6�   
   Columns
 5      /   )FusilControlLib.CustomDataGridTextColumns  5      -   5        dgColumnSno��,  &System.Windows.Controls.DataGridColumn   Header$	 Sno��5   H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6U   �� *Sno+$ TwoWay=�$ PropertyChanged=�  5      -   5        dgColumnName��$
 Name��5   I    6W   �� *Name+$ TwoWay=�$ PropertyChanged=�4	  .System.Windows.Controls.DataGridComboBoxColumn	  5      -   5        dgColumnTaxClass��$ 
Tax Class*��5   G      Width5
  /System.Windows.Controls.DataGridLengthConverter$	 120
 6[    	  SelectedItemBinding 6g   �� *
TaxClass+$ TwoWay=�$ PropertyChanged=�  5      -   5        dgColumnCode��$
 Code��5   I    6W   �� *Code+$ TwoWay=�$ PropertyChanged=�  5      -	   5        dgColumnDesc��$
 Desc��5   I    6W   �� *Desc+$ TwoWay=�$ PropertyChanged=�  5      -
   5        dgColumnTaxRate��$ Tax Rate��5   L    6^   �� *	TaxRate+$ TwoWay=�$ PropertyChanged=�  5      -   5        dgColumnNarration��$ 	Narration��5   N    6a   �� *	Narration+$ TwoWay=�$ PropertyChanged=�5      5      5      5       5!      