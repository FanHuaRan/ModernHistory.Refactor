   M S B A M L   `   `   `  ����H  DModernHistory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ModernHistoryModernHistory  5   	       ModernHistory.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   N JFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=null0mui&http://firstfloorsoftware.com/ModernUI  5   	   $myclr-namespace:ModernHistory  5   	     � Title$$  近代名人事件信息系统��5   	   7  1FirstFloor.ModernUI.Windows.Controls.ModernWindow   IsTitleVisible .    LogoData� ��|�{h���l�~���ӴL����$:�<��C<��p�<L^��������ф�̴�ӄ��n�$�W`�F�W���d�W<�w@Xt�}̴�� ~o�"%���:���C�:��P���:� -�"%��	h�����@Xt0�"��W��@��W�|�c��W|�{�n|�{h���܄��:�����:`-�m``-����`-��
����(d�܄�(d��P6i(d���B�
���B��Ӽ�Bm`P6i�:܄��:�$&��:Ӱt�:D�Dm`D�D���D�D�
��t(d�$&�(d�Ә׿(d��}��
��}���Ӡ}�m`�׿�:$&��:$
��1200��5	   	   $	��600��6    � WindowStartupLocation$ CenterScreen=�5
   	      ContentSource$ /Views/MapPage.xaml?�6.    � DataContext 5   	   ��    Locator �� Source# [   �� Path$ MainPageViewModel�   MenuLinkGroups 5   
   0  *FirstFloor.ModernUI.Presentation.LinkGroup  2  ,FirstFloor.ModernUI.Presentation.Displayable	   DisplayName$	 地图窗口��6   
   Links
 5      +  %FirstFloor.ModernUI.Presentation.Link  5         Source$ /Views/MapPage.xaml?�6   5        5   
   $	 名人信息��6   
 5        5      $ /Views/PersonPage.xaml?�6   5        5   
   $	 事件信息��6   
 5        5      $ /Views/EventPage.xaml?�6   5        5   
   $	 其它��6   
 5        5      $ /Views/SettingsPage.xaml?�6   5          
TitleLinks 5%   
     $	 帮助��6   $/ )https://github.com/firstfloorsoftware/mui?�6$   5'      