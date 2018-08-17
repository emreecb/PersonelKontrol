using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Otokar.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Otokar.Models.Data
{
    public class OtokarContext : DbContext
    {
        public OtokarContext() : base("OtokarContext")
        {
             Database.SetInitializer(new MigrateDatabaseToLatestVersion<OtokarContext, Configuration>("OtokarContext"));
    
        }

        public DbSet<Personel> Personel { get; set; }
        public DbSet<Meslek> Meslek { get; set; }
        public DbSet<Departman> Departman { get; set; }
        public DbSet<Gorev> Gorev { get; set; }
        public DbSet<PersonelIzinleri> PersonelIzinleri { get; set; }
        public DbSet<StoktakiEnvanterSayisi> StoktakiEnvanterSayisi { get; set; }
        public DbSet<PersoneleKayitliEnvanter> PersoneleKayitliEnvanter { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
 
        }
    }
}
