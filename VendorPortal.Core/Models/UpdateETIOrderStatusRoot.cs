using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VendorPortal.Core.Models.D365Model;

namespace VendorPortal.Core.Models
{
    public class UpdateETIOrderStatusRoot
    {
        public string eventId { get; set; }
        public string eventType { get; set; }
        public Event Event { get; set; }
    }
}
