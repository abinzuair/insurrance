using CHI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CHI.Infrastructure;

public class MainDbContext : DbContext
{
    public DbSet<InsurancePolicy> Policies { get; set; }
    public DbSet<InsuranceProvider> Providers { get; set; }
    public DbSet<InsuranceBeneficiary> Beneficiaries { get; set; }

    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var insurancePolicy = modelBuilder.Entity<InsurancePolicy>();
        insurancePolicy.HasKey(x => x.Id);
        insurancePolicy.HasOne(x => x.Beneficiary).WithMany().IsRequired();
        insurancePolicy.HasOne(x => x.Provider).WithMany().IsRequired();

        var beneficiaries = modelBuilder.Entity<InsuranceBeneficiary>();
        beneficiaries.HasKey(x => x.Id);

        var providers = modelBuilder.Entity<InsuranceProvider>();
        providers.HasKey(x => x.Id);
    }
}