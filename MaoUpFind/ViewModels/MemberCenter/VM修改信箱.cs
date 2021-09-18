using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaoUpFind.ViewModels.MemberCenter
{
    public class VM修改信箱
    {
        public int 會員編號 { get; set; }

        [Required(ErrorMessage = "請輸入Email")]
        [EmailAddress(ErrorMessage = "Email格式錯誤")]
        public string 信箱VM { get; set; }
    }
}