using MaoUpFind.Models;
using MaoUpFind.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaoUpFind.Factories
{
    public class F_GetMemberInfo
    {
        /// <summary>
        /// 取得醫院資料 
        /// </summary>
        /// <param name="data">回傳的資料</param>
        /// <returns></returns>
        public VM_Info getHospital(ref List<醫院會員資料> data)
        {
            // 呼叫方式
            // List<醫院會員資料> data = new List<醫院會員資料>();
            // (new F_GetMemberInfo()).getHospital(ref data);
            // 直接把 data 回傳至畫面
            // return View(data);

            VM_Info rInfo = new VM_Info();
            try
            {
                MaoUpFindEntities db = new MaoUpFindEntities();
                data = db.醫院會員資料.ToList();
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

        public VM_Info getAdoption(ref List<刊登認養> data)
        {
           

            VM_Info rInfo = new VM_Info();
            try
            {
                MaoUpFindEntities db = new MaoUpFindEntities();
                data = db.刊登認養.ToList();
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

        public VM_Info getBulletin(ref List<通報資料> data)
        {


            VM_Info rInfo = new VM_Info();
            try
            {
                MaoUpFindEntities db = new MaoUpFindEntities();
                data = db.通報資料.ToList();
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

        public VM_Info getFinding(ref List<刊登協尋> data)
        {


            VM_Info rInfo = new VM_Info();
            try
            {
                MaoUpFindEntities db = new MaoUpFindEntities();
                data = db.刊登協尋.ToList();
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
    }
}
