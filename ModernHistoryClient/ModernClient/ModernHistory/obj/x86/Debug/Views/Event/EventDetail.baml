   M S B A M L   `   `   `  ����  ModernHistory+    %ModernHistory.Views.Event.EventDetail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      N JFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=null0mui&http://firstfloorsoftware.com/ModernUI  5        � DataContext  5	      ��    Locator �� Source# [   �� Path$ EventsInfoViewModel�.��5
      ]�   6   �� *SelectHistoryEvent+.+�5   
   �� $	��Top=�6   .+�5      �� $��事件信息��6     Heading2#��[ 6$   $��0,0,0,8q�6F   5      �� 5   
   $
��Left=�6   .��5      �� $	��300��6   .+�5      �� -   5         ��Name$
 Form��5       �� Orientation$ Vertical=�6+    � 	Resources 5       �� 
TargetType �� Property �� Value	 �� BasedOn��%�  '��       '�� �     7��'�� �     7��'	� I    7	��� 5      " ��6    .�5      ��  �@��Orientation$ 
Horizontal=�6<   �� 5       � ��$ 0,0,0,4q�67   5      �� 5      " ��6    8	   .�5      ��  � ��$	 150��66   �� 5       � ��$ Center=�6B   5      �� 5      " ��6    8	   .�5      ��  � ��$	 0,3q�68   5      �� 5      " 	�6    8	   .�5      ��  � ��$	 0,3q�68   5       5!      .+�5#      �� .+�5$      �� $��标题��6    �� 5%      -   5        
 ��Name$
 	TextTitle��5%   "   $	��150��65    �� 
IsReadOnly . ��6A   �� *Title+6X   5&      �� 5(      .+�5)      �� $��发生日期��6    (  "System.Windows.Controls.DatePicker  5*      -   5          Name$ 	DateBirth��5*   %   {�.     SelectedDate 68   �� *	OccurDate+ �� Mode$ TwoWay=�6g   5+      �� 5-      .+�5.      �� $��省份��6    �� 5/      -   5        $
 TextProvince��5/   "   $	��150��68    . ��6D   �� *
Province+.��6p   50      51      �� 53      .+�54      �� $��地点��6    �� 55      -   5        $
 	TextPlace��55   "   $	��150��65    . ��6A   �� *Place+6X   56      �� 58      .+�59      �� $��经度��6    �� 5:      -   5        $
 
TextOccurX��5:   "   $	��150��66    . ��6B   �� *OccurX+6Z   5;      �� 5=      .+�5>      �� $��纬度��6    �� 5?      -   5        $
 
TextOccurY��5?   "   $	��150��66    . ��6B   �� *OccurY+6Z   5@      �� 5B      .+�5C      �� $��事件类型��6    �� 5D      -   5         ��Name$ ComboEventType��5D   #   $	��150��6;    �� 
IsReadOnly .  �� DisplayMemberPath$ HistoryEventTypeName��6Y    �� SelectedItem 5E   #   �� *HistoryEventId+$ TwoWay=�  historyEventTypeConverter �� 	Converter# [ ��5F   #   �� # [  $, &CommonConstViewModel.HistoryEventTypes�5G      5H      �� 5J      .+�5K      �� $��详细信息��6    �� 5L      -	   5        $
 
TextDetail��5L   "   $	��200��66   $	��150��6C    �� TextWrapping$
 Wrap=�5M   "    �� AcceptsReturn . " �� VerticalScrollBarVisibility$ Visible=�6L    . ��5N   "   �� *Detail+6:   5O      5P      � 5Q      .+�5R      �� $��修改��6   $��33,10,236,10q�6*   $#��mui:LinkCommands.NavigateLink��6@   $!��/Views/Event/EventEdit.xaml��5S      �� 5T      $��删除��6   $��238,10,31,10q�6*   $#��mui:LinkCommands.NavigateLink��6@   $*��$/Views/Event/EventDeleteConfirm.xaml��5U      5V      5W      5X      �� 5Y   
   $��Right=�6   .+�5Z      �� $
��None=�6i   ��6   �� *HistoryEventId+  eventImageConverter# [ 5]      5^      5_      5`      