using MaoUpFind.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaoUpFind.ViewModels
{
    public class VM_Adoption01_Form
    {
        public VM_Adoption01_Form()
        {
            // 建立一個空的認養資料容器,作為寫入資料庫用(EF)
            this.adoption = new 刊登認養();
            this.animal = new 寵物資料();
        }

        public 寵物資料 animal = new 寵物資料();
        public 刊登認養 adoption = new 刊登認養();
        // 通報編號由資料庫產生
        // 通報單號由系統產生



        [Required(ErrorMessage = "必填")]
        public string 認養標題 { get => this.adoption.認養標題; set => this.adoption.認養標題 = value; }

        public Nullable<int> 會員編號 { get => this.adoption.會員編號; set => this.adoption.會員編號 = value; }

        [Required(ErrorMessage = "必填")]
        public string 會員暱稱 { get => this.adoption.會員暱稱; set => this.adoption.會員暱稱 = value; }

        [Required(ErrorMessage = "必填")]
        public string 會員電話 { get => this.adoption.會員電話; set => this.adoption.會員電話 = value; }

        [Required(ErrorMessage = "必填")]
        public Nullable<int> 寵物所在地點_市 { get => this.adoption.寵物所在地點_市; set => this.adoption.寵物所在地點_市 = value; }

        [Required(ErrorMessage = "必填")]
        public Nullable<int> 寵物所在地點_區 { get => this.adoption.寵物所在地點_區; set => this.adoption.寵物所在地點_區 = value; }

        [Required(ErrorMessage = "必填")]
        public string 寵物所在地點_全 { get => this.adoption.寵物所在地點_全; set => this.adoption.寵物所在地點_全 = value; }

        [Required(ErrorMessage = "必填")]
        public string 刊登原因 { get => this.adoption.刊登原因; set => this.adoption.刊登原因 = value; }

        public string 備註 { get => this.adoption.備註; set => this.adoption.備註 = value; }

        [Required(ErrorMessage = "必填")]
        [DisplayName("領養截止日")]
        public Nullable<DateTime> 結束時間 { get => this.adoption.結束時間; set => this.adoption.結束時間 = value; }


        // 寵物資料
        [Required(ErrorMessage = "必填")]
        [DisplayName("動物類別")]
        public Nullable<int> 動物別編號 { get => this.animal.動物別編號; set => this.animal.動物別編號 = value; }

        //[Required(ErrorMessage = "必填")]
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
        public string 健康狀況 { get => this.animal.健康狀況; set => this.animal.健康狀況 = value; }

        public string 寵物資訊備註 { get => this.animal.寵物資訊備註; set => this.animal.寵物資訊備註 = value; }

        // 附件另外處理
        // 是否結案預設0

        public string 認養單號 { get; set; }
        public string 認養狀態 { get; set; }
        public string 是否結案 { get; set; }
        public Nullable<DateTime> 建立時間 { get; set; }
        public Nullable<DateTime> 更新時間 { get; set; }
        // 照片(多個用陣列)
        public HttpPostedFileBase[] photo { get; set; }



    }
}