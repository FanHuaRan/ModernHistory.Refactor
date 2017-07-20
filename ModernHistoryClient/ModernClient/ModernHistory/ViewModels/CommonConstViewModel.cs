using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

// Toolkit namespace
using SimpleMvvmToolkit;
using ModernHistory.Models;
using ModernHistory.Services;
using ModernHistory.Exceptions;
using System.Threading.Tasks;

namespace ModernHistory.ViewModels
{
    /// <summary>
    /// 公用常量数据Viewmodel 单例
    /// 2017/01/14 fhr
    /// </summary>
    public class CommonConstViewModel : ViewModelBase<CommonConstViewModel>
    {
        #region 单例
        private static CommonConstViewModel instance;

        public static CommonConstViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommonConstViewModel(SingletonServiceFactory.Instance.GetConstModelsService());
                }
                return instance;
            }
        }
        private CommonConstViewModel(IConstModelsService constModelsService)
        {
            this.constModelsService = constModelsService;
            //Task.Run(() =>
            //{
            try
            {
                    this.FamousPersonTypes = constModelsService.FamousPersonTypes;
                    this.HistoryEventTypes = constModelsService.HistoryEventTypes;
                    this.Provinces = constModelsService.Provinces;
                    this.Nations = constModelsService.Nations;
                }
                catch (ApiErrorException e)
                {
                    MessageBox.Show(e.Message);
                }
          //  });
        }
        #endregion

        private IConstModelsService constModelsService;

        private ObservableCollection<FamousPersonType> famousPersonTypes;

        public ObservableCollection<FamousPersonType> FamousPersonTypes
        {
            get { return famousPersonTypes; }
            set
            {
                if (famousPersonTypes != value)
                {
                    famousPersonTypes = value;
                    NotifyPropertyChanged(p => p.FamousPersonTypes);
                }
            }
        }

        private ObservableCollection<HistoryEventType> historyEventTypes;

        public ObservableCollection<HistoryEventType> HistoryEventTypes
        {
            get { return historyEventTypes; }
            set
            {
                if (historyEventTypes != value)
                {
                    historyEventTypes = value;
                    NotifyPropertyChanged(p => p.HistoryEventTypes);
                }
            }
        }

        private ObservableCollection<string> provinces;

        public ObservableCollection<string> Provinces
        {
            get { return provinces; }
            set
            {
                if (provinces != value)
                {
                    provinces = value;
                    NotifyPropertyChanged(p => p.Provinces);
                }
            }
        }

        private ObservableCollection<string> nations;

        public ObservableCollection<string> Nations
        {
            get { return nations; }
            set
            {
                if (nations != value)
                {
                    nations = value;
                    NotifyPropertyChanged(p => p.Nations);
                }
            }
        }
    }
}