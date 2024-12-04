using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VendorPortal.Core.Models
{

    public class ConfirmShipmentViewModel
    {
        [Required(ErrorMessage = "Order number is required.")]
        [StringLength(50, ErrorMessage = "Order number cannot exceed 50 characters.")]
        public string Ordernumber { get; set; }

        [Required(ErrorMessage = "Business Unit ID is required.")]
        public int BusinessUnitId { get; set; }

        [Required(ErrorMessage = "District ID is required.")]
        [StringLength(20, ErrorMessage = "District ID cannot exceed 20 characters.")]
        public string districtId { get; set; }

        [Required(ErrorMessage = "Delivery date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public string DeliveryDate { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        [StringLength(500, ErrorMessage = "Street cannot exceed 100 characters.")]
        public string street { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string MobileNumber1 { get; set; }

        public string MobileNumber2 { get; set; }

        //[Required(ErrorMessage = "Created by is required.")]
        [StringLength(150, ErrorMessage = "Created by cannot exceed 50 characters.")]
        public string CreateBy { get; set; }

        [StringLength(50, ErrorMessage = "AWB cannot exceed 50 characters.")]
        public string? AWB { get; set; }

        //[EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string? Email { get; set; }

        public string? deliveryMethod { get; set; }
        public string? cityId { get; set; }
    }
}
