using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class StepIngridient
{
    public int IdStep { get; set; }

    public int IdIngridient { get; set; }

    public virtual Ingredient Ingridient { get; set; } = null!;

    public virtual Step Step { get; set; } = null!;
}
