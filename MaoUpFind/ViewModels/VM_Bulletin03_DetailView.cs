using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaoUpFind.ViewModels
{
    public class VM_Bulletin03_DetailView
    {
        public int 通報編號 { get; set; }
        public string 通報單號 { get; set; }
        public Nullable<int> 會員編號 { get; set; }
        public string 會員暱稱 { get; set; }
        public string 會員電話 { get; set; }
        public string 通報標題 { get; set; }
        public string 狀況概述 { get; set; }
        public Nullable<System.DateTime> 通報時間 { get; set; }
        public Nullable<int> 通報地點_市 { get; set; }
        public string 市 { get; set; }
        public Nullable<int> 通報地點_區 { get; set; }
        public string 區 { get; set; }
        public string 發生地點_全 { get; set; }
        public Nullable<int> 急迫性編號 { get; set; }
        public string 急迫性 { get; set; }
        public string 附件一 { get; set; }
        public string 附件二 { get; set; }
        public string 附件三 { get; set; }
        public string 是否結案 { get; set; }
        public Nullable<System.DateTime> 建立時間 { get; set; }
        public Nullable<System.DateTime> 更新時間 { get; set; }
    }
}