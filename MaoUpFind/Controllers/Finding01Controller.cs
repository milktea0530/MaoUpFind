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
    public class Finding01Controller : Controller
    {
        // 刊登協尋
        public ActionResult Index()
        {
            VM_Finding01_Form model = new VM_Finding01_Form();
            if (Session[CDictionary.SK_LOGINED_ID] != null)
            {
                var s_id = Session[CDictionary.SK_LOGINED_ID].ToString();
                var s_type = Session[CDictionary.SK_LOGINED_TYPE].ToString();
                (new F_Finding01()).GetMemberInfo(ref model, s_id, s_type);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(VM_Finding01_Form data)
        {
            // 判斷必要欄位
            if (ModelState.IsValid == false)
            {
                return View(data);
            }
            // 判斷是否有上傳圖片
            if (data.photo[0] == null)
            {
                ViewBag.FileUploadErrorMsg = "請至少上傳一張圖片!";
                return View();
            }
            // 用來暫時存放圖片的路徑
            string[] tempPhotoSave = new string[3];
            // 附件處理
            for (int i = 0; i < data.photo.Length; i++)
            {
                String savePath = Server.MapPath(CDictionary.FILEUPLOAD_PATH);  // 存放的地方
                string phtoName = Guid.NewGuid().ToString() + ".jpg";   // 檔名名稱
                String saveResult = savePath + phtoName;                // 組合成完整路徑+檔案名稱
                data.photo[i].SaveAs(saveResult);                       // 存放該路徑下
                tempPhotoSave[i] = phtoName;                      // 存放路徑
            }
            // 對應的圖片順序放到對應的欄位
            data.animal.附件一 = tempPhotoSave[0];
            data.animal.附件二 = tempPhotoSave[1] == null ? "" : tempPhotoSave[1];
            data.animal.附件三 = tempPhotoSave[2] == null ? "" : tempPhotoSave[2];
            // 交給工廠寫入資料庫

            var rInfo = (new F_Finding01()).Create(ref data);


            // 失敗 -> 回到Index
            if (!rInfo.isSuccess)
            {
                TempData["message"] = rInfo.Msg;
                return View();
            }
            // 成功 -> 切到成功畫面(為設計) 有按鈕可直接連到查詢專欄
            // 回傳單號+編號            
            Session["finding"] = data.finding;
            return RedirectToAction("addSuccess");
        }
        public ActionResult addSuccess()
        {
            var finding = (刊登協尋)Session["finding"];
            return View(finding);
        }
    }
}