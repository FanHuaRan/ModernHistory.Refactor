using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Dtos;
using Fhr.ModernHistory.Models;
using Fhr.ModernHistory.Repositorys;

namespace Fhr.ModernHistory.Services.Impl
{
      /// <summary>
      /// 用户服务实现
      /// 2017/07/02 fhr
      /// </summary>
      public class MhUserServiceClass : IMhUserService
      {
            private IMhUserRepository mhUserRepository = null;

            public MhUserServiceClass(IMhUserRepository mhUserRepository)
            {
                  this.mhUserRepository = mhUserRepository;
            }

            public MhUser FindByUserName(string userName)
            {
                  return mhUserRepository.FindByLinq(p => p.UserName == userName)
                                                           .FirstOrDefault();
            }

            public string FindPassword(string userName)
            {
                  var result = mhUserRepository.FindByWhereAndSelect(p => p.UserName == userName, p => p.Password);
                  if (result.Count() == 0)
                  {
                        return null;
                  }
                  return result.First().ToString();
            }

            public Task<string> FindPasswordAsync(string userName)
            {
                  return Task<string>.Run(() =>
                  {
                        return FindPassword(userName);
                  });
            }

            MhUser IMhUserService.FindByUserName(string userName)
            {
                  throw new NotImplementedException();
            }
      }
}
