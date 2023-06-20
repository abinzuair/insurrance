namespace CHI.Domain.Entities;

public sealed class InsuranceBeneficiary : Entity
{
    public int Nin { get; set; }
    public string FirstName { get; set; }
    public string FatherName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
}