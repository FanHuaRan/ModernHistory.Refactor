using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dto = Fhr.ModernHistory.Models;
using uimodel = ModernHistory.Models;
namespace ModernHistory.DtoConvert
{
    /// <summary>
    /// DTO与MVVM model互相转换
    /// 防止外键问题 Model->DTO放弃依赖属性
    /// 2017/07/13
    /// </summary>
    public class DtoConvertToModel
    {
        public static uimodel.FamousPerson FamousePersonConvert(dto.FamousPerson source)
        {
            if (source == null)
            {
                return null;
            }
            var destination = new uimodel.FamousPerson()
            {
                BornDate = source.BornDate,
                BornPlace = source.BornPlace,
                BornX = source.BornX,
                BornY = source.BornY,
                DeadDate = source.DeadDate,
                FamousPersonId = source.FamousPersonId,
                FamousPersonTypeId = source.FamousPersonTypeId,
                Province=source.Province,
                Gender = source.Gender,
                Nation = source.Nation,
                PersonName = source.PersonName,
                PersonType = FamousPersonTypeConvert(source.PersonType)
            };
            return destination;
        }

        public static uimodel.HistoryEvent HistoryEventConvert(dto.HistoryEvent source)
        {
            if (source == null)
            {
                return null;
            }
            var destionation = new uimodel.HistoryEvent()
            {
                Detail = source.Detail,
                EventType = HistoryEventTypeConvert(source.EventType),
                HistoryEventId = source.HistoryEventId,
                HistoryEventTypeId = source.HistoryEventTypeId,
                OccurDate = source.OccurDate,
                OccurX = source.OccurX,
                OccurY = source.OccurY,
                Place = source.Place,
                Province = source.Province,
                Title = source.Title
            };
            return destionation;
        }

        public static uimodel.FamousPersonType FamousPersonTypeConvert(dto.FamousPersonType source)
        {
            if (source == null)
            {
                return null;
            }
            var destination = new uimodel.FamousPersonType()
            {
                FamousPersonTypeId = source.FamousPersonTypeId,
                FamousPersonTypeName = source.FamousPersonTypeName
            };
            return destination;
        }

        public static uimodel.HistoryEventType HistoryEventTypeConvert(dto.HistoryEventType source)
        {
            if (source == null)
            {
                return null;
            }
            var destination = new uimodel.HistoryEventType()
            {
                HistoryEventTypeId = source.HistoryEventTypeId,
                HistoryEventTypeName = source.HistoryEventTypeName
            };
            return destination;
        }

        public static uimodel.PersonEventRelation PersonEventRelationConvert(dto.PersonEventRelation souce)
        {
            if (souce == null)
            {
                return null;
            }
            var destionnation = new uimodel.PersonEventRelation()
            {
                FamousPersonId = souce.FamousPersonId,
                HistoryEventId = souce.HistoryEventId,
                PersonEventRelationId = souce.PersonEventRelationId
            };
            return destionnation;
        }

        public static uimodel.PersonSearchModel PersonSearchModelConvert(dto.SearchModels.PersonSearchModel source)
        {
            if (source == null)
            {
                return null;
            }
            var destionnation = new uimodel.PersonSearchModel()
            {
                BornPlace = source.BornPlace,
                DeadPlace = source.DeadPlace,
                FamousPersonTypeId = source.FamousPersonTypeId,
                MaxBornDate = source.MaxBornDate,
                MaxDeadDate = source.MaxDeadDate,
                MinBornDate = source.MinBornDate,
                MinDeadDate = source.MinDeadDate,
                Nation = source.Nation,
                PersonName = source.PersonName,
                Province = source.Province
            };
            return destionnation;
        }

        public static uimodel.EventSearchModel EventSearchModelConvert(dto.SearchModels.EventSearchModel source)
        {
            if (source == null)
            {
                return null;
            }
            var destnation = new uimodel.EventSearchModel()
            {
                HistoryEventTypeId = source.HistoryEventTypeId,
                MaxOccurDate = source.MaxOccurDate,
                MinOccurDate = source.MinOccurDate,
                Place = source.Place,
                Province = source.Province,
                Title = source.Title
            };
            return destnation;
        }

        public static uimodel.PersonEventRelationSearchModel PersonEventRelationSearchModelConvert(dto.SearchModels.PersonEventRelationSearchModel source)
        {
            if (source == null)
            {
                return null;
            }
            var destnation = new uimodel.PersonEventRelationSearchModel()
            {
                EventId = source.EventId,
                PersonId = source.PersonId
            };
            return destnation;
        }

        public static dto.FamousPerson FamousePersonConvert(uimodel.FamousPerson source)
        {
            if (source == null)
            {
                return null;
            }
            var destination = new dto.FamousPerson()
            {
                BornDate = source.BornDate,
                BornPlace = source.BornPlace,
                BornX = source.BornX,
                BornY = source.BornY,
                DeadDate = source.DeadDate,
                FamousPersonId = source.FamousPersonId,
                FamousPersonTypeId = source.FamousPersonTypeId,
                Province = source.Province,
                Gender = source.Gender,
                Nation = source.Nation,
                PersonName = source.PersonName,
               // PersonType = FamousPersonTypeConvert(source.PersonType)
            };
            return destination;
        }

        public static dto.HistoryEvent HistoryEventConvert(uimodel.HistoryEvent source)
        {
            if (source == null)
            {
                return null;
            }
            var destionation = new dto.HistoryEvent()
            {
                Detail = source.Detail,
                //EventType = HistoryEventTypeConvert(source.EventType),
                HistoryEventId = source.HistoryEventId,
                HistoryEventTypeId = source.HistoryEventTypeId,
                OccurDate = source.OccurDate,
                OccurX = source.OccurX,
                OccurY = source.OccurY,
                Place = source.Place,
                Province = source.Province,
                Title = source.Title
            };
            return destionation;
        }

        public static dto.FamousPersonType FamousPersonTypeConvert(uimodel.FamousPersonType source)
        {
            if (source == null)
            {
                return null;
            }
            var destination = new dto.FamousPersonType()
            {
                FamousPersonTypeId = source.FamousPersonTypeId,
                FamousPersonTypeName = source.FamousPersonTypeName
            };
            return destination;
        }

        public static dto.HistoryEventType HistoryEventTypeConvert(uimodel.HistoryEventType source)
        {
            if (source == null)
            {
                return null;
            }
            var destination = new dto.HistoryEventType()
            {
                HistoryEventTypeId = source.HistoryEventTypeId,
                HistoryEventTypeName = source.HistoryEventTypeName
            };
            return destination;
        }

        public static dto.PersonEventRelation PersonEventRelationConvert(uimodel.PersonEventRelation souce)
        {
            if (souce == null)
            {
                return null;
            }
            var destionnation = new dto.PersonEventRelation()
            {
                FamousPersonId = souce.FamousPersonId,
                HistoryEventId = souce.HistoryEventId,
                PersonEventRelationId = souce.PersonEventRelationId
            };
            return destionnation;
        }

        public static dto.SearchModels.PersonSearchModel PersonSearchModelConvert(uimodel.PersonSearchModel source)
        {
            if (source == null)
            {
                return null;
            }
            var destionnation = new dto.SearchModels.PersonSearchModel()
            {
                BornPlace = source.BornPlace,
                DeadPlace = source.DeadPlace,
                FamousPersonTypeId = source.FamousPersonTypeId,
                MaxBornDate = source.MaxBornDate,
                MaxDeadDate = source.MaxDeadDate,
                MinBornDate = source.MinBornDate,
                MinDeadDate = source.MinDeadDate,
                Nation = source.Nation,
                PersonName = source.PersonName,
                Province = source.Province
            };
            return destionnation;
        }

        public static dto.SearchModels.EventSearchModel EventSearchModelConvert(uimodel.EventSearchModel source)
        {
            if (source == null)
            {
                return null;
            }
            var destnation = new dto.SearchModels.EventSearchModel()
            {
                HistoryEventTypeId = source.HistoryEventTypeId,
                MaxOccurDate = source.MaxOccurDate,
                MinOccurDate = source.MinOccurDate,
                Place = source.Place,
                Province = source.Province,
                Title = source.Title
            };
            return destnation;
        }

        public static dto.SearchModels.PersonEventRelationSearchModel PersonEventRelationSearchModelConvert(uimodel.PersonEventRelationSearchModel source)
        {
            if (source == null)
            {
                return null;
            }
            var destnation = new dto.SearchModels.PersonEventRelationSearchModel()
            {
                EventId = source.EventId,
                PersonId = source.PersonId
            };
            return destnation;
        }

        public static ObservableCollection<uimodel.FamousPerson> FamousePersonsConvert(ObservableCollection<dto.FamousPerson> sources)
        {
            if (sources == null)
            {
                return null;
            }
            var desCollections = new ObservableCollection<uimodel.FamousPerson>();
            foreach (var source in sources)
            {
                desCollections.Add(FamousePersonConvert(source));
            }
            return desCollections;
        }

        public static ObservableCollection<uimodel.HistoryEvent> HistoryEventsConvert(ObservableCollection<dto.HistoryEvent> sources)
        {
            if (sources == null)
            {
                return null;
            }
            var desCollections = new ObservableCollection<uimodel.HistoryEvent>();
            foreach (var source in sources)
            {
                desCollections.Add(HistoryEventConvert(source));
            }
            return desCollections;
        }

        public static ObservableCollection<uimodel.FamousPersonType> FamousPersonTypesConvert(ObservableCollection<dto.FamousPersonType> sources)
        {
            if (sources == null)
            {
                return null;
            }
            var desCollections = new ObservableCollection<uimodel.FamousPersonType>();
            foreach (var source in sources)
            {
                desCollections.Add(FamousPersonTypeConvert(source));
            }
            return desCollections;
        }

        public static ObservableCollection<uimodel.HistoryEventType> HistoryEventTypesConvert(ObservableCollection<dto.HistoryEventType> sources)
        {
            if (sources == null)
            {
                return null;
            }
            var desCollections = new ObservableCollection<uimodel.HistoryEventType>();
            foreach (var source in sources)
            {
                desCollections.Add(HistoryEventTypeConvert(source));
            }
            return desCollections;
        }

        public static ObservableCollection<uimodel.PersonEventRelation> PersonEventRelationsConvert(ObservableCollection<dto.PersonEventRelation> sources)
        {
            if (sources == null)
            {
                return null;
            }
            var desCollections = new ObservableCollection<uimodel.PersonEventRelation>();
            foreach (var source in sources)
            {
                desCollections.Add(PersonEventRelationConvert(source));
            }
            return desCollections;
        }

    }
}
