   M S B A M L   `   `   `  ����J  FFusilControlLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:FusilControlLib;assembly=FusilControlLibFusilControlLib  5       FusilWPFApplication&    FusilWPFApplication.MasterReport   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Ecf6clr-namespace:FusilControlLib;assembly=FusilControlLib     5        � 	Resources  5	         HeaderBrush �� 
StartPoint �� EndPoint � Color � Offset��%�   &	        �� 5
   
   $	 0,1&�62   $	 0,0&�6C   .��5      � $ SkyBlue��6   $ 1Q�6+   � 5      $ 	AliceBlue��6   5      5      .��5          FusilControlLib.CustomGrid  -   5          Name$ gdReport��5      .+�5         � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � $��0��6   .+�5      %   FusilControlLib.CustomWrapPanel  -   5          Name$ wpReport��5   !    � Orientation$ Vertical=�63   $	��Top=�6J   $��Center=�6b   .+�5      �� -   5        	 ��Name$	 	spButtons��5      $��80��60   .+�5      #   FusilControlLib.CustomButtons  -   5        
  Name$
 btnAccounts��5   '   $��Accounts��6<   $��0,50,0,0q�6O   6a     5      -   5        $
 btnReg��5   '   $��Registration��67   6N     5      -   5        $
 
btnVehicle��5   '   $��Vehicle��6;   6M   5      5      5      � 5   
   $��1��6    � RowDefinitions 5      �� 5       $	��10* �6    �� 5!      $	��60* �6    .+�5#      � $��0��6   .+�5$      &    FusilControlLib.CustomStackPanel  -   5          Name$ 	spColumn2��5$   &    �� Orientation$ 
Horizontal=�69   $��Center=�6R   $
��Left=�6m   $	��400��6�   .+�5%        -   5        $
 btnView��5%   '   $
��View��68   $��5,0,0,0q�6G   6X     5&      -	   5        $
 btnClear��5&   '   $��Clear��69   $��5,0,0,0q�6I   6Z   !   FusilControlLib.CustomLabel  5'      -
   5          Name$ Report��5'   %   $��Reports Window��65   $��40��6N   $	��130��6Z   $��15(�6f   $��10,0,0,0q�6t     5(      -   5        $
 btnHome��5(   '   $
��Home��68   $��60,0,0,0q�6G   6Y   5)      5*      � 5+      $��1��6   .+�5,        -   5        $ gdReportChild��5,       5.      5/      50      51      52      53      