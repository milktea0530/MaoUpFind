using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MaoUpFind.Models;
using MaoUpFind.Factories;
using MaoUpFind.ViewModels;
namespace MaoUpFind.Controllers
{
    public class MapController : Controller
    {
        
        // GET: hospitalMap
        public ActionResult hospitalMap()
        {
            List<醫院會員資料> data = new List<醫院會員資料>();
            (new F_GetMemberInfo()).getHospital(ref data);
            //直接把 data 回傳至畫面
            return View(data);
        }


        public ActionResult BulletinMap()
        {
            List<通報資料> data = new List<通報資料>();
            (new F_GetMemberInfo()).getBulletin(ref data);
            //直接把 data 回傳至畫面
            return View(data);
        }


        public ActionResult AdoptionMap()
        {
            // 取得資料
            List<VM_Adoption02_DetailView> data = new List<VM_Adoption02_DetailView>();
            (new F_Adoption02()).Query(ref data);
            // 預設空的查詢條件
            VM_Adoption02_Query queryModel = new VM_Adoption02_Query();
            ViewBag.QueryModel = queryModel;
            return View(data);
        }

        public ActionResult FindingMap()
        {
            List<VM_Finding02_DetailView> data = new List<VM_Finding02_DetailView>();
            (new F_Finding02()).Query(ref data);
            // 預設空的查詢條件
            VM_Finding02_Query queryModel = new VM_Finding02_Query();
            ViewBag.QueryModel = queryModel;
            return View(data);
        }
    }
}