using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using MaoUpFind.Factories;
using MaoUpFind.Models;
using MaoUpFind.ViewModels;
using System.Web.Security;
using MaoUpFind.ViewModels.MemberCenter;

namespace MaoUpFind.Controllers
{

    public class HomeController : Controller
    {
        MaoUpFindEntities db = new MaoUpFindEntities();

        // 首頁
        public ActionResult Index()
        {
            // 取得資料
            var data = (new F_HomeCarousel()).Query();
            // 預設空的查詢條件
            VM_Home_Carousel queryModel = new VM_Home_Carousel();
            ViewBag.QueryModel = queryModel;
            return View(data);
        }

        // 判斷Session是否存在, 存在的話要調整導覽列(顯示會員資料&登出)
        // 登出清掉Session並且還原導覽列
        // 跟這個畫面沒直接關係, 直接調整_Header畫面


        // 以下2021-7-8 由尾鰭翻修
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(VM_Home_Login p)
        {

            MaoUpFindEntities db = new MaoUpFindEntities();

            var account = db.帳號資料.Where(m => m.會員帳號 == p.會員帳號).FirstOrDefault();
            if (account == null)
            {
                ViewBag.Message = "查無此帳號!";
                return View();

            }
            if (account.帳號開通 == "1" && account.會員密碼 == p.會員密碼)
            {
                Session[CDictionary.SK_LOGINED_ID] = account.會員編號;
                Session[CDictionary.SK_LOGINED_ACCOUNT] = account.會員帳號;
                Session[CDictionary.SK_LOGINED_TYPE] = account.會員種類;

                FormsAuthentication.RedirectFromLoginPage(account.會員帳號, false);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "密碼錯誤!";
                return View();
            }

        }

        public ActionResult Logout()
        {
            Session.Abandon(); //清除全部Session
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(VM_Home_Register p)
        {
            if (ModelState.IsValid == false) //判斷模型是否通過驗證
                return View();

            var memberCheck = db.帳號資料.Where(m => m.會員帳號 == p.會員帳號).FirstOrDefault();
            //若member不為空 代表該帳號已被註冊
            if (memberCheck != null)
            {
                ViewBag.Message = "此帳號已有人使用 註冊失敗";
                return View();
            }

            string checkCode = new Random().Next(100000, 999999).ToString();
            string url = Request.Url.AbsoluteUri + $"Checked?checkedCode={checkCode}&Email={p.信箱VM}";
            if (!Do寄驗證信(p, checkCode, url))
            {
                ViewBag.Message = "寄送驗證信時發生錯誤 註冊失敗";
                return View();
            }

            Session["VM_Home_Register"] = p;
            Session["checkedCode"] = checkCode;
            return RedirectToAction("RegisterChecking");
        }


        //輸入信箱驗證碼頁面
        public ActionResult RegisterChecking()
        {
            if (Session["VM_Home_Register"] == null)
            {
                ViewBag.messag = "無註冊暫存資料 跳轉至登入頁面";
                return View("login");
            }
            VM_Home_Register p = (VM_Home_Register)Session["VM_Home_Register"];
            ViewBag.Account = p.會員帳號;
            ViewBag.Email = p.信箱VM;
            return View();
        }

        //判斷驗證碼是否正確
        public ActionResult RegisterChecked(string account, string checkedCode)
        {
            if (Session["VM_Home_Register"] == null)
            {
                return RedirectToAction("Index");
            }
            VM_Home_Register p = (VM_Home_Register)Session["VM_Home_Register"];
            ViewBag.Message = "";
            string tcc = (string)Session["CheckedCode"];
            if (checkedCode != tcc || string.IsNullOrEmpty(tcc))
            {
                ViewBag.Account = p.會員帳號;
                ViewBag.Email = p.信箱VM;
                ViewBag.Message = "驗證碼錯誤!";
                return View("RegisterChecking");
            }

            var member = db.帳號資料.Where(m => m.會員帳號 == p.會員帳號).FirstOrDefault();
            //若member不為空 代表該帳號已被註冊
            if (member != null)
            {
                ViewBag.Message = "此帳號已開通!";
                return RedirectToAction("Login");
            }
            //VM_Home_Register p = (VM_Home_Register)Session["VM_Home_Register"];
            var p帳號資料 = new 帳號資料();
            p帳號資料.會員種類 = p.會員種類;
            p帳號資料.會員帳號 = p.會員帳號;
            p帳號資料.會員密碼 = p.會員密碼;
            p帳號資料.帳號開通 = "1";
            p帳號資料.收到通知 = "0";
            p帳號資料.違規次數 = 0;
            p帳號資料.建立時間 = DateTime.Now;
            db.帳號資料.Add(p帳號資料);
            db.SaveChanges();


            if (p帳號資料.會員種類 == 0)
            {
                一般會員資料 q一般會員資料 = new 一般會員資料();
                q一般會員資料.會員編號 = p帳號資料.會員編號;
                q一般會員資料.會員暱稱 = "新會員";
                q一般會員資料.會員信箱 = p.信箱VM;
                q一般會員資料.公開聯絡 = "0";
                //大部分詳細資料讓使用者在會員介面修改
                db.一般會員資料.Add(q一般會員資料);
            }
            else if (p帳號資料.會員種類 == 1)
            {
                醫院會員資料 q醫院會員資料 = new 醫院會員資料();
                q醫院會員資料.會員編號 = p帳號資料.會員編號;
                q醫院會員資料.醫院信箱 = p.信箱VM;
                //大部分詳細資料讓使用者在會員介面修改
                db.醫院會員資料.Add(q醫院會員資料);
            }
            db.SaveChanges();
            Session.Abandon();
            ViewBag.Message = $"帳號\"{p.會員帳號}\"註冊完成，\n請重新登入!";
            return View();

        }

        public ActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(string account )
        {
            //if (ModelState.IsValid == false) //判斷模型是否通過驗證
            //    return View();

            var member = db.帳號資料.Where(m => m.會員帳號 == account).FirstOrDefault();
            //若member不為空 代表該帳號已被註冊
            if (member == null)
            {
                ViewBag.ValidationMessage = "查無此帳號";
                return View();
            }
            string email = "";
            if (member.會員種類 == 0)
            {
                var memberDetail = db.一般會員資料.Where(m => m.會員編號 == member.會員編號).FirstOrDefault();
                email = memberDetail.會員信箱;
            }
            else
            {
                var memberDetail = db.醫院會員資料.Where(m => m.會員編號 == member.會員編號).FirstOrDefault();
                email = memberDetail.醫院信箱;
            }
            string checkCode = new Random().Next(100000, 999999).ToString();
            string url = Request.Url.AbsoluteUri + $"Checked?checkedCode={checkCode}&account={member.會員帳號}";

            //寄信
            string yourMessageSubject = $"毛起來找-重設密碼";
            string yourMessageBody;
            yourMessageBody = "This is a test email.\nPlease Disregard.\n\n";
            yourMessageBody += $"Hi, {member.會員帳號}!\n 我們收到您重設密碼的請求.\n";
            yourMessageBody += $"請在發送請求時用的瀏覽器開啟連結: {url}\n\n";
            yourMessageBody += $"以上動作請在20分鐘內完成!";
            List<string> addresList = new List<string>();
            addresList.Add(email);

            if(!(new F_SendEmail()).IsDoingSendEmail(addresList, yourMessageSubject, yourMessageBody))
            {
                TempData["Message"] = "寄信過程發生錯誤!";
                return View();
            }

            Session["ForgetPasswordAccount"] = member.會員帳號;
            Session["ForgetPasswordCheckedCode"] = checkCode;
            TempData["Message"] = "已發送重設密碼信，請至信箱查收!";
            return RedirectToAction("Index");
        }

        public ActionResult ForgetPasswordChecked(string checkedCode,string account)
        {
            if (Session["ForgetPasswordAccount"] == null)
            {
                return RedirectToAction("Index");
            }
            if((string)Session["ForgetPasswordCheckedCode"] != checkedCode)
            {
                return RedirectToAction("Index");
            }


            return View();
        }
        [HttpPost]
        public ActionResult ForgetPasswordChecked(VM修改密碼 vm)
        {
            if (Session["ForgetPasswordAccount"] == null)
            {
                return RedirectToAction("Index");
            }
            string acc = (string)Session["ForgetPasswordAccount"];
            var member = db.帳號資料.Where(m => m.會員帳號 == acc).FirstOrDefault();
            member.會員密碼 = vm.新密碼;
            db.SaveChanges();
            TempData["Message"] = "重設密碼成功! 請重新登入.";

            return RedirectToAction("Login");
        }


        [NonAction] //不被視為動作方法，視為一般類別方法
        public bool Do寄驗證信(VM_Home_Register p, string checkedCode, string url)
        {
            string yourMessageSubject;
            string yourMessageBody;
            yourMessageSubject = $"毛起來找-信箱驗證";
            yourMessageBody = "This is a test email.\nPlease Disregard.\n\n";
            yourMessageBody += $"Hi, {p.會員帳號}!\n你的驗證碼是 {checkedCode}.\n";
            yourMessageBody += $"或直接在註冊時用的瀏覽器開啟連結: {url}\n\n";
            yourMessageBody += $"以上動作請在20分鐘內完成，若超過時限，請重新註冊!";
            List<string> addresList = new List<string>();
            addresList.Add(p.信箱VM);

            return (new F_SendEmail()).IsDoingSendEmail(addresList, yourMessageSubject, yourMessageBody);

        }

    }
}