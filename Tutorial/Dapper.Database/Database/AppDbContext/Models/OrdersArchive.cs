using System;
using System.Collections.Generic;

namespace Dapper.Database.Database.AppDbContext.Models;

public partial class OrdersArchive
{
    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? CustomerId { get; set; }

    public int? SalesPersonId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public DateOnly? ShipDate { get; set; }

    public string? OrderStatus { get; set; }

    public string? ShipAddress { get; set; }

    public string? BillAddress { get; set; }

    public int? Quantity { get; set; }

    public int? Sales { get; set; }

    public DateTime? CreationTime { get; set; }
}
