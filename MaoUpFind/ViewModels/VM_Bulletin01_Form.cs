using MaoUpFind.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MaoUpFind.ViewModels
{
    public class VM_Bulletin01_Form
    {
        // 建構子, 建立時執行
        public VM_Bulletin01_Form()
        {
            // 建立一個空的通報資料容器,作為寫入資料庫用(EF)
            this.bulletin = new 通報資料();
        }
        public 通報資料 bulletin = new 通報資料();
        // 通報編號由資料庫產生
        // 通報單號由系統產生
        public Nullable<int> 會員編號 { get => this.bulletin.會員編號; set => this.bulletin.會員編號 = value; }

        [Required(ErrorMessage = "必填")]
        public string 會員暱稱 { get => this.bulletin.會員暱稱; set => this.bulletin.會員暱稱 = value; }

        [Required(ErrorMessage = "必填")]
        public string 會員電話 { get => this.bulletin.會員電話; set => this.bulletin.會員電話 = value; }

        [Required(ErrorMessage = "必填")]
        public string 通報標題 { get => this.bulletin.通報標題; set => this.bulletin.通報標題 = value; }

        public string 狀況概述 { get => this.bulletin.狀況概述; set => this.bulletin.狀況概述 = value; }

        public Nullable<DateTime> 通報時間 { get => this.bulletin.通報時間; set => this.bulletin.通報時間 = value; }

        [Required(ErrorMessage = "必填")]
        public Nullable<int> 通報地點_市 { get => this.bulletin.通報地點_市; set => this.bulletin.通報地點_市 = value; }

        [Required(ErrorMessage = "必填")]
        public Nullable<int> 通報地點_區 { get => this.bulletin.通報地點_區; set => this.bulletin.通報地點_區 = value; }

        [Required(ErrorMessage = "必填")]
        public string 發生地點_全 { get => this.bulletin.發生地點_全; set => this.bulletin.發生地點_全 = value; }

        [Required(ErrorMessage = "必填")]
        [DisplayName("急迫性")]
        public Nullable<int> 急迫性編號 { get => this.bulletin.急迫性編號; set => this.bulletin.急迫性編號 = value; }

        // 附件另外處理
        // 是否結案預設0
        public Nullable<DateTime> 建立時間 { get; set; }
        public Nullable<DateTime> 更新時間 { get; set; }
        // 照片(多個用陣列)
        public HttpPostedFileBase[] photo { get; set; }
    }
}