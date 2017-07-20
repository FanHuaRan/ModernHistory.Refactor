using Fhr.ModernHistory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Services
{
    /// <summary>
    /// 名人类型服务接口
    /// 2017/07/11 fhr
    /// </summary>
    public interface IFamousPersonTypeService
    {
        Task<ObservableCollection<FamousPersonType>> FindAllAsync();
        Task<FamousPersonType> FindByIdAsync(int id);
    }
}
