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
    
    public partial class 留言板
    {
        public int 留言編號 { get; set; }
        public Nullable<int> 來源編號 { get; set; }
        public Nullable<int> 會員編號 { get; set; }
        public string 留言內容 { get; set; }
        public Nullable<System.DateTime> 留言日期 { get; set; }
        public Nullable<int> 按讚數 { get; set; }
        public string 是否公開 { get; set; }
        public Nullable<int> 是否被檢舉 { get; set; }
        public string 來源單號 { get; set; }
    }
}
