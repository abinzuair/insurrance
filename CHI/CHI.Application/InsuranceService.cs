using CHI.Domain.Entities;
using CHI.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CHI.Application;

public sealed class InsuranceService
{
    private readonly MainDbContext _dbContext;

    public InsuranceService(MainDbContext dbContext)
    {
        _dbContext = dbContext;
        SetInitialValues();
    }

    private void SetInitialValues()
    {
        for (int i = 1; i <= 10; i++)
        {
            if (_dbContext.Policies.AsNoTracking().Any(x => x.Id == i))
                continue;

            _dbContext.Add(new InsurancePolicy()
            {
                Id = i,
                BeneficiaryId = i,
                ProviderId = (i % 3),
                BeneficiaryNumber = new Random().Next(10000000, 70000000),
                PolicyNumber = new Random().Next(900000000, 999999999),
                StartDate = DateTime.Now.AddMonths(-new Random().Next(1, 10)),
                EndDate = DateTime.Now.AddMonths(new Random().Next(1, 10))
            });
        }

        for (int b = 1; b <= 10; b++)
        {
            if (_dbContext.Beneficiaries.AsNoTracking().Any(x => x.Id == b))
                continue;

            _dbContext.Add(
                new InsuranceBeneficiary()
                {
                    Id = b,
                    Nin = 100000000 + b,
                    Gender = Gender.Male,
                    FirstName = "Beneficiary FirstName" + b,
                    FatherName = "FatherName" + b,
                    LastName = "LastName" + b,
                }
            );
        }

        if (_dbContext.Providers.AsNoTracking().Any())
            return;

        _dbContext.AddRange(new[]
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
            }
        });
        _dbContext.SaveChanges();
    }

    public async Task<List<TResult>> GetPolicy<TResult>(IPolicyQueryable<TResult> policyQueryable)
    {
        var result = await _dbContext.Policies.AsNoTracking()
            .Select(policyQueryable.QuerySelector())
            .ToListAsync();
        return result;
    }
}