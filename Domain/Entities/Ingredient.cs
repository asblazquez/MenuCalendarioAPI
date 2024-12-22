using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Ingredient
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }
}
