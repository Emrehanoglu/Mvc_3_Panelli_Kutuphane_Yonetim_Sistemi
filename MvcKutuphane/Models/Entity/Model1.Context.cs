﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcKutuphane.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DbKutuphaneEntities : DbContext
    {
        public DbKutuphaneEntities()
            : base("name=DbKutuphaneEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TblCezalar> TblCezalar { get; set; }
        public virtual DbSet<TblHareket> TblHareket { get; set; }
        public virtual DbSet<TblKasa> TblKasa { get; set; }
        public virtual DbSet<TblKategori> TblKategori { get; set; }
        public virtual DbSet<TblKitap> TblKitap { get; set; }
        public virtual DbSet<TblPersonel> TblPersonel { get; set; }
        public virtual DbSet<TblUyeler> TblUyeler { get; set; }
        public virtual DbSet<TblYazar> TblYazar { get; set; }
        public virtual DbSet<TblHakkimizda> TblHakkimizda { get; set; }
        public virtual DbSet<TblIletisim> TblIletisim { get; set; }
        public virtual DbSet<TblMesajlar> TblMesajlar { get; set; }
        public virtual DbSet<TblDuyurular> TblDuyurular { get; set; }
        public virtual DbSet<TblAdmin> TblAdmin { get; set; }
    
        public virtual ObjectResult<string> enCokKitapYazar()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("enCokKitapYazar");
        }
    
        public virtual ObjectResult<string> enAktifUye()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("enAktifUye");
        }
    
        public virtual ObjectResult<string> enCokOkunanKitap()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("enCokOkunanKitap");
        }
    
        public virtual ObjectResult<string> enIyiPersonel()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("enIyiPersonel");
        }
    
        public virtual ObjectResult<string> enIyiYayinEvi()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("enIyiYayinEvi");
        }
    }
}
