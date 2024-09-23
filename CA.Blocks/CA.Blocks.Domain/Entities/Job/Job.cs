using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Blocks.Domain.Common;

namespace CA.Blocks.Domain.Entities;
public class Job : BaseAuditableEntity
{
    public string Description { get; set; } = string.Empty;

}

