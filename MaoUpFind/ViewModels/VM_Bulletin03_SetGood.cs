using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaoUpFind.ViewModels
{
    public class VM_Bulletin03_SetGood
    {
        public bool isTrueSet { get; set; } // 是否勾選讚
        public string memberid { get; set; }    // 按讚的會員編號
        public int mbid { get; set; }   // 留言板編號
        public int gid { get; set; }    // 按讚編號
        public int GoodNum { get; set; }    // 按讚數
        public bool IsSuccess { get; set; }
    }
}