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
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// 服务工厂
        /// </summary>
        private IServiceFactory serviceFactory = new SingletonServiceFactory();

        private PersonsInfoViewModel personsInfoViewModel = null;
        /// <summary>
        /// 名人信息ViewModel
        /// </summary>
        public PersonsInfoViewModel PersonsInfoViewModel
        {
            get
            {
                if (personsInfoViewModel == null)
                {
                    personsInfoViewModel = new PersonsInfoViewModel(serviceFactory.GetFamousePersonService());
                }
                return personsInfoViewModel;
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
        public AppearanceViewModel AppearanceViewModel
        {
            get
            {
                return new AppearanceViewModel();
            }
        }
    }
}