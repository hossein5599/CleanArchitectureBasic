using CA.Blocks.Domain.Common;
using CA.Blocks.Domain.Enums;

namespace CA.Blocks.Domain.Entities;
public class Employee : BaseAuditableEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public string Address { get; set; } = string.Empty;
}
