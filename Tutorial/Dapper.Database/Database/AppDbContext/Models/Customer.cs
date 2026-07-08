using System;
using System.Collections.Generic;

namespace Dapper.Database.Database.AppDbContext.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Country { get; set; }

    public int? Score { get; set; }
}
