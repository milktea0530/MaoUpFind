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
    
    public partial class 寵物資料
    {
        public int 寵物編號 { get; set; }
        public Nullable<int> 動物別編號 { get; set; }
        public Nullable<int> 品種編號 { get; set; }
        public string 晶片號碼 { get; set; }
        public string 寵物稱呼 { get; set; }
        public string 寵物年紀 { get; set; }
        public string 寵物性別 { get; set; }
        public string 健康狀況 { get; set; }
        public string 附件一 { get; set; }
        public string 附件二 { get; set; }
        public string 附件三 { get; set; }
        public Nullable<System.DateTime> 建立時間 { get; set; }
        public Nullable<System.DateTime> 更新時間 { get; set; }
        public string 寵物資訊備註 { get; set; }
    }
}
