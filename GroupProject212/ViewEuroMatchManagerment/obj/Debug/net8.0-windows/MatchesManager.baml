   M S B A M L   `   `   `  ����S  OViewEuroMatchManagerment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ViewEuroMatchManagermentViewEuroMatchManagerment  5   	   -    'ViewEuroMatchManagerment.MatchesManager   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ViewEuroMatchManagerment     5   	   -   5          � Title$  MatchesManager��5   	   $	��553��5	   	   $	��850��5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Matches Management��6   $��Center=�5      $	��Top=�5      $��0��5      $��0��5      $��2��5      $��	0,10,0,10q�5      $��24(�5       $
��Bold"�5!      
����  �5"      �� 5%   
   
�������
���   �$��1q�5'      $��1��5(      $��0��5)      $��2��5*      $��10q�5+      ._�5,      � $��10q�6    5-      �� 5.      $
��Auto �6'   �� 5/      $��* �6'   �� 50      $
��Auto �6'   �� 51      $
��Auto �6'   �� 52      $
��Auto �6'   .+�54      �� $��	Home Team��6   $��Center=�55      $��5q�56      �� 57      -   5         ��Name$ HomeTeamTextBox��57      $��1��58       �� TextAlignment$
 Left=�59      $��5q�5:       �� TextWrapping$
 Wrap=�5;      $��Center=�5<      $	��120��5=      
����  �5>      �� 5?      $��
Guest Team��6   $��Center=�5@      $��5q�5A      $��2��5B      �� 5C      -   5        $ GuestTeamTextBox��5C      $��3��5D      $
 Left=�5E      $��5q�5F      $
 Wrap=�5G      $��Center=�5H      $	��120��5I      
����  �5J      �� 5K      -   5         ��Name$ SearchButton��5K      $��4��5L      $��Search��5M      $��Center=�5N      $��5q�5O      $��75��5Q      5R      5S      &   System.Windows.Controls.DataGrid  5V   
   -   5          Name$ ListMatchesDataGrid��5V      $��2��5W      $��	10,20,0,0q�5X         AutoGenerateColumns$ False��5Y      	   AlternatingRowBackground
	 �����
   RowBackground

 �����   GridLinesVisibility$ 
Horizontal=�5]         CanUserAddRows$ False��5^         CanUserDeleteRows$ False��5_         CanUserResizeRows$ False��5`      
�������
�������$��1q�5c      $
��Left=�5d      $	��710��5e         Columns 5f      0  *System.Windows.Controls.DataGridTextColumn  5g      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5h   %   �� *Id+  5i      $ 	Home Team��6%    5j   %   �� *
TeamA.Name+  5k      $ 
Guest Team��6%    5l   %   �� *
TeamB.Name+  5m      $ Location��6%    5n   %   �� *Location.Name+4  .System.Windows.Controls.DataGridTemplateColumn  5o      $ Image Stadium��6)      CellTemplate 5p      �� 5q      .R�5r      �� $	��100��6M   $	��100��6Y   $��UniformToFill=�6f   $��Center=�5s      $��Center=�5t      ��5r   $   �� *Location.ImageStadium+5t      5u      5w        5x      $ 
Attendance��6%    5y   %   �� *
Attendance+  5z      $ Home Team Goals��6%    5{   %   �� *	GoalTeamA+  5|      $ Guest Team Goals��6%    5}   %   �� *	GoalTeamB+5      �� 5�   
   $��2��6   $��1��5�      $��10q�5�      $	��Top=�5�      $��Center=�5�      .+�5�      �� -   5        $ 	AddButton��5�      $	��Add��5�      $��38��5�      $��75��5�      $	��0,5q�5�      ���#4CAF50
����������#388E3C$��2q�5�      �� 5�      -   5        $ UpdateButton��5�      $��Update��5�      $��37��5�      $��75��5�      $	��0,5q�5�      ���#03A9F4
����������#0288D1$��2q�5�      �� 5�      -   5        $ DeleteButton��5�      $��Delete��5�      $��37��5�      $��75��5�      $	��0,5q�5�      ���#F44336
����������#D32F2F$��2q�5�      �� 5�      -	   5        $ ExportButton��5�      $��Export��5�      $��38��5�      $��75��5�      $	��0,5q�5�      ���#FFC107
����������#FFA000$��2q�5�      �� 5�      -
   5        $ 
QuitButton��5�      $
��Quit��5�      $��37��5�      $��75��5�      $	��0,5q�5�      ���#FF5722
����������#E64A19$��2q�5�      �� 5�      -   5        $ ClearDataButton��5�      $��
Clear Data��6.   ���#4CAF50
�������$��16(�5�       J� RenderTransformOrigin$ 0.531,-0.769&�5�      $��37��6>   5�      5�      5�      