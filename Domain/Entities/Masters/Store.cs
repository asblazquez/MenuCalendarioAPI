﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Store
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}
