using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaoUpFind.Controllers
{
    public class FooterController : Controller
    {
        // GET: Footer
        public ActionResult about()
        {
            return View();
        }

        public ActionResult privacypolicy()
        {
            return View();
        }
    }
}