using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaoUpFind.ViewModels
{
    public class VM_Home_Carousel
    {
        public IEnumerable<VM_Adoption02_DetailView> 認養 { get; set; }
        public IEnumerable<MaoUpFind.Models.通報資料> 通報 { get; set; }
        public IEnumerable<VM_Finding02_DetailView> 協尋 { get; set; }
    }
}