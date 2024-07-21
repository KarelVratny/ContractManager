using Microsoft.EntityFrameworkCore;

namespace ContractManager.Models {
	public class ApplicationDbContext : DbContext {
		public DbSet<Contract> Contracts { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Advisor> Advisors { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Contract>()
			   .HasOne(contract => (Client)contract.Client)
			   .WithMany(client => client.Contracts)
			   .HasForeignKey("ClientId");

			modelBuilder.Entity<Contract>()
				.HasOne(contract => contract.Manager)
				.WithMany(advisor => advisor.ManagedContracts)
				.HasForeignKey("ManagerId");

			modelBuilder.Entity<Contract>()
				.HasMany(contract => contract.Advisors)
				.WithMany(advisor => advisor.ParticipatedContracts)
				.UsingEntity(join => join.ToTable("ContractAdvisors"));
		}
	}
}
