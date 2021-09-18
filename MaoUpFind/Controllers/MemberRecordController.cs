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
    public class MemberRecordController : Controller
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
            ViewBag.ActionTab = 0;

            return View();
        }

        [ChildActionOnly]
        public ActionResult 通報PV()
        {
            int s_id = (int)Session[CDictionary.SK_LOGINED_ID];
            var temp = db.通報資料.Where(m=>m.會員編號==s_id);
            return PartialView(temp);
        }
        [ChildActionOnly]
        public ActionResult 認養PV()
        {
            int s_id = (int)Session[CDictionary.SK_LOGINED_ID];
            var temp = db.刊登認養.Where(m => m.會員編號 == s_id);
            return PartialView(temp);
        }
        [ChildActionOnly]
        public ActionResult 協尋PV()
        {
            int s_id = (int)Session[CDictionary.SK_LOGINED_ID];
            var temp = db.刊登協尋.Where(m => m.會員編號 == s_id);
            return PartialView(temp);
        }


        public ActionResult 通報PV_Delete(string number)
        {
            var temp = db.通報資料
                .Where(m => m.通報單號 == number).FirstOrDefault();
            db.通報資料.Remove(temp);
            db.SaveChanges();


            List<string> pathList = new List<string>();
            pathList.Add($@"~/FileUpload/{temp.附件一}");
            pathList.Add($@"~/FileUpload/{temp.附件二}");
            pathList.Add($@"~/FileUpload/{temp.附件三}");
            try
            {
                foreach (var item in pathList)
                {
                    string temppath = Server.MapPath(item);

                    if (System.IO.File.Exists(temppath) &&item!= Server.MapPath(@"~/FileUpload/"))
                    {
                        System.IO.File.Delete(temppath);
                    }
                }     
            }
            catch (Exception)
            {
                
            }
            ViewBag.ActionTab = 1;
            return View("Index");

        }

        public ActionResult 認養PV_Delete(string number)
        {
            var temp = db.刊登認養
                .Where(m => m.認養單號 == number).FirstOrDefault();
            db.刊登認養.Remove(temp);
            db.SaveChanges();

            //寵物資訊未刪除

            ViewBag.ActionTab = 2;
            return View("Index");
        }
        public ActionResult 協尋PV_Delete(string number)
        {
            var temp = db.刊登協尋
                .Where(m => m.協尋單號 == number).FirstOrDefault();
            db.刊登協尋.Remove(temp);
            db.SaveChanges();

            //寵物資訊未刪除
            ViewBag.ActionTab = 3;
            return View("Index");

        }


        public ActionResult 認養資訊修改(string number)
        {
            VM_Adoption01_Form model = new VM_Adoption01_Form();
            if (Session[CDictionary.SK_LOGINED_ID] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                刊登認養 temp刊登認養 = db.刊登認養.Where(m => m.認養單號==number).FirstOrDefault();
                寵物資料 temp寵物資料 = db.寵物資料.Where(m=>m.寵物編號==temp刊登認養.寵物編號).FirstOrDefault();
                model.認養單號 = temp刊登認養.認養單號;
                model.認養標題 = temp刊登認養.認養標題;
                model.會員暱稱 = temp刊登認養.會員暱稱;
                model.會員電話 = temp刊登認養.會員電話;
                model.寵物所在地點_市 = temp刊登認養.寵物所在地點_市;
                model.寵物所在地點_區 = temp刊登認養.寵物所在地點_區;
                model.寵物所在地點_全 = temp刊登認養.寵物所在地點_全;
                model.刊登原因 = temp刊登認養.刊登原因;
                model.備註 = temp刊登認養.備註;
                model.結束時間 = temp刊登認養.結束時間;
                //---
                model.動物別編號 = temp寵物資料.動物別編號;
                model.品種編號 = temp寵物資料.品種編號;
                model.寵物稱呼 = temp寵物資料.寵物稱呼;
                model.晶片號碼 = temp寵物資料.晶片號碼;
                model.寵物年紀 = temp寵物資料.寵物年紀;
                model.寵物性別 = temp寵物資料.寵物性別;
                model.健康狀況 = temp寵物資料.健康狀況;
                model.寵物資訊備註 = temp寵物資料.寵物資訊備註;
                return View(model);

            }
        }

        public ActionResult 協尋資訊修改(string number)
        {
            VM_Finding01_Form model = new VM_Finding01_Form();
            if (Session[CDictionary.SK_LOGINED_ID] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                刊登協尋 temp刊登協尋 = db.刊登協尋.Where(m => m.協尋單號 == number).FirstOrDefault();
                寵物資料 temp寵物資料 = db.寵物資料.Where(m => m.寵物編號 == temp刊登協尋.寵物編號).FirstOrDefault();
                model.協尋單號 = temp刊登協尋.協尋單號;
                model.協尋標題 = temp刊登協尋.協尋標題;
                model.會員暱稱 = temp刊登協尋.會員暱稱;
                model.會員電話 = temp刊登協尋.會員電話;
                model.走失地點_市 = temp刊登協尋.走失地點_市;
                model.走失地點_區 = temp刊登協尋.走失地點_區;
                model.走失地點_全 = temp刊登協尋.走失地點_全;
                model.走失時間 = temp刊登協尋.走失時間;
                model.備註 = temp刊登協尋.備註;
                //---
                model.動物別編號 = temp寵物資料.動物別編號;
                model.品種編號 = temp寵物資料.品種編號;
                model.寵物稱呼 = temp寵物資料.寵物稱呼;
                model.晶片號碼 = temp寵物資料.晶片號碼;
                model.寵物年紀 = temp寵物資料.寵物年紀;
                model.寵物性別 = temp寵物資料.寵物性別;
                model.健康狀況 = temp寵物資料.健康狀況;
                model.寵物資訊備註 = temp寵物資料.寵物資訊備註;
                return View(model);

            }
        }

        [HttpPost]
        public ActionResult 認養資訊修改(VM_Adoption01_Form model)
        {
            // 判斷必要欄位
            if (ModelState.IsValid == false) // if (ModelState.IsValid == false)
            {
                return View();
            }
            if (Session[CDictionary.SK_LOGINED_ID] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                刊登認養 temp刊登認養 = db.刊登認養.Where(m => m.認養單號 == model.認養單號).FirstOrDefault();
                寵物資料 temp寵物資料 = db.寵物資料.Where(m => m.寵物編號 == temp刊登認養.寵物編號).FirstOrDefault();
                temp刊登認養.認養單號 = model.認養單號;
                temp刊登認養.認養標題 = model.認養標題;
                temp刊登認養.會員暱稱 = model.會員暱稱;
                temp刊登認養.會員電話 = model.會員電話;
                temp刊登認養.寵物所在地點_市 = model.寵物所在地點_市;
                temp刊登認養.寵物所在地點_區 = model.寵物所在地點_區;
                temp刊登認養.寵物所在地點_全 = model.寵物所在地點_全;
                temp刊登認養.刊登原因 = model.刊登原因;
                temp刊登認養.備註 = model.備註;
                temp刊登認養.結束時間 = model.結束時間;
                temp刊登認養.更新時間 = DateTime.Now;
                //---
                temp寵物資料.動物別編號 = model.動物別編號;
                temp寵物資料.品種編號 = model.品種編號;
                temp寵物資料.寵物稱呼 = model.寵物稱呼;
                temp寵物資料.晶片號碼 = model.晶片號碼;
                temp寵物資料.寵物年紀 = model.寵物年紀;
                temp寵物資料.寵物性別 = model.寵物性別;
                temp寵物資料.健康狀況 = model.健康狀況;
                temp寵物資料.寵物資訊備註 = model.寵物資訊備註;
                db.SaveChanges();
                TempData["Message"] = "修改認養資訊成功!";
                ViewBag.ActionTab = 2;
                return View("Index");

            }
        }

        [HttpPost]
        public ActionResult 協尋資訊修改(VM_Finding01_Form model)
        {
            // 判斷必要欄位
            if (ModelState.IsValid == false) // if (ModelState.IsValid == false)
            {
                return View();
            }
            if (Session[CDictionary.SK_LOGINED_ID] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                刊登協尋 temp刊登協尋 = db.刊登協尋.Where(m => m.協尋單號 == model.協尋單號).FirstOrDefault();
                寵物資料 temp寵物資料 = db.寵物資料.Where(m => m.寵物編號 == temp刊登協尋.寵物編號).FirstOrDefault();
                temp刊登協尋.協尋單號 = model.協尋單號;
                temp刊登協尋.協尋標題 = model.協尋標題;
                temp刊登協尋.會員暱稱 = model.會員暱稱;
                temp刊登協尋.會員電話 = model.會員電話;
                temp刊登協尋.走失地點_市 = model.走失地點_市;
                temp刊登協尋.走失地點_區 = model.走失地點_區;
                temp刊登協尋.走失地點_全 = model.走失地點_全;
                temp刊登協尋.備註 = model.備註;
                temp刊登協尋.走失時間 = model.走失時間;
                temp刊登協尋.更新時間 = DateTime.Now;
                //---
                temp寵物資料.動物別編號 = model.動物別編號;
                temp寵物資料.品種編號 = model.品種編號;
                temp寵物資料.寵物稱呼 = model.寵物稱呼;
                temp寵物資料.晶片號碼 = model.晶片號碼;
                temp寵物資料.寵物年紀 = model.寵物年紀;
                temp寵物資料.寵物性別 = model.寵物性別;
                temp寵物資料.健康狀況 = model.健康狀況;
                temp寵物資料.寵物資訊備註 = model.寵物資訊備註;
                db.SaveChanges();
                TempData["Message"] = "修改協尋資訊成功!";
                ViewBag.ActionTab = 3;
                return View("Index");

            }
        }


        public ActionResult 通報結案修改(string 通報單號) 
        {
            var a = db.通報資料.Where(m => m.通報單號 == 通報單號).FirstOrDefault();
            if(a==null)
            {
                return Json("false");
            }
            a.是否結案 = "1";
            db.SaveChanges();
            return Json("success");
        }
        public ActionResult 認養結案修改(string 認養單號)
        {
            var b = db.刊登認養.Where(m => m.認養單號 == 認養單號).FirstOrDefault();
            if (b == null)
            {
                return Json("false");
            }
            b.是否結案 = "1";
            db.SaveChanges();
            return Json("success");
        }
        public ActionResult 協尋結案修改(string 協尋單號)
        {
            var c = db.刊登協尋.Where(m => m.協尋單號 == 協尋單號).FirstOrDefault();
            if (c == null)
            {
                return Json("false");
            }
            c.是否結案 = "1";
            db.SaveChanges();
            return Json("success");
        }

    }
}