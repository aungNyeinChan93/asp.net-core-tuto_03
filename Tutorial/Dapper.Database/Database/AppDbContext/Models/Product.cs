using System;
using System.Collections.Generic;

namespace Dapper.Database.Database.AppDbContext.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Product1 { get; set; }

    public string? Category { get; set; }

    public int? Price { get; set; }
}
