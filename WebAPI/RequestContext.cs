using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI
{
    public class RequestContext : DbContext
    {
        public RequestContext(DbContextOptions<RequestContext> options) : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }

        #region Overrides of DbContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultContainer("ThirdPartyRequests");

            modelBuilder.Entity<Request>()
                .ToContainer("ThirdPartyRequests")
                .HasNoDiscriminator()
                .HasPartitionKey(r => r.PartitionKey);
        }

        #endregion
    }
}