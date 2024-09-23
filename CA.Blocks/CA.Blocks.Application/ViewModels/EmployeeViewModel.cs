﻿using CA.Blocks.Application.Common.ViewModels;

namespace CA.Blocks.Application.ViewModels;

public class EmployeeViewModel : TrackableEntityViewModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public EnumViewModel? Gender { get; set; }
    public string Address { get; set; } = string.Empty;
}
