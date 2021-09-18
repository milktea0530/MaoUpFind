using MaoUpFind.Models;
using MaoUpFind.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MaoUpFind.Factories
{
    public class F_HomeCarousel
    {
        #region Query 查詢所有認養紀錄
        /// <summary>
        /// 查詢所有認養紀錄
        /// </summary>
        /// <param name="data">畫面上的資料</param>
        /// <returns></returns>
        internal VM_Home_Carousel Query()
        {
            MaoUpFindEntities db = new MaoUpFindEntities();

            var 認養 = db.認養檢視表.Where(m => m.是否結案.Equals("0")).Select(m => new VM_Adoption02_DetailView
            {
                認養編號 = m.認養編號,
                認養單號 = m.認養單號,
                認養標題 = m.認養標題,
                認養狀態 = m.認養狀態,
                會員暱稱 = m.會員暱稱,
                會員編號 = m.會員編號,
                會員電話 = m.會員電話,
                寵物所在地點_全 = m.寵物所在地點_全,
                寵物所在地點_區 = m.寵物所在地點_區,
                寵物所在地點_市 = m.寵物所在地點_市,
                備註 = m.備註,
                結束時間 = m.結束時間,
                是否結案 = m.是否結案,
                建立時間 = m.建立時間,
                更新時間 = m.更新時間,
                寵物編號 = (int)m.寵物編號,
                健康狀況 = m.健康狀況,
                動物別名稱 = m.動物別名稱,
                動物別編號 = m.動物別編號,
                品種名稱 = m.品種名稱,
                品種編號 = m.品種編號,
                寵物年紀 = m.寵物年紀,
                寵物性別 = m.寵物性別,
                寵物稱呼 = m.寵物稱呼,
                寵物資訊備註 = m.寵物資訊備註,
                晶片號碼 = m.晶片號碼,
                附件一 = m.附件一,
                附件三 = m.附件三,
                附件二 = m.附件二,
                刊登原因 = m.刊登原因
            }).OrderByDescending(m => m.結束時間).Take(2).ToList();

            var 通報 = db.通報資料.Where(m => m.是否結案.ToString() == "0").OrderByDescending(m => m.通報時間).Take(2).ToList();

            var 協尋 = db.協尋檢視表.Where(m => m.是否結案.Equals("0")).Select(m => new VM_Finding02_DetailView
            {
                協尋編號 = m.協尋編號,
                協尋單號 = m.協尋單號,
                協尋標題 = m.協尋標題,
                協尋狀態 = m.協尋狀態,
                會員暱稱 = m.會員暱稱,
                會員編號 = m.會員編號,
                會員電話 = m.會員電話,
                走失地點_全 = m.走失地點_全,
                走失地點_區 = m.走失地點_區,
                走失地點_市 = m.走失地點_市,
                備註 = m.備註,
                走失時間 = m.走失時間,
                是否結案 = m.是否結案,
                建立時間 = m.建立時間,
                更新時間 = m.更新時間,
                寵物編號 = (int)m.寵物編號,
                健康狀況 = m.健康狀況,
                動物別名稱 = m.動物別名稱,
                動物別編號 = m.動物別編號,
                品種名稱 = m.品種名稱,
                品種編號 = m.品種編號,
                寵物年紀 = m.寵物年紀,
                寵物性別 = m.寵物性別,
                寵物稱呼 = m.寵物稱呼,
                寵物資訊備註 = m.寵物資訊備註,
                晶片號碼 = m.晶片號碼,
                附件一 = m.附件一,
                附件三 = m.附件三,
                附件二 = m.附件二
            }).OrderByDescending(m => m.走失時間).Take(2).ToList();


            var model = new VM_Home_Carousel
            {
                認養 = 認養,
                通報 = 通報,
                協尋 = 協尋
            };
            return model;
        }

        #endregion
    }
}