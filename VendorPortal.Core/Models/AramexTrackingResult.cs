using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorPortal.Core.Models
{
    public class AramexTrackingResult
    {
        public List<TrackShipmentsResult> TrackShipmentsResult { get; set; }
    }
    public class Status
    {
        public string ChargeableWeight { get; set; }
        public string Comments { get; set; }
        public string GrossWeight { get; set; }
        public string ProblemCode { get; set; }
        public string UpdateCode { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string UpdateDescription { get; set; }
        public string UpdateLocation { get; set; }
        public string WaybillNumber { get; set; }
        public string WeightUnit { get; set; }
    }

    public class TrackShipmentsResult
    {
        public string AWB { get; set; }
        public string Existing { get; set; }
        public List<Status> Status { get; set; }
    }
}
