using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Models
{
    /// <summary>
    /// 系统用户 暂时不使用 也就不实现属性通知改变接口了
    /// 2017/06/30 fhr
    /// </summary>
    public class MhUser
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public Int32 MhUserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [Required(ErrorMessage = "Real Name is required")]
        public string RealName { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is is not valid.")]
        public string Email { get; set; }
    }
}
