﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaoUpFind.ViewModels
{
    public class VM_Home_Register
    {
        [Required(ErrorMessage = "請選擇會員種類")]
        public Nullable<int> 會員種類 { get; set; }

        [Required(ErrorMessage = "請輸入帳號")]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "會員帳號的長度需在4~12個字元內！")]
        [RegularExpression(@"[a-zA-Z]+[a-zA-Z0-9]*$", ErrorMessage = "帳號僅能有英文或數字，且開頭需為英文字母！")]
        public string 會員帳號 { get; set; }

        [Required(ErrorMessage = "請輸入密碼")]
        [DataType(DataType.Password)]
        [StringLength(18, MinimumLength = 6, ErrorMessage = "會員密碼的長度需在6~18個字元內！")]
        [RegularExpression(@"[a-zA-Z0-9]*$", ErrorMessage = "密碼僅能有英文或數字！")]
        public string 會員密碼 { get; set; }

        [Required(ErrorMessage = "請再次輸入密碼")]
        [Compare("會員密碼", ErrorMessage = "兩次密碼輸入不符")]
        [DataType(DataType.Password)]
        public string 確認密碼 { get; set; }

        [Required(ErrorMessage = "請輸入Email")]
        [EmailAddress(ErrorMessage = "Email格式錯誤")]
        public string 信箱VM { get; set; }

        public static implicit operator string(VM_Home_Register v)
        {
            throw new NotImplementedException();
        }
    }
}