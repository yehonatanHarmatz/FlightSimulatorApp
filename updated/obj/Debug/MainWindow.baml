   M S B A M L   `   `   `  ����J  FFlyingSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:FlightSimulatorAppFlightSimulatorApp  5   	   C&clr-namespace:FlightSimulatorApp.ViewsFlightSimulatorApp.Views  5   	   #    FlightSimulatorApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:FlightSimulatorApp     5   	   8views&clr-namespace:FlightSimulatorApp.Views     5   	   -   5          � Title$  
MainWindow��5	   	   $	��600��6   $
��1000��6)   .��5      �  J� RenderTransformOrigin$ 10,10&�6    � ColumnDefinitions 5   
   �� 5      $
��0.2* �6   6.   �� 5      $��8* �6   6,   �� 5      $
��0.4* �6   6.   �� 5      $��5* �6   6,   �� 5      $
��0.2* �6   6.    � RowDefinitions 5   
   �� 5      $
��0.3* �6   6,   �� 5      $��4* �6   6*   �� 5      $
��0.7* �6   6,   �� 5      $��8* �6   6*   �� 5      $
��0.3* �6   6,   .+�5   
   �� $��3��6   $��3��6!   ��5      �� 5       �� Color$ 	SlateGray��6"   5      �� 5    
   $��1��6   $��3��6!   ��5!      �� 5"      $ 	SlateGray��6"   5$      �� 5%   
   $��0��6   $��5��6!   ��5&      �� 5'      $ 	LightBlue��6"   5)      �� 5*   
   $��0��6   $��5��6$   ��5+      �� 5,      $ 	LightBlue��6"   5.      �� 5/   
   $��2��6   $��5��6$   ��50      �� 51      $ 	LightBlue��6"   53      �� 54   
   $��4��6   $��5��6$   ��55      �� 56      $ 	LightBlue��6"   58      �� 59   
   $��2��6   $��3��6!   ��5:      �� 5;      $ 	LightBlue��6"   5=      �� 5>   
   $��4��6   $��5��6!   ��5?      �� 5@      $ 	LightBlue��6"   5B      (� 5C   
   $��3��6   $��3��6"   .��5D      (   "FlightSimulatorApp.Views.Navigator  -   5          Name$ 	navigator��5D      $��Stretch=�61   $��Stretch=�6M   6m   5E      (� 5F   
   $��3��6   $��1��6"   .��5G      $   FlightSimulatorApp.Views.Panel  -   5          Name$ panel��5G      $��Stretch=�6)   $��Stretch=�6E   6e   5H      5I      5J      