   M S B A M L   `   `   `  ����S  OProyectoPruebaBasesDatos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProyectoPruebaBasesDatosProyectoPruebaBasesDatos  5   	   )    #ProyectoPruebaBasesDatos.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ProyectoPruebaBasesDatos     5   	   -   5          � Title$  
MainWindow��5   	   $	��500��6   $	��800��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��3* �6   �� 5      $��4* �6    � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��1* �6   .+�5   
   �� $��20(�6   $��Clientes��6   $
��Left=�61   $	��Top=�6L   $��	10,10,0,0q�6d   �� 5   
   -   5        $��listaClientes��5      $��0��6'   $��0��64   $��10,40,10,10q�6D   6Y   �� 5   
   $��20(�6   $��Pedidos��6   $
��Left=�60   $	��Top=�6K   $��1��6c   $��	10,10,0,0q�6s   �� 5   
   -   5        $��listaPedidos��5      $��0��6&   $��1��63   $��10,40,10,10q�6C   �� 5   
   $��19(�6   $��Todos Los Pedidos��6   $
��Left=�6:   $	��Top=�6U   $��2��6m   $��	10,10,0,0q�6}   �� 5   
   -   5        $��listaGeneralPedidos��5      $��0��6-   $��2��6:   $��10,40,10,10q�6J   �� 5!   
   -   5        $��20(�5!      $��Borrar��6   $
��Left=�60   $	��Top=�6K   $��31��6c   $	��122��6o   $��	10,10,0,0q�6{   $��1��6�   $��2��6�   �� 5"   
   -   5        $��Insertar��5"      $
��Left=�6$   $	��Top=�6?   $��33��6W   $��78��6c   $��	10,38,0,0q�6n   $��1��6�   $��0��6�   �� 5#   
   -   5        $��Borrar��5#      $
��Left=�6"   $	��Top=�6=   $��33��6U   $��74��6a   $��	93,38,0,0q�6l   $��1��6   6�   �� 5%   
   -   5        $��instertaCliente��5%      $
��Left=�6)   $	��Top=�6D   $	��157��6\   $��23��6h   $��	10,10,0,0q�6t   $��1��6�   $��0��6�   �� 5&   
   -	   5        $��
actualizar��5&      $��20(�6#   $��1��61   $��
Actualizar��6A   $��Center=�6V   $��0,41,0,0q�6s   $��1��6�   $	��Top=�6�   $��30��6�   $	��246��6�   6�   5'      5(      