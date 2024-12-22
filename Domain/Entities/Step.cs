using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Step
{
    public int Id { get; set; }

    public int IdMenu { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int StepNumber { get; set; }

    public virtual Menu Menu { get; set; } = null!;
}
