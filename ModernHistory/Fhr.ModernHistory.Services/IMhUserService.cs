using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Models;

namespace Fhr.ModernHistory.Services
{
      /// <summary>
      /// 用户服务借口
      /// 2017/07/02 fhr
      /// </summary>
      public interface IMhUserService
      {
             MhUser FindByUserName(string userName);

            string FindPassword(string userName);

            Task<string> FindPasswordAsync(string userName);

      }
}
