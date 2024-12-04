using System;
using System.Collections.Generic;

namespace VendorPortal.EF;

public partial class OrderStatus
{
    public int Id { get; set; }

    public string OrderRef { get; set; } = null!;

    public string? OrderStatus1 { get; set; }

    public string? DeliveryMethod { get; set; }

    public string? OrderAwb { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? ModificationDate { get; set; }
}
