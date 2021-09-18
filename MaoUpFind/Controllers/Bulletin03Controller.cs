using MaoUpFind.Factories;
using MaoUpFind.Models;
using MaoUpFind.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaoUpFind.Controllers
{
    public class Bulletin03Controller : Controller
    {
        /// <summary>
        /// 查詢所有通報
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // 取得資料
            List<通報資料> data = new List<通報資料>();
            (new F_Bulletin03()).Query(ref data);
            // 預設空的查詢條件
            VM_Bulletin03_Query queryModel = new VM_Bulletin03_Query();
            ViewBag.QueryModel = queryModel;
            return View(data);
        }
        /// <summary>
        /// 查詢所有通報(條件)
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(VM_Bulletin03_Query queryModel)
        {
            // 取得資料
            List<通報資料> data = new List<通報資料>();
            (new F_Bulletin03()).Query(ref data, queryModel);
            // 需要處理查詢條件的暫存
            ViewBag.QueryModel = queryModel;
            return View(data);
        }
        /// <summary>
        /// 查詢詳細資料
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public ActionResult detailView(string number)
        {
            VM_Bulletin03_DetailView data = new VM_Bulletin03_DetailView();
            // 取得資料
            (new F_Bulletin03()).QueryDetail(number, ref data);

            // 取得登入資訊
            會員檢視表 userData = new 會員檢視表();
            if (Session[CDictionary.SK_LOGINED_ID] != null)
            {
                var userId = Session[CDictionary.SK_LOGINED_ID];
                // 取得使用者資訊
                (new F_Bulletin03()).GetUserInfo(userId.ToString(), ref userData);
            }
            ViewBag.UserData = userData;

            return View(data);
        }
        /// <summary>
        /// 取得留言資料
        /// </summary>
        /// <param name="id">通報編號</param>
        /// <param name="number">通報單號</param>
        /// <returns></returns>
        public ActionResult MessageBoard(string id = "", string number = "", string bId = "")
        {
            List<VM_Bulletin03_MessageBoard> data = new List<VM_Bulletin03_MessageBoard>();
            var userId = Session[CDictionary.SK_LOGINED_ID];
            // 取得留言板資訊
            (new F_Bulletin03()).QueryMessage(id, number, ref data, userId);
            // 
            ViewBag.bId = bId;
            return PartialView(data);
        }
        /// <summary>
        /// 新增留言
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MessageBoard(留言板 add_data)
        {
            // 寫入到資料庫
            (new F_Bulletin03()).AddMessageBoard(add_data);
            // 重新取得資料
            List<VM_Bulletin03_MessageBoard> data = new List<VM_Bulletin03_MessageBoard>();
            var userId = Session[CDictionary.SK_LOGINED_ID];
            // 取得留言板資訊
            (new F_Bulletin03()).QueryMessage(add_data.來源編號.ToString(), add_data.來源單號, ref data, userId);
            return PartialView(data);
        }
        public JsonResult SetGood(VM_Bulletin03_SetGood queryData)
        {
            VM_Bulletin03_SetGood rData = new VM_Bulletin03_SetGood();
            if (Session[CDictionary.SK_LOGINED_ID] == null)
            {
                rData.IsSuccess = false;
                return Json(rData, JsonRequestBehavior.AllowGet);
            }
            queryData.memberid = Session[CDictionary.SK_LOGINED_ID].ToString();
            (new F_Bulletin03()).SetGood(queryData, ref rData);
            rData.IsSuccess = true;
            // rData 主要回傳最新按讚數還有按讚編號
            return Json(rData, JsonRequestBehavior.AllowGet);
        }
    }
}