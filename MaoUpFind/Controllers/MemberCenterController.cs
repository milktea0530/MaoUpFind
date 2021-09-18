using MaoUpFind.Models;
using MaoUpFind.ViewModels.MemberCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaoUpFind.Controllers
{
    public class MemberCenterController : Controller
    {
        MaoUpFindEntities db = new MaoUpFindEntities();

        [Authorize]
        public ActionResult Index()
        {
            if (Session[CDictionary.SK_LOGINED_ID] == null)
            {
                TempData["Message"] = "請先登入";
                return RedirectToAction("Login", "Home");
            }
            
            return View();
        }

        [ChildActionOnly]
        public ActionResult Form1_g()
        {
            int id = (int)Session[CDictionary.SK_LOGINED_ID];
            var tempAcc = db.帳號資料
                .Where(m => m.會員編號 == id)
                .FirstOrDefault();
            var tempDetail = db.一般會員資料
                .Where(m => m.會員編號 == id)
                .FirstOrDefault();
            VM修改一般會員資料 vm = new VM修改一般會員資料();
            vm.會員編號 = tempAcc.會員編號;
            vm.會員種類 = tempAcc.會員種類;
            vm.會員帳號 = tempAcc.會員帳號;
            vm.會員名字 = tempDetail.會員名字;
            vm.會員暱稱 = tempDetail.會員暱稱;
            vm.會員電話 = tempDetail.會員電話;
            vm.公開聯絡 = tempDetail.公開聯絡;
            vm.聯絡時段 = tempDetail.聯絡時段;

            vm.聯絡地區_市 = tempDetail.聯絡地區_市;
            vm.聯絡地區_區 = tempDetail.聯絡地區_區;

            ViewBag.Message = "Form1_g";
            return PartialView(vm);
        }
        [HttpPost]
        public ActionResult Form1_g(VM修改一般會員資料 vm)
        {
            if (!ModelState.IsValid)
            {
                TempData["message"] = "未通過驗證!";
            }
            else if (Session[CDictionary.SK_LOGINED_ID] == null)
            {
                TempData["message"] = "未登入!";
            }
            else
            {
                int id = (int)Session[CDictionary.SK_LOGINED_ID];
                var tempAcc = db.帳號資料
                    .Where(m => m.會員編號 == id)
                    .FirstOrDefault();
                var tempDetail = db.一般會員資料
                    .Where(m => m.會員編號 == id)
                    .FirstOrDefault();


                tempDetail.會員名字 = vm.會員名字;
                tempDetail.會員暱稱 = vm.會員暱稱;
                tempDetail.會員電話 = vm.會員電話;
                tempDetail.公開聯絡 = vm.公開聯絡;
                tempDetail.聯絡時段 = vm.聯絡時段;

                tempDetail.聯絡地區_市 = vm.聯絡地區_市;
                tempDetail.聯絡地區_區 = vm.聯絡地區_區;


                db.SaveChanges();
                TempData["message"] = "資料更新完成!!";
            }
            return RedirectToAction("Index");

        }


        [ChildActionOnly]
        public ActionResult Form1_h()
        {
            int id = (int)Session[CDictionary.SK_LOGINED_ID];
            var tempAcc = db.帳號資料
                .Where(m => m.會員編號 == id)
                .FirstOrDefault();
            var tempDetail = db.醫院會員資料
                .Where(m => m.會員編號 == id)
                .FirstOrDefault();
            VM修改醫院會員資料 vm = new VM修改醫院會員資料();
            vm.會員編號 = tempAcc.會員編號;
            vm.會員種類 = tempAcc.會員種類;
            vm.會員帳號 = tempAcc.會員帳號;
            vm.醫院名字 = tempDetail.醫院名字;
            vm.所在地點_全 = tempDetail.所在地點_全;
            vm.醫院電話 = tempDetail.醫院電話;
            vm.聯絡人 = tempDetail.聯絡人;
            vm.備註 = tempDetail.備註;
            vm.營業時間 = tempDetail.營業時間;

            vm.所在地點_市 = tempDetail.所在地點_市;
            vm.所在地點_區 = tempDetail.所在地點_區;

            ViewBag.Message = "Form1_h";
            return PartialView(vm);
        }
        [HttpPost]
        public ActionResult Form1_h(VM修改醫院會員資料 vm)
        {
            if (!ModelState.IsValid)
            {
                TempData["message"] = "未通過驗證!";
            }
            else if (Session[CDictionary.SK_LOGINED_ID] == null)
            {
                TempData["message"] = "未登入!";
            }
            else
            {
                int id = (int)Session[CDictionary.SK_LOGINED_ID];
                var tempAcc = db.帳號資料
                    .Where(m => m.會員編號 == id)
                    .FirstOrDefault();
                var tempDetail = db.醫院會員資料
                    .Where(m => m.會員編號 == id)
                    .FirstOrDefault();

                tempDetail.醫院名字 = vm.醫院名字;
                tempDetail.聯絡人 = vm.聯絡人;
                tempDetail.醫院電話 = vm.醫院電話;
                tempDetail.所在地點_全 = vm.所在地點_全;
                tempDetail.營業時間 = vm.營業時間;
                tempDetail.備註 = vm.備註;

                tempDetail.所在地點_市 = vm.所在地點_市;
                tempDetail.所在地點_區 = vm.所在地點_區;

                db.SaveChanges();
                TempData["message"] = "資料更新完成!!";
            }
            return RedirectToAction("Index");

        }










        /**************/
        [ChildActionOnly]
        public ActionResult Form2()
        {
            ViewBag.Message = "Form2";
            return PartialView();
        }

        [HttpPost]
        public ActionResult Form2(VM修改密碼 vm)
        {
            if(!ModelState.IsValid)
            {
                TempData["message"] = "未通過驗證!";
            }
            else if(Session[CDictionary.SK_LOGINED_ID]==null)
            {
                TempData["message"] = "未登入!";
            }
            else
            {
                int id = (int)Session[CDictionary.SK_LOGINED_ID];
                var temp = db.帳號資料
                    .Where(m => m.會員編號 == id)
                    .FirstOrDefault();
                temp.會員密碼 = vm.新密碼;
                db.SaveChanges();
                TempData["message"] = "修改密碼完成!!";
            }
            return RedirectToAction("Index");

        }

        [ChildActionOnly]
        public ActionResult Form3()
        {
            int id = (int)Session[CDictionary.SK_LOGINED_ID];
            int memberType = (int)Session[CDictionary.SK_LOGINED_TYPE];
            VM修改信箱 vm = new VM修改信箱();
            if (memberType == 0)
            {
                var tempDetail = db.一般會員資料
                .Where(m => m.會員編號 == id)
                .FirstOrDefault();
                vm.信箱VM = tempDetail.會員信箱;
            }
            else
            {
                var tempDetail = db.醫院會員資料
                .Where(m => m.會員編號 == id)
                .FirstOrDefault();
                vm.信箱VM = tempDetail.醫院信箱;
            }

            return PartialView(vm);

        }
        [HttpPost]
        public ActionResult Form3(VM修改信箱 vm)
        {
            if (!ModelState.IsValid)
            {
                TempData["message"] = "未通過驗證!";
            }
            else if (Session[CDictionary.SK_LOGINED_ID] == null)
            {
                TempData["message"] = "未登入!";
            }
            else
            {
                int id = (int)Session[CDictionary.SK_LOGINED_ID];
                int memberType = (int)Session[CDictionary.SK_LOGINED_TYPE];
                if (memberType == 0)
                {
                    var tempDetail = db.一般會員資料
                    .Where(m => m.會員編號 == id)
                    .FirstOrDefault();
                    tempDetail.會員信箱 = vm.信箱VM;
                    db.SaveChanges();
                }
                else
                {
                    var tempDetail = db.醫院會員資料
                    .Where(m => m.會員編號 == id)
                    .FirstOrDefault();
                    tempDetail.醫院信箱 = vm.信箱VM;
                    db.SaveChanges();
                }

                TempData["message"] = "修改信箱完成!!";
            }
            return RedirectToAction("Index");

        }


    }
}