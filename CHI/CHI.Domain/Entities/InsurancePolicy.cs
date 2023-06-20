namespace CHI.Domain.Entities;

public sealed class InsurancePolicy : Entity
{
    public int PolicyNumber { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int BeneficiaryId { get; set; }
    public InsuranceBeneficiary Beneficiary { get; set; }
    public int BeneficiaryNumber { get; set; }
    
    public int ProviderId { get; set; }
    public InsuranceProvider Provider { get; set; }
}