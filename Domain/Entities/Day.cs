using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Day
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public DateOnly Date { get; set; }

    public int? IdMeal { get; set; }

    public int? IdDinner { get; set; }

    public virtual Menu? Dinner{ get; set; }

    public virtual Menu? Meal { get; set; }
}
