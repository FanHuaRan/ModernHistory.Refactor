using ModernHistory.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Exceptions
{
    /// <summary>
    /// API错误异常
    /// </summary>
    public class ApiErrorException : Exception
    {
        public ApiErrorModel ApiErrorModel { get; set; }

        public ApiErrorException(ApiErrorModel apiErrorModel)
            : base(apiErrorModel.Message)
        {
            this.ApiErrorModel = apiErrorModel;
        }
    }
}
