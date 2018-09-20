using Microsoft.EntityFrameworkCore;
using SampleDomainSimple;
using System;

namespace ORMSQLProvider
{
    public class PromotionsDBRepository : DbContext
    {
        internal static string ConnectionString = @"Server=.\;Database=test.db.anycompany;Trusted_Connection=True;MultipleActiveResultSets=true";
        public virtual DbSet<Promotion> Promotions { get; set; }

        public PromotionsDBRepository() : base() { }

        public PromotionsDBRepository(DbContextOptions<PromotionsDBRepository> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);

            }
        }

    }
}
