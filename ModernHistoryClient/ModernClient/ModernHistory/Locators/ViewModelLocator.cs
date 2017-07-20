/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:ModernHistory"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// Toolkit namespace
using SimpleMvvmToolkit;
using ModernHistory.ViewModels;
using ModernHistory.Services;

namespace ModernHistory
{
    /// <summary>
    /// ViewModel定位器 相当于ViewModel工厂
    /// 因为都是单例 从ViewModel的使用看 部分会存在线程问题
    /// </summary>
    public class ViewModelLocator
    {
        private static object locker = 1;

        /// <summary>
        /// 服务工厂
        /// </summary>
        private static IServiceFactory serviceFactory = SingletonServiceFactory.Instance;

        private static MapPageViewModel mapPageViewModel = null;

        private static PersonsInfoViewModel personsInfoViewModel = null;

        private static PersonEditViewModel personEditViewModel = null;

        private static EventsInfoViewModel eventsInfoViewModel=null;

        private static EventEditViewModel eventEditViewModel = null;

        private PersonAddViewModel personAddViewModel;

        private  EventAddViewModel eventAddViewModel = null;
        /*
        public MapPageViewModel MapPageViewModel
        {
            get
            {
                lock (locker)
                {
                    if (mapPageViewModel == null)
                    {
                        mapPageViewModel = new MapPageViewModel(serviceFactory.GetFamousePersonService(), serviceFactory.GetHistoryEventService(), serviceFactory.GetImageService());
                    }
                    return mapPageViewModel;
                }
            }
        }
         */

        public static MapPageViewModel MapPageViewModelInstance
        {
            get
            {
                lock (locker)
                {
                    if (mapPageViewModel == null)
                    {
                        mapPageViewModel = new MapPageViewModel(serviceFactory.GetFamousePersonService(), serviceFactory.GetHistoryEventService(), serviceFactory.GetImageService());
                    }
                    return mapPageViewModel;
                }
            }
        }

        public PersonEditViewModel PersonEditViewModel
        {
            get
            {
                if (personEditViewModel == null)
                {
                    personEditViewModel = new PersonEditViewModel(serviceFactory.GetFamousePersonService(), serviceFactory.GetImageService());
                }
                return personEditViewModel;
            }
        }

        /// <summary>
        /// 名人信息ViewModel
        /// </summary>
        public PersonsInfoViewModel PersonsInfoViewModel
        {
            get
            {
                if (personsInfoViewModel == null)
                {
                    personsInfoViewModel = new PersonsInfoViewModel(
                        serviceFactory.GetFamousePersonService(),
                        serviceFactory.GetImageService());
                }
                return personsInfoViewModel;
            }
        }

        public static PersonsInfoViewModel PersonsInfoViewModelInstance
        {
            get
            {
                {
                    if (personsInfoViewModel == null)
                    {
                        personsInfoViewModel = new PersonsInfoViewModel(
                            serviceFactory.GetFamousePersonService(),
                            serviceFactory.GetImageService());
                    }
                    return personsInfoViewModel;
                }
            }
        }


        public PersonAddViewModel PersonAddViewModel
        {
            get
            {
                if (personAddViewModel == null)
                {
                    personAddViewModel = new PersonAddViewModel(serviceFactory.GetFamousePersonService(), serviceFactory.GetImageService());
                }
                return personAddViewModel;

            }
        }


        public static EventsInfoViewModel EventsInfoViewModel
        {
            get
            {
                if (eventsInfoViewModel == null)
                {
                    eventsInfoViewModel = new EventsInfoViewModel(serviceFactory.GetHistoryEventService(), serviceFactory.GetImageService());
                }
                return eventsInfoViewModel;
            }
        }

        public static EventEditViewModel EventEditViewModel
        {
            get
            {
                if (eventEditViewModel == null)
                {
                    eventEditViewModel = new EventEditViewModel(serviceFactory.GetHistoryEventService(), serviceFactory.GetImageService());
                }
                return eventEditViewModel;
            }
        }

        public EventAddViewModel EventAddViewModel
        {
             get
            {
                if (eventAddViewModel == null)
                {
                    eventAddViewModel = new EventAddViewModel(serviceFactory.GetHistoryEventService(), serviceFactory.GetImageService());
                }
                return eventAddViewModel;
            }
        }


        // Create MainPageViewModel on demand
        public MainPageViewModel MainPageViewModel
        {
            get { return new MainPageViewModel(); }
        }



        // Create CustomerViewModel on demand
        public CustomerViewModel CustomerViewModel
        {
            get
            {
                ICustomerServiceAgent serviceAgent = new MockCustomerServiceAgent();
                return new CustomerViewModel(serviceAgent);
            }
        }

        public CommonConstViewModel CommonConstViewModel
        {
            get
            {
                return CommonConstViewModel.Instance;
            }
        }

        public AppearanceViewModel AppearanceViewModel
        {
            get
            {
                return new AppearanceViewModel();
            }
        }
    }
}