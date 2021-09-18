using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaoUpFind.ViewModels
{
    public class VM_Finding02_DetailView
    {
        // 刊登協尋
        public int 協尋編號 { get; set; }
        public string 協尋單號 { get; set; }
        //public Nullable<int> 寵物編號 { get; set; }
        public string 協尋狀態 { get; set; }
        public Nullable<int> 會員編號 { get; set; }
        public string 會員暱稱 { get; set; }
        public string 會員電話 { get; set; }
        public Nullable<int> 走失地點_市 { get; set; }
        public Nullable<int> 走失地點_區 { get; set; }
        public string 走失地點_全 { get; set; }
        public string 備註 { get; set; }
        public string 是否結案 { get; set; }
        public Nullable<System.DateTime> 建立時間 { get; set; }
        public Nullable<System.DateTime> 更新時間 { get; set; }
        public string 協尋標題 { get; set; }
        public Nullable<System.DateTime> 走失時間 { get; set; }

        // 寵物資料
        public int 寵物編號 { get; set; }
        public Nullable<int> 動物別編號 { get; set; }
        public Nullable<int> 品種編號 { get; set; }
        public string 晶片號碼 { get; set; }
        public string 寵物稱呼 { get; set; }
        public string 寵物年紀 { get; set; }
        public string 寵物性別 { get; set; }
        public string 健康狀況 { get; set; }
        public string 寵物資訊備註 { get; set; }
        public string 附件一 { get; set; }
        public string 附件二 { get; set; }
        public string 附件三 { get; set; }

        public string 品種名稱 { get; set; }
        public string 動物別名稱 { get; set; }
        // public Nullable<System.DateTime> 建立時間 { get; set; }
        // public Nullable<System.DateTime> 更新時間 { get; set; }
    }
}