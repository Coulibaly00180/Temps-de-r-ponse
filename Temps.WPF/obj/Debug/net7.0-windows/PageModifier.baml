   M S B A M L   `   `   `  ����D  @Temps.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Temps.WPF	Temps.WPF  5   	       Temps.WPF.PageModifier   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Temps.WPF     5   	     � Title$  PageAjouter��5   	   $	��650��6   $
��1000��6*   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Modifier la machine��6   $��Center=�6/   $��20(�6L   $
��Bold"�6Z   $��0��6l   �� 5   
   $��1��6   .+�5      �� $��Numéro de la machine:��6   $��Center=�65   $��10q�6P   �� 5      -   5        $��NumeroTextBox��5   "   $��10q�6    �� 
IsReadOnly$
 True��67   5      �� 5   
   $��2��6   .+�5      �� $��Nom de la machine:��6   $��Center=�62   $��10q�6M   �� 5      -   5        $��
NomTextBox��5   "   $��10q�6   6"   5      �� 5!   
   $��3��6   .+�5"      �� $ ��Description de la machine:��6   $��Center=�6:   $��10q�6U   �� 5#      -   5        $��DescriptionTextBox��5#   /   $��10q�6   $	��100��6"   6/   5$      �� 5&   
   $��4��6   .+�5'      �� $ ��Date d'entrée en service:��6   $��Center=�69   $��10q�6T   (  "System.Windows.Controls.DatePicker  5(      -   5        $!��DateEntreeServiceDatePicker��5(   %   $��10q�6   6%   5)      �� 5,   
   $��SignalTime:��6   $y�	Collapsed=�6'     5-   
   -   5          Name$ SignalTimeDatePicker��5-      $y�	Collapsed=�63   �� 50   
   $��
LocalTime:��6   $y�	Collapsed=�6&     51   
   -   5        $ LocalTimeDatePicker��51      $y�	Collapsed=�62   �� 53   
   $��6��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�54      �� -   5        $��Retour��54      $��10q�6&   62   �� 55      -   5        $��Enregistrer��55      $��10q�6+   67   56      58      59      