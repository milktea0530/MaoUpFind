using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaoUpFind.ViewModels.MemberCenter
{
    public class VM修改密碼
    {
        [ReadOnly(true)]    //不確定該用法對不對(應該沒錯)
        public int 會員編號 { get; set; }

        //懶得寫判斷，有時間再做QQ
        //[DisplayName("舊密碼")]
        //[Required(ErrorMessage = "請輸入原本的密碼")]
        //[DataType(DataType.Password)]   //使用此Type時 似乎無法從Controller傳該欄位到View
        //[StringLength(18, MinimumLength = 6, ErrorMessage = "密碼的長度需在6~18個字元內！")]
        //[RegularExpression(@"[a-zA-Z0-9]*$", ErrorMessage = "密碼僅能有英文或數字！")]
        //public string 舊密碼 { get; set; }

        [DisplayName("新密碼")]
        [Required(ErrorMessage = "請輸入新密碼")]
        [DataType(DataType.Password)]
        [StringLength(18, MinimumLength = 6, ErrorMessage = "密碼的長度需在6~18個字元內！")]
        [RegularExpression(@"[a-zA-Z0-9]*$", ErrorMessage = "密碼僅能有英文或數字！")]
        public string 新密碼 { get; set; }

        [DisplayName("確認新密碼")]
        [Compare("新密碼", ErrorMessage = "兩次密碼輸入不符")]
        [DataType(DataType.Password)]
        public string 確認新密碼 { get; set; }
    }
}