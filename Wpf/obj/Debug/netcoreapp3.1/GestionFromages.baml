   M S B A M L   `   `   `  ����>  :Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfClubFromageWpfClubFromage  5   	   $    WpfClubFromage.GestionFromages   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WpfClubFromage     5   	     � Title$  Affichage des fromages��5   	   $	��450��6(   $	��800��65   .��5	      � -   5         �Name$ mainGrid��5	       � ColumnDefinitions 5
   
   �� 5      �� 5      $��1 �6   �� 5      .+�5   
   �� -   5         ��Name$ listFromagesView��5      $ �� IsSynchronizedWithCurrentItem$
 TrueY�6z   $��0��6�   ��6,   �� *ListFromages+ �� SelectedItem 6Q   �� *SelectedFromage+6�   �� 5   
   $��1��6   � 5   
   -   5        $ displayFromage��5      $��2��6'    5      �� 5      $��* �6#   �� 5      $��2* �6#    � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� $��Nom Fromage��6   $��0��6*   $��0��67   $
��Left=�6G   $��Center=�6b   $��10q�6}   �� 5      -   5         ��Name$ 
nomFromage��5      $��0��6@   $��1��6M   $��Stretch=�6]   $��Center=�6{   $��10q�6�   ��6*   �� *Name+6�   �� 5      $��Origine��6   $��1��6&   $��0��63   $
��Left=�6C   $��Center=�6^   $��10q�6y   �� 5       -   5         ��Name$ 
listOrigin��5       $
 TrueY�6z   $��1��6�   $��1��6�   $��Stretch=�6�   $��Center=�6�   $��10q�6�   ��6+   �� *
ListPays+	 �� Mode$	 OneTime=� 6Z   �� *Origin+6�   �� 5!      $��Date de création��6   $��2��6/   $��0��6<   $
��Left=�6L   $��Center=�6g   $��10q�6�   (  "System.Windows.Controls.DatePicker  5"      -   5        
  Name$
 dateCreation��5"      $��2��6Q   $��1��6^   $��Stretch=�6n   $��Center=�6�   $��10q�6�      SelectedDate 6/   �� *
Creation+6�   �� 5#      $��Image du fromage��6   $��3��6/   $��0��6<   $
��Left=�6L   $��Center=�6g   $��10q�6�   �� 5$      -   5         ��Name$ imageFromage��5$      $��3��6C   $��1��6P   $
��Left=�6`   $��81��6{   $	��143��6�   $��30,3,0,3q�6�   ��6*   �� *Image+6�   �� 5%      -   5        $ imageFromageSource��5%      $	��Top=�6O   $��
10,57,15,0q�6g   $��3��6{   ��62   �� *ImageSource+6{   �� 5&      -	   5         ��Name$ imageFileDialog��5&      $��Source��6.   $��3��6j   $��0��6w   $��21,11,26,51q�6�   ��6?   �� *ImageFileDialogCommand+6�   �� 5'      -
   5        $ updateFromage��5'      $��Sauvegarder��6,   $��4��6d   $��10,10,10,10q�6q   ��6B   �� *UpdateCommand+6q   �� 5(      -   5        $ deleteFromage��5(      $��	Supprimer��6,   $��4��6b   $��133,10,144,10q�6o   $��2��6�   ��6@   �� *DeleteCommand+6�   �� 5)      -   5        $ createFromage��5)      $��Nouveau��6,   $��4��6`   $��133,10,14,10q�6m   $��1��6�   ��6>   �� *CreateCommand+6�   5*      5+      5,      