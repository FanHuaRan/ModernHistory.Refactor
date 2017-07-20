using System;
namespace ModernHistory.Services
{
    /// <summary>
    /// 服务工厂接口
    /// 抽象工厂模式
    /// 2017/07/12 fhr
    /// </summary>
    public interface IServiceFactory
    {
        IFamousePersonService GetFamousePersonService();
        IFamousPersonTypeService GetFamousPersonTypeService();
        IHistoryEventService GetHistoryEventService();
        IHistoryEventTypeService GetHistoryEventTypeService();
        IImageService GetImageService();
        IPersonEventRelationService GetPersonEventRelationService();
        IConstModelsService GetConstModelsService();
    }
}
