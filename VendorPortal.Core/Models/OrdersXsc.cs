using System;
using System.Collections.Generic;

namespace VendorPortal.Core;

public partial class OrdersXsc
{
    public string OrderInfo { get; set; } = null!;

    public string Source { get; set; } = null!;

    public string OrderNumber { get; set; } = null!;

    public string OrderRef { get; set; } = null!;

    public string CustomerInfo { get; set; } = null!;

    public string? CustomerName { get; set; }

    public string? CustomerMobile { get; set; }

    public string? CustomerAddress { get; set; }

    public string DeliveryInfo { get; set; } = null!;

    public string? ShippingwayCustom { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string Awb { get; set; } = null!;

    public string StatusInfo { get; set; } = null!;

    public string DxStatus { get; set; } = null!;

    public string ScAwbStatus { get; set; } = null!;

    public string ScInternalStatus { get; set; } = null!;

    public string OrderDates { get; set; } = null!;

    public DateTime DxCreatedDate { get; set; }

    public DateTime? DxInvoiceDate { get; set; }

    public string ScCreatedDate { get; set; } = null!;

    public DateTime ScExpectedDeliver { get; set; }

    public string ScAwbStatusDate { get; set; } = null!;

    public string FleetInfo { get; set; } = null!;

    public string? ScShipmentCreated { get; set; }

    public string ScShipmentNo { get; set; } = null!;

    public string ScTruckPalletNo { get; set; } = null!;

    public string ScDriverName { get; set; } = null!;

    public string ScDriverMobile { get; set; } = null!;

    public string ScPodAmount { get; set; } = null!;

    public string WarehouseInfo { get; set; } = null!;

    public string? WarehouseName { get; set; }

    public string ScReleaseCreated { get; set; } = null!;

    public string ScReleaseStatus { get; set; } = null!;

    public string ScReleaseNo { get; set; } = null!;

    public string? ReleasedInfo { get; set; }

    public string ScReleaseDate { get; set; } = null!;

    public string Driver { get; set; } = null!;

    public string ScDriverDeliverProduct { get; set; } = null!;

    public string ScDriverUploadedDocument { get; set; } = null!;

    public string ScDriverComment { get; set; } = null!;

    public string? District { get; set; }

    public string? City { get; set; }

    public string OrderSource { get; set; } = null!;

    public string? ReturnNumber { get; set; }
}
