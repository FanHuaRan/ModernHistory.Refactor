using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernHistory.Models;
using System.Collections.ObjectModel;

namespace ModernHistory.Services.Impl
{
    /// <summary>
    /// 简单常量数据服务实现
    /// </summary>
    public class SimpleConstModelsService : IConstModelsService
    {

        public ObservableCollection<FamousPersonType> FamousPersonTypes
        {
            get
            {
                return new ObservableCollection<FamousPersonType>()
                {
                        new FamousPersonType(){ FamousPersonTypeId=1,FamousPersonTypeName =" 政治家"},
                        new FamousPersonType(){ FamousPersonTypeId=2,FamousPersonTypeName = "思想家"},
                        new FamousPersonType(){ FamousPersonTypeId=3,FamousPersonTypeName = "军事家"},
                        new FamousPersonType(){ FamousPersonTypeId=4,FamousPersonTypeName = "文学家"},
                        new FamousPersonType(){ FamousPersonTypeId=5,FamousPersonTypeName = "商人"},
                        new FamousPersonType(){ FamousPersonTypeId=6,FamousPersonTypeName = "明星"},
                        new FamousPersonType(){ FamousPersonTypeId=7,FamousPersonTypeName = "其它"}
                };
            }
        }

        public ObservableCollection<HistoryEventType> HistoryEventTypes
        {
            get
            {
                return new ObservableCollection<HistoryEventType>()
                {
                        new HistoryEventType(){HistoryEventTypeId=1,HistoryEventTypeName="政治"},
                        new HistoryEventType(){ HistoryEventTypeId=2,HistoryEventTypeName="军事"},
                        new HistoryEventType(){ HistoryEventTypeId=3,HistoryEventTypeName="经济"},
                        new HistoryEventType(){ HistoryEventTypeId=4,HistoryEventTypeName="文学"},
                };
            }
        }

        public ObservableCollection<string> Provinces
        {
            get {
                return new ObservableCollection<string>()
                {
                    "四川","湖南","贵州","江苏","北京","云南",
                    "广东","上海","福建","广西","湖北","湖南",
                    "江西","西藏","新疆","蒙古","宁夏","黑龙江",
                    "吉林","重庆","河北","河南","山东","天津",
                    "辽宁","山西","甘肃","安徽","浙江","其它"
                };
            }
        }

        public ObservableCollection<string> Nations
        {
            get
            {
                return new ObservableCollection<string>()
                {
                    "汉族","蒙古族","回族","藏族","维吾尔族","苗族","彝族","壮族","布依族",
                    "朝鲜族","满族","侗族","瑶族","白族","土家族","哈尼族","哈萨克族","傣族",
                    "黎族","僳僳族","佤族","畲族","高山族","拉祜族","水族","东乡族","纳西族",
                    "其它"
                };
            }
        }
    }
}
