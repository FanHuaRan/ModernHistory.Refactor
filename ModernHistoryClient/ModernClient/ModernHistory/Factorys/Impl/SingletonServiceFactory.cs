using ModernHistory.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Services
{
    /// <summary>
    /// 单例服务工厂实现
    /// 抽象工厂模式+单例模式变种
    /// 2017/07/12 fhr
    /// </summary>
    public class SingletonServiceFactory : IServiceFactory
    {
        #region 单例
        private static SingletonServiceFactory instance = null;

        public static SingletonServiceFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonServiceFactory();
                }
                return instance;
            }
        }
        private SingletonServiceFactory() { }
        #endregion
        private IFamousePersonService famousePersonService = null;

        private IFamousPersonTypeService famousPersonTypeService = null;

        private IHistoryEventService historyEventService = null;

        private IHistoryEventTypeService historyEventTypeService = null;

        private IImageService imageService = null;

        private IPersonEventRelationService personEventRelationService = null;

        private IConstModelsService constModelsService = null;

        public IFamousePersonService GetFamousePersonService()
        {
            if (famousePersonService == null)
            {
                famousePersonService = new FamousePersonServiceClass();
            }
            return famousePersonService;
        }
        public IFamousPersonTypeService GetFamousPersonTypeService()
        {
            if (famousPersonTypeService == null)
            {
                famousPersonTypeService = new FamousPersonTypeServiceClass();
            }
            return famousPersonTypeService;
        }
        public IHistoryEventService GetHistoryEventService()
        {
            if (historyEventService == null)
            {
                historyEventService = new HistoryEventServiceClass();
            }
            return historyEventService;
        }
        public IHistoryEventTypeService GetHistoryEventTypeService()
        {
            if (historyEventTypeService == null)
            {
                historyEventTypeService = new HistoryEventTypeServiceClass();
            }
            return historyEventTypeService;
        }
        public IImageService GetImageService()
        {
            if (imageService == null)
            {
                imageService = new LocalImageServiceClass();
            }
            return imageService;
        }
        public IPersonEventRelationService GetPersonEventRelationService()
        {
            if (personEventRelationService == null)
            {
                personEventRelationService = new PersonEventRelationServiceClass();
            }
            return personEventRelationService;
        }


        public IConstModelsService GetConstModelsService()
        {
            if (constModelsService == null)
            {
                constModelsService = new SimpleConstModelsService();
            }
            return constModelsService;
        }
    }
}
