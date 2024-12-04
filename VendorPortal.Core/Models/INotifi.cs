using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorPortal.EF;

namespace VendorPortal.Core.Models
{
    internal interface INotifi
    {
        Task NotifiOtherAsync(Notification notification);
    }
}
