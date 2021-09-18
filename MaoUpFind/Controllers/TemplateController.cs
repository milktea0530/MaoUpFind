using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaoUpFind.Controllers
{
    public class TemplateController : Controller
    {
        // GET: Template
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _AreaDropDownList(string city, string title, string area = "")
        {
            int i_city = 0;
            if (!string.IsNullOrEmpty(city)) i_city = Int32.Parse(city);
            ViewBag.City = i_city;
            ViewBag.Title = title; 
            ViewBag.Area = area;
            return PartialView();
        }
        public ActionResult _AnimalVarietyDropDownList(string animal, string title)
        {
            int i_animal = 0;
            if (!string.IsNullOrEmpty(animal)) i_animal = Int32.Parse(animal);
            ViewBag.Animal = i_animal;
            ViewBag.Title = title;
            return PartialView();
        }

        public ActionResult _FileUpload()
        {
            return PartialView();
        }
        public ActionResult Send(HttpPostedFileBase[] photo, string city, string area)
        {

            return View();
        }
    }
}