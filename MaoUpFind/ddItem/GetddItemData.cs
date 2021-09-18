using MaoUpFind.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MaoUpFind.ddItem
{
    public static class GetddItemData
    {
        public static IEnumerable<SelectListItem> 取得城市()
        {
            MaoUpFindEntities db = new MaoUpFindEntities();
            List<SelectListItem> selectList = new List<SelectListItem>();
            // 預設值
            selectList.Add(new SelectListItem()
            {
                Text = "請選擇城市",
                Value = "",
                Disabled = true,
                Selected = true
            });
            // 取得資料
            var temp = db.城市.Where(m => m.是否啟用.Equals("1"))
                .Select(a => new SelectListItem
                {
                    Text = a.城市名稱,
                    Value = a.城市編號.ToString()
                }
            ).ToList();
            selectList.AddRange(temp);
            // 回傳資料
            return selectList;
        }
        public static IEnumerable<SelectListItem> 取得區(int id)
        {
            MaoUpFindEntities db = new MaoUpFindEntities();
            List<SelectListItem> selectList = new List<SelectListItem>();
            // 預設值
            selectList.Add(new SelectListItem()
            {
                Text = "請選擇區",
                Value = "",
                Disabled = true,
                Selected = true
            });
            // 取得資料
            var temp = db.地區.Where(m => m.是否啟用.Equals("1") && m.城市編號 == id)
                .Select(a => new SelectListItem
                {
                    Text = a.地區名稱,
                    Value = a.地區編號.ToString()
                }
            ).ToList();
            selectList.AddRange(temp);
            // 回傳資料
            return selectList;
        }
        public static IEnumerable<SelectListItem> 取得區(int id, string area)
        {
            MaoUpFindEntities db = new MaoUpFindEntities();
            List<SelectListItem> selectList = new List<SelectListItem>();
            // 預設值
            selectList.Add(new SelectListItem()
            {
                Text = "請選擇區",
                Value = "",
                Disabled = true,
                Selected = true
            });
            // 取得資料
            var temp = db.地區.Where(m => m.是否啟用.Equals("1") && m.城市編號 == id)
                .Select(a => new SelectListItem
                {
                    Text = a.地區名稱,
                    Value = a.地區編號.ToString()
                }
            ).ToList();
            selectList.AddRange(temp);
            if (area == "") return selectList;
            // 有值就給預設值
            foreach (var item in selectList)
            {
                if (item.Value == area) item.Selected = true;
            }
            // 回傳資料
            return selectList;
        }
        public static List<SelectListItem> 取得急迫性()
        {
            MaoUpFindEntities db = new MaoUpFindEntities();
            List<SelectListItem> selectList = new List<SelectListItem>();
            // 預設值
            selectList.Add(new SelectListItem()
            {
                Text = "請選擇急迫性",
                Value = "",
                Disabled = true,
                Selected = true
            });
            // 取得資料
            var temp = db.急迫性.Where(m => m.是否啟用.Equals("1"))
                .Select(a => new SelectListItem
                {
                    Text = a.急迫性名稱,
                    Value = a.急迫性編號.ToString()
                }
            ).ToList();
            selectList.AddRange(temp);
            // 回傳資料
            return selectList;
        }
        public static List<SelectListItem> 取得動物別()
        {
            MaoUpFindEntities db = new MaoUpFindEntities();
            List<SelectListItem> selectList = new List<SelectListItem>();
            // 預設值
            selectList.Add(new SelectListItem()
            {
                Text = "請選擇動物別",
                Value = "",
                Disabled = true,
                Selected = true
            });
            // 取得資料
            var temp = db.動物別.Where(m => m.是否啟用.Equals("1"))
                .Select(a => new SelectListItem
                {
                    Text = a.動物別名稱,
                    Value = a.動物別編號.ToString()
                }
            ).ToList();
            selectList.AddRange(temp);
            // 回傳資料
            return selectList;
        }
        public static List<SelectListItem> 取得動物品種(int 動物別)
        {
            MaoUpFindEntities db = new MaoUpFindEntities();
            List<SelectListItem> selectList = new List<SelectListItem>();
            // 預設值
            selectList.Add(new SelectListItem()
            {
                Text = "請選擇動物品種",
                Value = "",
                Disabled = true,
                Selected = true
            });
            // 取得資料
            var temp = db.動物品種.Where(m => m.是否啟用.Equals("1") && m.動物別編號 == 動物別)
                .Select(a => new SelectListItem
                {
                    Text = a.品種名稱,
                    Value = a.品種編號.ToString()
                }
            ).ToList();
            selectList.AddRange(temp);
            return selectList;
        }
        public static List<SelectListItem> 取得排序(int check = 0, int addItem = 0)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem { Text = "建立日期(由新到舊)", Value = "0" });
            selectList.Add(new SelectListItem { Text = "建立日期(由舊到新)", Value = "1" });
            selectList.Add(new SelectListItem { Text = "最近更新", Value = "2" });
            // 認養
            if (addItem == 1)
            {
                selectList.Add(new SelectListItem { Text = "認養截止日(由新到舊)", Value = "3" });
                selectList.Add(new SelectListItem { Text = "認養截止日(由舊到新)", Value = "4" });
            }
            // 協尋
            if (addItem == 2)
            {
                selectList.Add(new SelectListItem { Text = "走失日期(由新到舊)", Value = "5" });
                selectList.Add(new SelectListItem { Text = "走失日期(由舊到新)", Value = "6" });
            }

            foreach (var item in selectList)
            {
                if (item.Value == check.ToString()) item.Selected = true;
            }
            return selectList;
        }
        public static List<SelectListItem> 是否公開()
        {
            List<SelectListItem> selectLists = new List<SelectListItem>();
            selectLists.Add(new SelectListItem { Text = "公開", Value = "1" });
            selectLists.Add(new SelectListItem { Text = "私", Value = "2" });
            return selectLists;
        }
    }
}