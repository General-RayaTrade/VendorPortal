using System;
using System.Collections.Generic;

namespace VendorPortal.EF;

public partial class OrderConfirmationsData
{
    public string OrderNumber { get; set; } = null!;

    public string OrderAddress { get; set; } = null!;

    public string? OrderMobileNumberOne { get; set; }

    public string? OrderMobileNumberTwo { get; set; }

    public string? DeliveryMethod { get; set; }

    public int? DistrictId { get; set; }

    public int CityCode { get; set; }
}
