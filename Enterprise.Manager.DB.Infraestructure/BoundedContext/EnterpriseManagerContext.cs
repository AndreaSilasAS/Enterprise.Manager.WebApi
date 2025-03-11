using Enterprise.Manager.DB.Infraestructure.Constants;
using Enterprise.Manager.Library.Entities;
using Microsoft.EntityFrameworkCore;


namespace Enterprise.Manager.DB.Infraestructure.BoundedContext
{
    internal class EnterpriseManagerContext : DbContext
    {
        public EnterpriseManagerContext(DbContextOptions<EnterpriseManagerContext> options) : base (options) { }

        public DbSet<CompanyEntity> Company { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompanyEntity>(entity =>
            {
                entity.ToTable(TableNameConstants.Company, SchemaNameConstants.EnterpriseManager);
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.Exchange).IsRequired();
                entity.Property(c => c.Ticker).IsRequired();
                entity.Property(c => c.Isin).IsRequired();
                entity.Property(c => c.Website);
            });
        }
    }
}
