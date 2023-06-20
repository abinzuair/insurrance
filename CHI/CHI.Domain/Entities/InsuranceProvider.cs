namespace CHI.Domain.Entities;

public sealed class InsuranceProvider : Entity
{
    public string CrNumber { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}