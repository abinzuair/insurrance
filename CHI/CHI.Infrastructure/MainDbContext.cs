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
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseInMemoryDatabase("InsuranceDb");
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var insurancePolicy = modelBuilder.Entity<InsurancePolicy>();
        insurancePolicy.HasKey(x => x.Id);
        insurancePolicy.HasOne(x => x.Beneficiary).WithMany().IsRequired();
        insurancePolicy.HasOne(x => x.Provider).WithMany().IsRequired();
        // for (int i = 1; i <= 10; i++)
        // {
        //     insurancePolicy.HasData(new InsurancePolicy()
        //     {
        //         Id = i,
        //         BeneficiaryId = i,
        //         ProviderId = (i % 3),
        //         BeneficiaryNumber = new Random().Next(10000000, 70000000),
        //         PolicyNumber = new Random().Next(900000000, 999999999),
        //         StartDate = DateTime.Now.AddMonths(-new Random().Next(1, 10)),
        //         EndDate = DateTime.Now.AddMonths(new Random().Next(1, 10))
        //     });
        // }

        var beneficiaries = modelBuilder.Entity<InsuranceBeneficiary>();
        beneficiaries.HasKey(x => x.Id);
        // for (int i = 1; i <= 10; i++)
        // {
        //     beneficiaries.HasData(
        //         new InsuranceBeneficiary()
        //         {
        //             Id = i,
        //             Nin = 100000000 + i,
        //             Gender = Gender.Male,
        //             FirstName = "Beneficiary FirstName" + i,
        //             FatherName = "FatherName" + i,
        //             LastName = "LastName" + i,
        //         }
        //     );
        // }

        var providers = modelBuilder.Entity<InsuranceProvider>();
        providers.HasKey(x => x.Id);
        providers.HasData(new[]
        {
            new InsuranceProvider()
            {
                Id = 1,
                Name = "Provider 1",
                Address = "Saudi Arabia, Riyadh",
                CrNumber = new Random().Next(700000000, 799999999).ToString(),
            },
            new InsuranceProvider()
            {
                Id = 2,
                Name = "Provider 2",
                Address = "Saudi Arabia, Khobar",
                CrNumber = new Random().Next(700000000, 799999999).ToString(),
            },
            new InsuranceProvider()
            {
                Id = 3,
                Name = "Provider 3",
                Address = "Saudi Arabia, Jeddah",
                CrNumber = new Random().Next(700000000, 799999999).ToString(),
            },
            new InsuranceProvider()
            {
                Id = 4,
                Name = "Provider 4",
                Address = "Saudi Arabia, Dammam",
                CrNumber = new Random().Next(700000000, 799999999).ToString(),
            },
        });
    }
}