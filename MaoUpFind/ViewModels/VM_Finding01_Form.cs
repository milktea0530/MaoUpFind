using MaoUpFind.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaoUpFind.ViewModels
{
    public class VM_Finding01_Form
    {
        public VM_Finding01_Form()
        {
            // 建立一個空的認養資料容器,作為寫入資料庫用(EF)
            this.finding = new 刊登協尋();
            this.animal = new 寵物資料();
        }

        public 寵物資料 animal = new 寵物資料();
        public 刊登協尋 finding = new 刊登協尋();
        // 通報編號由資料庫產生
        // 通報單號由系統產生



        [Required(ErrorMessage = "必填")]
        public string 協尋標題 { get => this.finding.協尋標題; set => this.finding.協尋標題 = value; }

        public Nullable<int> 會員編號 { get => this.finding.會員編號; set => this.finding.會員編號 = value; }

        [Required(ErrorMessage = "必填")]
        public string 會員暱稱 { get => this.finding.會員暱稱; set => this.finding.會員暱稱 = value; }

        [Required(ErrorMessage = "必填")]
        public string 會員電話 { get => this.finding.會員電話; set => this.finding.會員電話 = value; }

        [Required(ErrorMessage = "必填")]
        public Nullable<int> 走失地點_市 { get => this.finding.走失地點_市; set => this.finding.走失地點_市 = value; }

        [Required(ErrorMessage = "必填")]
        public Nullable<int> 走失地點_區 { get => this.finding.走失地點_區; set => this.finding.走失地點_區 = value; }

        [Required(ErrorMessage = "必填")]
        public string 走失地點_全 { get => this.finding.走失地點_全; set => this.finding.走失地點_全 = value; }


        [Required(ErrorMessage = "必填")]
        public Nullable<DateTime> 走失時間 { get => this.finding.走失時間; set => this.finding.走失時間 = value; }

        public string 備註 { get => this.finding.備註; set => this.finding.備註 = value; }


        // 寵物資料
        [Required(ErrorMessage = "必填")]
        [DisplayName("動物類別")]
        public Nullable<int> 動物別編號 { get => this.animal.動物別編號; set => this.animal.動物別編號 = value; }

        [Required(ErrorMessage = "必填")]
        [DisplayName("品種")]
        public Nullable<int> 品種編號 { get => this.animal.品種編號; set => this.animal.品種編號 = value; }

        [Required(ErrorMessage = "必填")]
        public string 寵物稱呼 { get => this.animal.寵物稱呼; set => this.animal.寵物稱呼 = value; }

        public string 晶片號碼 { get => this.animal.晶片號碼; set => this.animal.晶片號碼 = value; }

        [Required(ErrorMessage = "必填")]
        public string 寵物性別 { get => this.animal.寵物性別; set => this.animal.寵物性別 = value; }

        [Required(ErrorMessage = "必填")]
        public string 寵物年紀 { get => this.animal.寵物年紀; set => this.animal.寵物年紀 = value; }

        [Required(ErrorMessage = "必填")]
        [DisplayName("寵物特徵")]
        public string 健康狀況 { get => this.animal.健康狀況; set => this.animal.健康狀況 = value; }

        public string 寵物資訊備註 { get => this.animal.寵物資訊備註; set => this.animal.寵物資訊備註 = value; }



        // 附件另外處理
        // 是否結案預設0
        public string 協尋單號 { get; set; }
        public string 協尋狀態 { get; set; }
        public string 是否結案 { get; set; }
        public Nullable<DateTime> 建立時間 { get; set; }
        public Nullable<DateTime> 更新時間 { get; set; }
        // 照片(多個用陣列)
        public HttpPostedFileBase[] photo { get; set; }

    }
}