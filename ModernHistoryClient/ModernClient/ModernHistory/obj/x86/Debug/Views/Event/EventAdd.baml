   M S B A M L   `   `   `  ����  ModernHistory(    "ModernHistory.Views.Event.EventAdd   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      N JFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=null0mui&http://firstfloorsoftware.com/ModernUI  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5        � DataContext  5      ��    Locator �� Source# [   �� Path$ EventAddViewModel�.��5      ]� .+�5   
   �� $	��Top=�6   .+�5      �� $��新增事件��6     Heading2#��[ 6$   $��0,0,0,8q�6F   5      �� 5   
   $
��Left=�6   .��5      �� $	��300��6   .+�5      �� -   5         ��Name$
 Form��5       �� Orientation$ Vertical=�6+     6B   �� *HistoryEvent+ � 	Resources 5       �� 
TargetType �� Property �� Value	 �� BasedOn��%�  '��       '�� �     7��'�� �     7��'	� I    7	��� 5      " ��6    .�5      ��  �@��Orientation$ 
Horizontal=�6<   �� 5       � ��$ 0,0,0,4q�67   5      �� 5      " ��6    8	   .�5      ��  � ��$	 150��66   �� 5       � ��$ Center=�6B   5      �� 5      " ��6    8	   .�5      ��  � ��$	 0,3q�68   5      �� 5       " 	�6    8	   .�5!      ��  � ��$	 0,3q�68   5"      5#      .+�5%      �� .+�5&      �� $��标题��6    
 �� Target
 6-   ��  �� ElementName$ 	TextTitle���� 5'      -   5         ��Name$ 	TextTitle��5'   "   $	��150��65   ��6A   �� *Title+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . 5(      �� 5*      .+�5+      �� $��发生日期��6    
 6/   �� $ 	DateBirth��(  "System.Windows.Controls.DatePicker  5,      -   5          Name$ 	DateBirth��5,   %      SelectedDate 68   �� *	OccurDate+$ TwoWay=�5-      �� 5/      .+�50      �� $��省份��6    
 6-   �� $ ComboProvince���� 51      -   5         ��Name$ ComboProvince��51   #   $	��150��6:    �� SelectedItem 52   #   �� *
Province+$ TwoWay=���53   #   �� # [  $$ CommonConstViewModel.Provinces�54      55      �� 57      .+�58      �� $��地点��6    
 6-   �� $ 	TextPlace���� 59      -   5        $ 	TextPlace��59   "   $	��150��65   ��6A   �� *Place+$ TwoWay=� . 5:      �� 5<      .+�5=      �� $��经度��6    
 6-   �� $ 
TextOccurX���� 5>      -   5        $ 
TextOccurX��5>   "   $	��150��66   ��6B   �� *OccurX+$ TwoWay=� . 5?      �� 5A      .+�5B      �� $��纬度��6    
 6-   �� $ 
TextOccurY���� 5C      -   5        $ 
TextOccurY��5C   "   $	��150��66   ��6B   �� *OccurY+$ TwoWay=� . 5D      �� 5F      .+�5G      �� $��事件类型��6    �� 5H      -   5        $ ComboEventType��5H   #   $	��150��6;    �� 
IsReadOnly .  �� DisplayMemberPath$ HistoryEventTypeName��6Y    5I   #   �� *HistoryEventTypeId+$ TwoWay=�  historyEventTypeConverter �� 	Converter# [ ��5J   #   �� # [  $, &CommonConstViewModel.HistoryEventTypes�5K      5L      �� 5N      .+�5O      �� $��详细信息��6    
 6/   �� $ 
TextDetail���� 5P      -	   5        $ 
TextDetail��5P   "   $	��200��66   $	��150��6B    �� TextWrapping$
 Wrap=�5Q   "    �� AcceptsReturn . " �� VerticalScrollBarVisibility$ Visible=�6L   ��5R   "   �� *Detail+$ TwoWay=� . 5S      5T      �� 5U      $��确认修改��6   $��
100,16,0,0q�6(   $
��Left=�6<   .  (System.Windows.Interactivity.Interaction   Triggers 5V      /  )System.Windows.Interactivity.EventTrigger  5W         	EventName$ Click��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5X      >  8Microsoft.Expression.Interactivity.Core.CallMethodAction     
MethodName$ 	SaveAsync��5Z   !      TargetObject 5Y   !   �� 5Z   !   5[      5]      5^      5_      �� 5`   
   $��Right=�6   .+�5a      �� $��选择图片��6    5b        5c      $ Click��6%   . 5d        $ ChooseImage��6L    61   �� 6L   5e      5g      �� 5h      $
��None=�61   ��6   �� *	SelectImg+6B   5i      5j      5k      