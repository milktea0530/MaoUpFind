//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaoUpFind.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class 帳號資料
    {
        public int 會員編號 { get; set; }
        public Nullable<int> 會員種類 { get; set; }
        public string 會員帳號 { get; set; }
        public string 會員密碼 { get; set; }
        public string 帳號開通 { get; set; }
        public string 收到通知 { get; set; }
        public Nullable<int> 違規次數 { get; set; }
        public Nullable<System.DateTime> 建立時間 { get; set; }
    }
}
