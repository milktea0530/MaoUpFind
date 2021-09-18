using MaoUpFind.Models;
using MaoUpFind.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaoUpFind.Factories
{
    public class F_Bulletin03
    {
        #region Query 查詢所有通報紀錄
        /// <summary>
        /// 查詢所有通報紀錄
        /// </summary>
        /// <param name="data">畫面上的資料</param>
        /// <returns></returns>
        internal VM_Info Query(ref List<通報資料> data)
        {
            MaoUpFindEntities db = new MaoUpFindEntities();
            VM_Info rInfo = new VM_Info();
            try
            {
                data = db.通報資料.Where(m => m.是否結案.ToString() == "0").OrderByDescending(m => m.通報時間).ToList();
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

        #region Query 查詢所有通報紀錄(條件
        /// <summary>
        /// 查詢所有通報紀錄
        /// </summary>
        /// <param name="data">畫面上的資料</param>
        /// <param name="queryModel">查詢條件</param>
        /// <returns></returns>
        internal VM_Info Query(ref List<通報資料> data, VM_Bulletin03_Query queryModel)
        {
            MaoUpFindEntities db = new MaoUpFindEntities();
            VM_Info rInfo = new VM_Info();
            try
            {
                // 先做第一次查詢
                // 排序
                if (queryModel.sortType == 0) data = db.通報資料.Where(m => m.是否結案.ToString() == "0").OrderByDescending(m => m.通報時間).ToList();
                if (queryModel.sortType == 1) data = db.通報資料.Where(m => m.是否結案.ToString() == "0").OrderBy(m => m.通報時間).ToList();
                if (queryModel.sortType == 2) data = db.通報資料.Where(m => m.是否結案.ToString() == "0").OrderByDescending(m => m.更新時間).ToList();

                // 有日期條件再做第二次查詢
                if (!string.IsNullOrEmpty(queryModel.startDate) && !string.IsNullOrEmpty(queryModel.endDate))
                {
                    DateTime d_strat = DateTime.Parse(queryModel.startDate);
                    DateTime d_end = DateTime.Parse(queryModel.endDate).AddDays(1);
                    data = data.Where(m => m.通報時間 >= d_strat && m.通報時間 <= d_end).ToList();
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

        #region QueryDetail 查詢單一筆通報紀錄
        /// <summary>
        /// 查詢單一筆通報紀錄(detailView使用)
        /// </summary>
        /// <param name="number"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public VM_Info QueryDetail(string number, ref VM_Bulletin03_DetailView data)
        {
            VM_Info rInfo = new VM_Info();
            try
            {
                MaoUpFindEntities db = new MaoUpFindEntities();
                data = db.通報資料.Where(m => m.通報單號 == number)
                    .Join(db.急迫性, m => m.急迫性編號, n => n.急迫性編號, (m, n) => new VM_Bulletin03_DetailView
                    {
                        通報編號 = m.通報編號,
                        通報單號 = m.通報單號,
                        會員編號 = m.會員編號,
                        會員電話 = m.會員電話,
                        狀況概述 = m.狀況概述,
                        通報時間 = m.通報時間,
                        通報標題 = m.通報標題,
                        通報地點_市 = m.通報地點_市,
                        通報地點_區 = m.通報地點_區,
                        發生地點_全 = m.發生地點_全,
                        急迫性編號 = m.急迫性編號,
                        急迫性 = n.急迫性名稱,
                        附件一 = m.附件一,
                        附件二 = m.附件二,
                        附件三 = m.附件三,
                        是否結案 = m.是否結案,
                        建立時間 = m.建立時間,
                        更新時間 = m.更新時間,
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

        /// <summary>
        /// 取得留言板內容
        /// </summary>
        /// <param name="id">通報編號</param>
        /// <param name="data">顯示的資料</param>
        /// <param name="memberType">會員種類</param>
        /// <returns></returns>
        public VM_Info QueryMessage(string id, string number, ref List<VM_Bulletin03_MessageBoard> data, object userId)
        {
            VM_Info rInfo = new VM_Info();
            try
            {
                int LoginID = 0;
                if (userId != null) LoginID = Int32.Parse(userId.ToString());
                MaoUpFindEntities db = new MaoUpFindEntities();
                var s_id = Int32.Parse(id);
                data = db.usp_GetMessageBoardContent(s_id, number, LoginID).Select(m => new VM_Bulletin03_MessageBoard
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
                var tempData = db.通報資料.Where(m => m.通報單號 == data.來源單號 && m.通報編號 == data.來源編號).FirstOrDefault();
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

        /// <summary>
        /// 設定是否按讚
        /// </summary>
        /// <param name="queryData"></param>
        public void SetGood(VM_Bulletin03_SetGood queryData, ref VM_Bulletin03_SetGood data)
        {
            MaoUpFindEntities db = new MaoUpFindEntities();
            if (queryData.isTrueSet)
            {
                // 按讚
                按讚資料 addData = new 按讚資料();
                addData.留言編號 = queryData.mbid;
                addData.按讚會員編號 = Int32.Parse(queryData.memberid);
                addData.按讚時間 = DateTime.Now;
                var checkData = db.按讚資料.Where(m => m.留言編號 == addData.留言編號 && m.按讚會員編號 == addData.按讚會員編號).Any();
                // 沒有資料就寫入
                if (!checkData)
                {
                    db.按讚資料.Add(addData);
                    db.SaveChanges();
                }
                data.gid = addData.按讚編號;
            }
            else
            {
                // 移除讚
                按讚資料 temp = db.按讚資料.Where(m => m.按讚編號 == queryData.gid).FirstOrDefault();
                if (temp != null)
                {
                    db.按讚資料.Remove(temp);
                    db.SaveChanges();
                }
                data.gid = 0;
            }
            // 取得最新按讚數
            var getGoodNum = db.按讚資料.Where(m => m.留言編號 == queryData.mbid).Count();
            data.GoodNum = getGoodNum;
            // 更新按讚數
            var mb = db.留言板.Where(m => m.留言編號 == queryData.mbid).FirstOrDefault();
            mb.按讚數 = getGoodNum;
            db.SaveChanges();
        }
    }
}