using CA.Blocks.Domain.Common;
using CA.Blocks.Domain.Entities;

namespace CA.Blocks.Domain.Events;
public class EmployeeCreatedEvent : BaseEvent
{
    public EmployeeCreatedEvent(Employee employee)
    {
        Employee = employee;
    }

    public Employee Employee { get; }
}
