   M S B A M L   `   `   `  ����L  HCadastroWPF, Version=1.20.819.1226, Culture=neutral, PublicKeyToken=null)clr-namespace:CadastroWPFCadastroWPF  5   	   7 clr-namespace:CadastroWPF.ModelsCadastroWPF.Models  5   	   =#clr-namespace:CadastroWPF.ViewModelCadastroWPF.ViewModel  5   	       CadastroWPF.UserWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:CadastroWPF     5   	   6	converter clr-namespace:CadastroWPF.Models     5   	   9	viewModel#clr-namespace:CadastroWPF.ViewModel     5   	     � Title$  Cadastro de Contatos��5
   	   $	��463��6&   $	��807��63    � WindowStyle$ 
ToolWindow=�6?    � WindowStartupLocation$ CenterScreen=�6X    � 	Resources 5      '  !CadastroWPF.Models.PhoneConverter   phoneconverter)   #CadastroWPF.ViewModel.UserViewModel  userViewModel��%:   &	        &	        5   
   6#     5   
   6"   5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ GridUser��5      $
��Left=�5      $	��357��6.   $��
340,10,0,0q�6;   $	��Top=�6O   $	��449��6g   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5      #��[ 5         AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *Id+  5      $
	 Nome��6%   
 63   �� *Name+  5      $	 	Sobrenome��6%   
 68   �� *
LastName+  5      $	 Telefone��6%   
 67   �� *Phone+ �� 	Converter# [  5      �� 5    
   $��Id��6   $
��Left=�5!      $��24��5"      $��	10,27,0,0q�6   $	��Top=�5#      $��84��5$      �� 5&   
   -   5         ��Name$ txtId��5&      $
��Left=�5'      $��24��5(      $��	99,27,0,0q�5)       �� TextWrapping$
 Wrap=�5*      {�.  $	��Top=�5-      $��58��5.      ��5+      �� *Id+5.      �� 50   
   $
��Nome��6   $
��Left=�51      $��25��52      $��	10,54,0,0q�53      $	��Top=�54      $��84��55      �� 57   
   -   5        $ txtName��57      $
��Left=�58      $��24��59      $��	99,55,0,0q�6   $
 Wrap=�5:      $	��Top=�5<      $	��225��5=      ��5;      �� *Name+5=      �� 5?   
   $��	Sobrenome��6   $
��Left=�5@      $��23��5A      $��	10,83,0,0q�5B      $	��Top=�5C      $��84��5D      �� 5F   
   -   5        $ txtLastName��5F      $
��Left=�5G      $��24��5H      $��	99,83,0,0q�5I      $
 Wrap=�5J      $	��Top=�5L      $	��225��5M      ��5K      �� *
LastName+5M      �� 5O   
   $��
Telefone
��6   $
��Left=�5P      $��25��5Q      $��
10,111,0,0q�5R      $	��Top=�5S      $��84��5T      �� 5V   
   -   5        $ txtPhone��5V      $
��Left=�5W      $��24��5X      $��
99,111,0,0q�5Y      $
 Wrap=�5Z       �� 	MaxLength$ 12��5]      $	��Top=�5^      $	��225��5_      ��5[      �� *Phone+# [  5_      �� 5b   
   -   5         ��Name$ 	btnInsert��5b      $��Inserir��5c      $
��Left=�5d      $��
10,393,0,0q�5e      $	��Top=�5f      $��75��5g      5h      �� 5j   
   -   5        $ 	btnUpdate��5j      $��Alterar��5k      $
��Left=�5l      $��
95,393,0,0q�5m      $	��Top=�5n      $��75��5o      5p      �� 5r   
   -   5        $ 	btnDelete��5r      $��Excluir��5s      $
��Left=�5t      $��178,393,0,0q�5u      $	��Top=�5v      $��75��5w      5x      �� 5z   
   -	   5        $ btnConfirmar��5z      $��	Confirmar��5{      $
��Left=�5|      $��340,393,0,0q�5}      $	��Top=�5~      $��75��5      5�      �� 5�   
   -
   5        $ btnCancelar��5�      $��Cancelar��5�      $
��Left=�5�      $��420,393,0,0q�5�      $	��Top=�5�      $��75��5�      5�      �� 5�   
   -   5        $ btnSair��5�      $
��Sair��5�      $
��Left=�5�      $��714,393,0,0q�5�      $	��Top=�5�      $��75��5�      5�      5�      5�      