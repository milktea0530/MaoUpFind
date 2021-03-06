//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaoUpFind.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MaoUpFindEntities : DbContext
    {
        public MaoUpFindEntities()
            : base("name=MaoUpFindEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<刊登協尋> 刊登協尋 { get; set; }
        public virtual DbSet<刊登認養> 刊登認養 { get; set; }
        public virtual DbSet<地區> 地區 { get; set; }
        public virtual DbSet<城市> 城市 { get; set; }
        public virtual DbSet<急迫性> 急迫性 { get; set; }
        public virtual DbSet<按讚資料> 按讚資料 { get; set; }
        public virtual DbSet<留言板> 留言板 { get; set; }
        public virtual DbSet<動物別> 動物別 { get; set; }
        public virtual DbSet<動物品種> 動物品種 { get; set; }
        public virtual DbSet<帳號資料> 帳號資料 { get; set; }
        public virtual DbSet<通報資料> 通報資料 { get; set; }
        public virtual DbSet<會員違規紀錄> 會員違規紀錄 { get; set; }
        public virtual DbSet<違規行為> 違規行為 { get; set; }
        public virtual DbSet<寵物資料> 寵物資料 { get; set; }
        public virtual DbSet<一般會員資料> 一般會員資料 { get; set; }
        public virtual DbSet<醫院會員資料> 醫院會員資料 { get; set; }
        public virtual DbSet<會員檢視表> 會員檢視表 { get; set; }
        public virtual DbSet<協尋檢視表> 協尋檢視表 { get; set; }
        public virtual DbSet<認養檢視表> 認養檢視表 { get; set; }
    
        public virtual ObjectResult<usp_GetMessageBoardContent_Result> usp_GetMessageBoardContent(Nullable<int> 來源編號, string 來源單號, Nullable<int> 按讚會員編號)
        {
            var 來源編號Parameter = 來源編號.HasValue ?
                new ObjectParameter("來源編號", 來源編號) :
                new ObjectParameter("來源編號", typeof(int));
    
            var 來源單號Parameter = 來源單號 != null ?
                new ObjectParameter("來源單號", 來源單號) :
                new ObjectParameter("來源單號", typeof(string));
    
            var 按讚會員編號Parameter = 按讚會員編號.HasValue ?
                new ObjectParameter("按讚會員編號", 按讚會員編號) :
                new ObjectParameter("按讚會員編號", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetMessageBoardContent_Result>("usp_GetMessageBoardContent", 來源編號Parameter, 來源單號Parameter, 按讚會員編號Parameter);
        }
    }
}
