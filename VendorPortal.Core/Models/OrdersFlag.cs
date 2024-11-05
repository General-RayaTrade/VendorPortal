using System;
using System.Collections.Generic;

namespace VendorPortal.Core;

public partial class OrdersFlag
{
    public int Id { get; set; }

    public string? OrderNumber { get; set; }

    public int? FlagStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int FlagId { get; set; }
}
