   M S B A M L   `   `   `  ����S  OViewEuroMatchManagerment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ViewEuroMatchManagermentViewEuroMatchManagerment  5   	   '    !ViewEuroMatchManagerment.TeamView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:ViewEuroMatchManagerment     5   	     � Title$  TeamView��5   	   $	��450��5	   	   $	��800��5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Team Management��6   $��Center=�5      $	��Top=�5      $��0��5      $��0��5      $��2��5      $��	0,10,0,10q�5      $��24(�5      $
��Bold"�5      
����  �5       �� 5#   
   
�������
���   �$��1q�5%      $��1��5&      $��0��5'      $��2��5(      $��10,10,10,10q�5)      ._�5*      � $��10q�6    5+      �� 5,      $
��Auto �6'   �� 5-      $��* �6'   �� 5.      $
��Auto �6'   .+�50      �� $��
Team Name:��6   $��Center=�51      $��5q�52      �� 53      -   5         ��Name$ TeamTitleTextBox��53      $��1��54       �� TextAlignment$
 Left=�55      $��5q�56       �� TextWrapping$
 Wrap=�57      $��Center=�58      $	��150��59      
����  �5:      �� 5;      -   5         ��Name$ SearchButton��5;      $��2��5<      $��Search��5=      $��Center=�5>      $��5q�5?      $��75��5A      5B      5C      &   System.Windows.Controls.DataGrid  5F   
   -   5          Name$ dtgTeam��5F      $��2��5G      $��0��5H      $��10,10,10,10q�5I         AutoGenerateColumns$ False��5J      
�������
�������$��1q�5N      5P      �� 5S   
   $��2��6   $��1��5T      $��10q�5U      $	��Top=�5V      $��Center=�5W      .+�5X      �� -   5        $ 	btnCreate��5X      $��Create��5Y      $��38��5Z      $��75��5[      $	��0,5q�5\      ���#4CAF50
����������#388E3C$��2q�5a      �� 5b      -   5        $ 	btnUpdate��5b      $��Update��5c      $��37��5d      $��75��5e      $	��0,5q�5f      ���#03A9F4
����������#0288D1$��2q�5k      �� 5l      -   5        $ 	btnDelete��5l      $��Delete��5m      $��37��5n      $��75��5o      $	��0,5q�5p      ���#F44336
����������#D32F2F$��2q�5u      �� 5v      -   5        $ 	btnExport��5v      $��Export��5w      $��38��5x      $��75��5y      $	��0,5q�5z      ���#FFC107
����������#FFA000$��2q�5      �� 5�      -   5        $ btnQuit��5�      $
��Quit��5�      $��37��5�      $��75��5�      $	��0,5q�5�      ���#FF5722
����������#E64A19$��2q�5�      5�      5�      5�      