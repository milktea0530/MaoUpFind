using MaoUpFind.Models;
using MaoUpFind.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MaoUpFind.Factories
{
    public class F_Finding02
    {
        #region Query 查詢所有協尋紀錄
        /// <summary>
        /// 查詢所有協尋紀錄
        /// </summary>
        /// <param name="data">畫面上的資料</param>
        /// <returns></returns>
        internal VM_Info Query(ref List<VM_Finding02_DetailView> data)
        {
            MaoUpFindEntities db = new MaoUpFindEntities();
            VM_Info rInfo = new VM_Info();
            try
            {
                data = db.協尋檢視表.Where(m => m.是否結案.Equals("0")).Select(m => new VM_Finding02_DetailView
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
                }).OrderByDescending(m => m.建立時間).ToList();
                rInfo.isSuccess = true;
                rInfo.Msg = "查詢成功";
            }
            catch (Exception)
            {
                rInfo.isSuccess = false;
                rInfo.Msg = "查詢失敗!";
            }
            return rInfo;
        }
        #endregion

        #region Query 查詢所有協尋紀錄(條件
        /// <summary>
        /// 查詢所有協尋紀錄
        /// </summary>
        /// <param name="data">畫面上的資料</param>
        /// <param name="queryModel">查詢條件</param>
        /// <returns></returns>
        internal VM_Info Query(ref List<VM_Finding02_DetailView> data, VM_Finding02_Query queryModel)
        {
            MaoUpFindEntities db = new MaoUpFindEntities();
            VM_Info rInfo = new VM_Info();
            try
            {
                // 先做第一次查詢
                data = db.協尋檢視表.Where(m => m.是否結案.Equals("0")).Select(m => new VM_Finding02_DetailView
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
                }).ToList();
                // 篩選日期與排序
                if (!string.IsNullOrEmpty(queryModel.startDate) && !string.IsNullOrEmpty(queryModel.endDate))
                {
                    DateTime d_strat = DateTime.Parse(queryModel.startDate);
                    DateTime d_end = DateTime.Parse(queryModel.endDate);
                    if (queryModel.sortType == 0) data = data.Where(m => m.建立時間 >= d_strat && m.建立時間 <= d_end).OrderByDescending(m => m.建立時間).ToList();
                    if (queryModel.sortType == 1) data = data.Where(m => m.建立時間 >= d_strat && m.建立時間 <= d_end).OrderBy(m => m.建立時間).ToList();
                    if (queryModel.sortType == 2) data = data.Where(m => m.更新時間 >= d_strat && m.更新時間 <= d_end).OrderBy(m => m.更新時間).ToList();
                    if (queryModel.sortType == 5) data = data.Where(m => m.走失時間 >= d_strat && m.走失時間 <= d_end).OrderByDescending(m => m.走失時間).ToList();
                    if (queryModel.sortType == 6) data = data.Where(m => m.走失時間 >= d_strat && m.走失時間 <= d_end).OrderBy(m => m.走失時間).ToList();
                }
                else
                {
                    if (queryModel.sortType == 0) data = data.OrderByDescending(m => m.建立時間).ToList();
                    if (queryModel.sortType == 1) data = data.OrderBy(m => m.建立時間).ToList();
                    if (queryModel.sortType == 2) data = data.OrderBy(m => m.更新時間).ToList();
                    if (queryModel.sortType == 5) data = data.OrderByDescending(m => m.走失時間).ToList();
                    if (queryModel.sortType == 6) data = data.OrderBy(m => m.走失時間).ToList();
                }

                rInfo.isSuccess = true;
                rInfo.Msg = "查詢成功";
            }
            catch (Exception)
            {
                rInfo.isSuccess = false;
                rInfo.Msg = "查詢失敗!";
            }
            return rInfo;
        }
        #endregion

        #region QueryDetail 查詢單一筆協尋紀錄
        /// <summary>
        /// 查詢單一筆協尋紀錄(detailView使用)
        /// </summary>
        /// <param name="number"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public VM_Info QueryDetail(string number, ref VM_Finding02_DetailView data)
        {
            VM_Info rInfo = new VM_Info();
            MaoUpFindEntities db = new MaoUpFindEntities();
            try
            {
                data = db.協尋檢視表.Where(m => m.協尋單號 == number).Select(m => new VM_Finding02_DetailView
                {
                    協尋單號 = m.協尋單號,
                    協尋編號 = m.協尋編號,
                    會員編號 = m.會員編號,
                    會員暱稱 = m.會員暱稱,
                    會員電話 = m.會員電話,
                    走失時間 = m.走失時間,
                    協尋標題 = m.協尋標題,
                    走失地點_全 = m.走失地點_全,
                    走失地點_區 = m.走失地點_區,
                    走失地點_市 = m.走失地點_市,
                    備註 = m.備註,
                    寵物編號 = (int)m.寵物編號,
                    動物別編號 = m.動物別編號,
                    動物別名稱 = m.動物別名稱,
                    品種編號 = m.品種編號,
                    品種名稱 = m.品種名稱,
                    晶片號碼 = m.晶片號碼,
                    寵物稱呼 = m.寵物稱呼,
                    寵物年紀 = m.寵物年紀,
                    寵物性別 = m.寵物性別,
                    健康狀況 = m.健康狀況,
                    寵物資訊備註 = m.寵物資訊備註,
                    附件一 = m.附件一,
                    附件二 = m.附件二,
                    附件三 = m.附件三,
                    是否結案 = m.是否結案,
                    協尋狀態 = m.協尋狀態
                }).FirstOrDefault();
                rInfo.isSuccess = true;
                rInfo.Msg = "查詢成功";
            }
            catch (Exception)
            {
                rInfo.isSuccess = false;
                rInfo.Msg = "查詢失敗!";
            }
            return rInfo;
        }
        #endregion

        #region GetUserInfo 查詢使用者登入資訊
        /// <summary>
        /// 查詢使用者登入資訊
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public VM_Info GetUserInfo(string userId, ref 會員檢視表 data)
        {
            VM_Info rInfo = new VM_Info();
            try
            {
                MaoUpFindEntities db = new MaoUpFindEntities();
                data = db.會員檢視表.Where(m => m.會員編號.ToString() == userId).FirstOrDefault();
                rInfo.isSuccess = true;
                rInfo.Msg = "查詢成功";
            }
            catch (Exception)
            {
                rInfo.isSuccess = false;
                rInfo.Msg = "查詢失敗";
            }
            return rInfo;
        }
        #endregion

        #region QueryMessage 取得留言板內容
        /// <summary>
        /// 取得留言板內容
        /// </summary>
        /// <param name="id">協尋編號</param>
        /// <param name="data">顯示的資料</param>
        /// <param name="memberType">會員種類</param>
        /// <returns></returns>
        public VM_Info QueryMessage(string id, string number, ref List<VM_Finding02_MessageBoard> data, object userId)
        {
            VM_Info rInfo = new VM_Info();
            try
            {
                int LoginID = 0;
                if (userId != null) LoginID = Int32.Parse(userId.ToString());
                MaoUpFindEntities db = new MaoUpFindEntities();
                var s_id = Int32.Parse(id);
                data = db.usp_GetMessageBoardContent(s_id, number, LoginID).Select(m => new VM_Finding02_MessageBoard
                {
                    來源編號 = m.來源編號,
                    按讚數 = m.按讚數,
                    按讚編號 = m.按讚編號,
                    是否公開 = m.是否公開,
                    是否按讚 = m.是否按讚,
                    是否被檢舉 = m.是否被檢舉,
                    會員暱稱 = m.會員暱稱,
                    會員編號 = m.會員編號,
                    留言內容 = m.留言內容,
                    留言日期 = m.留言日期,
                    留言編號 = m.留言編號
                }).OrderBy(m => m.留言日期).ToList();
                rInfo.isSuccess = true;
                rInfo.Msg = "查詢成功";
            }
            catch (Exception)
            {
                rInfo.isSuccess = false;
                rInfo.Msg = "查詢失敗";
            }
            return rInfo;
        }
        #endregion

        #region AddMessageBoard 新增留言紀錄
        /// <summary>
        /// 新增留言紀錄
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public VM_Info AddMessageBoard(留言板 data)
        {
            data.留言日期 = DateTime.Now;
            data.按讚數 = 0;
            data.是否公開 = string.IsNullOrEmpty(data.是否公開) ? "1" : data.是否公開;
            data.是否被檢舉 = 0;
            VM_Info rInfo = new VM_Info();
            try
            {
                // 新增資料
                MaoUpFindEntities db = new MaoUpFindEntities();
                db.留言板.Add(data);
                db.SaveChanges();
                // 更新時間
                var tempData = db.刊登協尋.Where(m => m.協尋單號 == data.來源單號 && m.協尋編號 == data.來源編號).FirstOrDefault();
                tempData.更新時間 = DateTime.Now;
                db.SaveChanges();
                rInfo.isSuccess = true;
                rInfo.Msg = "新增成功";
            }
            catch (Exception)
            {
                rInfo.isSuccess = false;
                rInfo.Msg = "新增失敗!";
            }
            return rInfo;
        }
        #endregion
    }
}