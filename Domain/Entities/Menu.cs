using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Menu
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Day> Dinners { get; set; } = new List<Day>();

    public virtual ICollection<Day> Meals { get; set; } = new List<Day>();

    public virtual ICollection<Step> Steps { get; set; } = new List<Step>();

    public virtual User User { get; set; } = null!;
}
