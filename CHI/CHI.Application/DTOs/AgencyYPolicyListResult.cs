using System.Linq.Expressions;
using CHI.Domain.Entities;

namespace CHI.Application;

public sealed class AgencyYPolicyListResult : IPolicyQueryable<AgencyYPolicyListResult>
{
    public int BeneficiaryNin { get; set; }
    public string BeneficiaryFirstName { get; set; }
    public string BeneficiaryFatherName { get; set; }
    public string BeneficiaryLastName { get; set; }
    public string ProviderName { get; set; }
    public string ProviderCrNumber { get; set; }

    public Expression<Func<InsurancePolicy, AgencyYPolicyListResult>> QuerySelector()
    {
        return x => new AgencyYPolicyListResult()
        {
            BeneficiaryNin = x.Beneficiary.Nin,
            ProviderName = x.Provider.Name,
            BeneficiaryFirstName = x.Beneficiary.FirstName,
            BeneficiaryFatherName = x.Beneficiary.FatherName,
            BeneficiaryLastName = x.Beneficiary.LastName,
            ProviderCrNumber = x.Provider.CrNumber
        };
    }
}