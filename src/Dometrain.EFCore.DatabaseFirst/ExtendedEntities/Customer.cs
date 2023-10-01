namespace Dometrain.EFCore.DatabaseFirst.Entities;

public partial class Customer
{
    public string FullName => $"{FirstName} {LastName}";
}