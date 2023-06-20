using System.Linq.Expressions;
using CHI.Domain.Entities;

namespace CHI.Application;

public sealed class AgencyXPolicyListResult : IPolicyQueryable<AgencyXPolicyListResult>
{
    public int BeneficiaryNin { get; set; }
    public string BeneficiaryFullName { get; set; }
    public string ProviderName { get; set; }

    public Expression<Func<InsurancePolicy, AgencyXPolicyListResult>> QuerySelector()
    {
        return x => new AgencyXPolicyListResult()
        {
            BeneficiaryNin = x.Beneficiary.Nin,
            ProviderName = x.Provider.Name,
            BeneficiaryFullName = $"{x.Beneficiary.FirstName} {x.Beneficiary.FatherName} {x.Beneficiary.LastName}"
        };
    }
}