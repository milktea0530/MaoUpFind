using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MaoUpFind.ViewModels
{
    public class VM_Bulletin03_MessageBoard
    {
        public int 留言編號 { get; set; }
        public Nullable<int> 來源編號 { get; set; }
        public Nullable<int> 會員編號 { get; set; }
        public string 會員暱稱 { get; set; }
        public string 留言內容 { get; set; }
        public Nullable<DateTime> 留言日期 { get; set; }
        public Nullable<int> 按讚數 { get; set; }
        [DisplayName("按讚")]
        public int 是否按讚 { get; set; }
        public int 按讚編號 { get; set; }
        public string 是否公開 { get; set; }
        public Nullable<int> 是否被檢舉 { get; set; }
    }
}