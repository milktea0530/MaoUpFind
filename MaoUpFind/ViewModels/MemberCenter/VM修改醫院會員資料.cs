using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaoUpFind.ViewModels.MemberCenter
{
    public class VM修改醫院會員資料
    {
        public int 會員編號 { get; set; }

        //[ReadOnly(true)]
        [Required(ErrorMessage = "請選擇會員種類")]
        public Nullable<int> 會員種類 { get; set; }

        //[ReadOnly(true)]
        [Required(ErrorMessage = "請輸入帳號")]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "會員帳號的長度需在4~12個字元內！")]
        [RegularExpression(@"[a-zA-Z]+[a-zA-Z0-9]*$", ErrorMessage = "帳號僅能有英文或數字，且開頭需為英文字母！")]
        public string 會員帳號 { get; set; }

        //----------------------------------------------------
        
        [Required(ErrorMessage = "請輸入醫院名稱")]
        public string 醫院名字 { get; set; }

        [RegularExpression(@"[-0-9]*$", ErrorMessage = "格式錯誤！")]
        public string 醫院電話 { get; set; }
        public string 聯絡人 { get; set; }
        public Nullable<int> 所在地點_市 { get; set; }
        public Nullable<int> 所在地點_區 { get; set; }
        public string 所在地點_全 { get; set; }
        public string 備註 { get; set; }
        public string 營業時間 { get; set; }
    }
}