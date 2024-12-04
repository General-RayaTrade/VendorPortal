using System;
using System.Collections.Generic;

namespace VendorPortal.EF;

public partial class Notification
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Message { get; set; }

    public string? IconClass { get; set; }

    public string? Url { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsRead { get; set; }

    public string VendorName { get; set; } = null!;
    public bool ActionState { get; set; }

}
