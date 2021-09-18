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
    public class Adoption02Controller : Controller
    {
        /// <summary>
        /// 查詢所有認養
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // 取得資料
            List<VM_Adoption02_DetailView> data = new List<VM_Adoption02_DetailView>();
            (new F_Adoption02()).Query(ref data);
            // 預設空的查詢條件
            VM_Adoption02_Query queryModel = new VM_Adoption02_Query();
            ViewBag.QueryModel = queryModel;
            return View(data);
        }
        /// <summary>
        /// 查詢所有認養(條件)
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(VM_Adoption02_Query queryModel)
        {
            // 取得資料
            List<VM_Adoption02_DetailView> data = new List<VM_Adoption02_DetailView>();
            (new F_Adoption02()).Query(ref data, queryModel);
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
            VM_Adoption02_DetailView data = new VM_Adoption02_DetailView();
            // 取得資料
            (new F_Adoption02()).QueryDetail(number, ref data);

            // 取得登入資訊
            會員檢視表 userData = new 會員檢視表();
            if (Session[CDictionary.SK_LOGINED_ID] != null)
            {
                var userId = Session[CDictionary.SK_LOGINED_ID];
                // 取得使用者資訊
                (new F_Adoption02()).GetUserInfo(userId.ToString(), ref userData);
            }
            ViewBag.UserData = userData;

            return View(data);
        }
        /// <summary>
        /// 取得留言資料
        /// </summary>
        /// <param name="id">認養編號</param>
        /// <param name="number">認養單號</param>
        /// <returns></returns>
        public ActionResult MessageBoard(string id = "", string number = "", string bId = "")
        {
            List<VM_Adoption02_MessageBoard> data = new List<VM_Adoption02_MessageBoard>();
            var userId = Session[CDictionary.SK_LOGINED_ID];
            // 取得留言板資訊
            (new F_Adoption02()).QueryMessage(id, number, ref data, userId);
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
            (new F_Adoption02()).AddMessageBoard(add_data);
            // 重新取得資料
            List<VM_Adoption02_MessageBoard> data = new List<VM_Adoption02_MessageBoard>();
            var userId = Session[CDictionary.SK_LOGINED_ID];
            // 取得留言板資訊
            (new F_Adoption02()).QueryMessage(add_data.來源編號.ToString(), add_data.來源單號, ref data, userId);
            return PartialView(data);
        }
    }
}