   M S B A M L   `   `   `  ����H  DModernHistory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ModernHistory.CustomLibModernHistory.CustomLib  5      "    ModernHistory.Others.MapPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VEsri.ArcGISRuntime, Version=10.2.7.0, Culture=neutral, PublicKeyToken=8fc3cc631e44ad866esri+http://schemas.esri.com/arcgis/runtime/2013  5      5	customlib%clr-namespace:ModernHistory.CustomLib  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5	        � DataContext  5      ��    Locator �� Source# [   �� Path$ MapPageViewModelInstance� � 	Resources 5      ��%    5      .��5      �   ContentRoot#��[ 6    � ColumnDefinitions 5   
   �� 5      $
��150* �6   �� 5      $��5* �6   �� 5      $
��500* �6   .+�5   
   � $��0��6   .+�5      �� 
�������$��1q�6)   $
��Left=�6=   $	��200��6X   $��-15,0,-109,0q�6e   $	��Top=�6{   $	��270��6�   ._�5      �� $	��200��6   .+�5      �� .+�5       �� $��名人查询��6$     Heading2#��[ 60   $��0,0,0,8q�6R   5!      �� 5#      -   5         ��Name$
 Form��5#   !    �� Orientation$ Vertical=�6/   $��10,0,0,4q�6o     6F   �� *PersonSearhModel+ 5$       �� 
TargetType �� Property	 �� Value
 �� BasedOn��%�  '��       '�� �     7��'�� �     7��'	� H    7	��� 5%      " ��6$   .�5&   "   ��  �@��Orientation$	 
Horizontal=�6@   �� 5'   "    � ��$	 0,0,0,4q�6;   5(      �� 5)      " ��6$   8
   .�5*   "   ��  � ��$	 70��6:   �� 5+   "    � ��$	 Center=�6F   5,      �� 5-      " ��6$   8
   .�5.   "   ��  � ��$		 0,3q�6<   5/      �� 50      " 	�6$   8
   .�51   "   ��  � ��$		 0,3q�6<   52      53      .+�55      �� .+�56      �� $��姓名��6$    �� Target 61   ��  �� ElementName$ TextName���� 57      -   5         ��Name$ TextName��57   &   $	��150��68   ��6D   �� *
PersonName+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . 58      �� 5;      .+�5<      �� $��省份��6$    61   �� $ ComboProvince���� 5=      -   5         ��Name$ ComboProvince��5=   '   $	��150��6>    �� SelectedItem 5>   #   �� *
Province+$ TwoWay=���5?   #   �� # [  $$ CommonConstViewModel.Provinces�5@      5A      �� 5C      .+�5D      �� $��民族��6$    61   �� $ ComboNation���� 5E      -   5        $ ComboNation��5E   '   $	��150��6<    6H   �� *Nation+$ TwoWay=���5F   #   �� # [  $" CommonConstViewModel.Nations�5G      5H      �� 5J      .+�5K      �� $��名人类型��6$    63   �� $ ComboPersonType���� 5L      -   5        $ ComboPersonType��5L   '   $	��150��6@    �� DisplayMemberPath$ FamousPersonTypeName��5M   #    5L   L   �� *FamousPersonTypeId+$ TwoWay=�  famousPersonTypeConverter �� 	Converter# [ ��5N   #   �� # [  $, &CommonConstViewModel.FamousPersonTypes�5O      5P      5Q      �� 5R      $��搜索��6   $��
100,16,0,0q�6*   $
��Left=�6>   .  (System.Windows.Interactivity.Interaction   Triggers 5S      /  )System.Windows.Interactivity.EventTrigger  5T         	EventName$ Click��6-   .  (System.Windows.Interactivity.TriggerBase   Actions. 5U   "   >  8Microsoft.Expression.Interactivity.Core.CallMethodAction     
MethodName$ SearchPersonAsync��5W         TargetObject 5V      �� 5W      5X      5Z      5[      5\      �� 5^      
�������$��1q�6)   $
��Left=�6=   $	��200��6X   $��-15,226,-79,0q�6e   $	��Top=�6|   $	��270��6�   ._�5c      �� $	��200��6   .+�5d      �� .+�5e      �� $��事件查询��6$   #��[ 60   $��0,0,0,8q�6R   5f      �� 5h      -   5        $ 	EventForm��5h   !   $ Vertical=�64   $��10,0,0,4q�6s     6K   �� *EventSearhModel+ 5i      ��%�  '��       '�� �     7��'�� �     7��'	� H    7	��� 5j      " ��6$   .�5k   "   ��  �@��Orientation$	 
Horizontal=�6@   �� 5l   "    � ��$	 0,0,0,4q�6;   5m      �� 5n      " ��6$   8
   .�5o   "   ��  � ��$	 70��6:   �� 5p   "    � ��$	 Center=�6F   5q      �� 5r      " ��6$   8
   .�5s   "   ��  � ��$		 0,3q�6<   5t      �� 5u      " 	�6$   8
   .�5v   "   ��  � ��$		 0,3q�6<   5w      5x      .+�5z      �� .+�5{      �� $��标题��6$    61   �� $ 	TextTitle���� 5|      -   5        $ 	TextTitle��5|   &   $	��150��69   ��6E   �� *Title+$ TwoWay=� . 5}      �� 5      .+�5�      �� $��发生日期��6$    63   �� $ 	DateBirth��(  "System.Windows.Controls.DatePicker  5�      -   5          Name$ 	DateBirth��5�   )      SelectedDate 6<   �� *MinOccurDate+$ TwoWay=�5�      �� 5�      .+�5�      �� $��省份��6$    61   �� $ EventComboProvince���� 5�      -	   5        $ EventComboProvince��5�   '   $	��150��6C    5�   #   �� *
Province+$ TwoWay=���5�   #   �� # [  $$ CommonConstViewModel.Provinces�5�      5�      �� 5�      .+�5�      �� $��事件类型��6$   �� 5�      -
   5        $ ComboEventType��5�   '   $	��150��6?    �� 
IsReadOnly . $ HistoryEventTypeName��6]    5�   #   �� *HistoryEventTypeId+$ TwoWay=�  historyEventTypeConverter# [ ��5�   #   �� # [  $, &CommonConstViewModel.HistoryEventTypes�5�      5�      5�      �� 5�      $��搜索��6   $��
100,16,0,0q�6*   $
��Left=�6>    5�        5�      $ Click��6-   . 5�   "     $ SearchEventAsync��5�       5�      �� 5�      5�      5�      5�      5�      �� 5�      
�������$��1q�6)   $
��Left=�6=   $��80��6X   $��-15,431,-79,-195q�6d   $	��Top=�6~   $	��270��6�   ._�5�      � .+�5�      �� $��新增名人��6   $
��Left=�6,   $��	19,10,0,0q�6G   $	��Top=�6Z   $��97��6r    5�        5�      $ Click��6-   . 5�   "     $ InsertPerson��5�       5�      �� 5�      5�      5�      �� 5�      $��查询名人��6   $
��Left=�6,   $��
146,10,0,0q�6G   $	��Top=�6[   $��93��6s    5�        5�      $ Click��6-   . 5�   "     $ QueryPerson��5�       5�      �� 5�      5�      5�      �� 5�      $��新增事件��6   $
��Left=�6,   $��	19,45,0,0q�6G   $	��Top=�6Z   $��97��6r    5�        5�      $ Click��6-   . 5�   "     $ InsertEvent��5�       5�      �� 5�      5�      5�      �� 5�      $��查询事件��6   $
��Left=�6,   $��
146,45,0,0q�6G   $	��Top=�6[   $��93��6s    5�        5�      $ Click��6-   . 5�   "     $ 
QueryEvent��5�       5�      �� 5�      5�      5�      5�      5�      5�      � 5�   
   -   5         �Name$ mapGrid��5�       $��2��6    5�        5�      $ Loaded��6!   . 5�      6  0System.Windows.Interactivity.InvokeCommandAction     Command 5�   !   �� *MapPageLoadedCommand+   CommandParameter 5�   !   �� $ mapGrid��5�       5�      3  -Esri.ArcGISRuntime.Symbology.SimpleFillSymbol  RedFillSymbol   Color    Outline3  -Esri.ArcGISRuntime.Symbology.SimpleLineSymbol!   Color"   Width��%m   &	         5�      $ 	#22FF0000��6>     5�        5�      $	! Red��60   $" 2Q�6<   5�      5�      .+�5�      )	  #Esri.ArcGISRuntime.Controls.MapView	  -   5        # 	 Name$# mainMap��5�       5�        5�      $ ExtentChanged��6%   . 5�        $ MyMapView_ExtentChanged��6S    6.   �� $ OneWay=�6S   5�        5�      $ 	MouseDown��6%   . 5�        $ MapView_MouseDown��6T    6.   �� $ OneWay=�6T   5�        5�      $ 	MouseMove��6%   . 5�        $ MyMapView_MouseMove��6T    6.   �� $ OneWay=�6T   5�      
$ 	  Map.$ 5�      %
  Esri.ArcGISRuntime.Controls.Map
  % 
  Layers.% 5�      ,   &ModernHistory.CustomLib.AmapTiledLayer  -  'Esri.ArcGISRuntime.Layers.GraphicsLayer  5�      %  Esri.ArcGISRuntime.Layers.Layer	&   ID$& personsLayer��6)     5�      $& eventsLayer��6)   5�      *  $Esri.ArcGISRuntime.Controls.ViewBase'   Overlays' 5�      5  /Esri.ArcGISRuntime.Controls.OverlayItemsControl  5�      (   Items.( 5�      �� 
�������
���  ��$��1q�6F   $	��300��5�   !   $	��250��6-   ) �� Padding$) 4q�5�   !   $
��Left=�6-   $	��Top=�6H   $��4q�6`     5�   !   �� *PersonTipGraphic+y�5�   !   �� # [  $2 ,MapPageViewModelInstance.PersonTipVisibility�*   ViewOverlayAnchor* 5�   !   �� *
Geometry+._�5�      �� .+�5�   "   �� $	��300��6�   $	��160��6�   $��UniformToFill=�6�   ��6(   �� *Attributes[PersonId]+  personImageConverter# [ 6�   �� 5�   "   ��6,   �� *Attributes[PersonId]++ �� StringFormat$+ 编号: {0}���� 5�   "   ��6,   �� *Attributes[PersonName]+$+ 
姓名:{0}��6l   �� 5�   "   ��6,   �� *Attributes[Place]+$+ 地点: {0}���� 5�   "   ��6,   �� *Attributes[BornDate]+$+ 出生日期日期: {0}��5�      5�      �� 5�      
�������
���  ��$��1q�6F   $	��300��5   !   $	��250��6-   $) 4q�5  !   $
��Left=�6-   $	��Top=�6H   $��4q�6`     5  !   �� *EventTipGraphic+y�5  !   �� # [  $1 +MapPageViewModelInstance.EventTipVisibility�* 5  !   �� *
Geometry+._�5     �� .+�5  "   �� $	��300��6~   $	��160��6�   $��UniformToFill=�6�   ��6(   �� *Attributes[EventId]+  eventImageConverter# [ 6�   �� 5  "   ��6,   �� *Attributes[EventId]+$+ 编号: {0}���� 5  "   ��6,   �� *Attributes[Title]+$+ 
标题:{0}��6g   �� 5	  "   ��6,   �� *Attributes[Place]+$+ 地点: {0}���� 5
  "   ��6,   �� *Attributes[OccurDate]+$+ 日期: {0}��5     5     5     5     �� 5     
�������
���   �$��1q�6<   $��Bottom=�6P   $��	0,358,0,0q�5     $) 20q�6   $��Right=�6$   , J� Effect, 5     3  -System.Windows.Media.Effects.DropShadowEffect  5     ._�5     	  -   5        $# overviewMap��5     $	��150��64   $��90��6@    5       5     $ LayerLoaded��6)   . 5       $ OverviewMap_LayerLoaded��6W    62   �� $ OneWay=�6W   5     -   GraphicsOverlays- 5     1  +Esri.ArcGISRuntime.Controls.GraphicsOverlay  	.   ID$. overviewOverlay��6/   /   Renderer/ 5     1  +Esri.ArcGISRuntime.Symbology.SimpleRenderer  5  "   0   Symbol.0 5   &     $ 	#22FF0000��6<     5!  *     5"  .   $	! Red��6D   $" 2Q�6P   5$  '   5%  #   5'     .$ 5*     
  .% 5+       5,     5-     5.     �� 5/     
������ $��1q�6/   $
��Left=�6C   $��20��6^   $��
0,427,0,-2q�6j   $��Bottom=�6~   $	��258��6�   , 50       51     ._�53     �� $ 
Horizontal=�6   .+�54     �� $��12(�6k   $
��Bold"�6y   
���   ���6    �� $ mainMap��$+ 当前比例尺:{0}��$ Scale�6�   57     58     59     5:     5;     