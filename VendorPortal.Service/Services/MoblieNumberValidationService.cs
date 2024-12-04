using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VendorPortal.Core.IServices;
using VendorPortal.Core.Models;

namespace VendorPortal.Service.Services
{
    public class MoblieNumberValidationService : IMoblieNumberValidationService
    {
        public ConfirmationOrderRequest ModifyMobileNumber(ConfirmationOrderRequest confirmationOrderRequest)
        {
            if (!confirmationOrderRequest.MobileNumber1.StartsWith('0'))
            {
                confirmationOrderRequest.MobileNumber1 = string.Concat('0', confirmationOrderRequest.MobileNumber1);
                //Log.Information("Modified MobileNumber1 to: {MobileNumber1}", number);
            }
            if (!string.IsNullOrEmpty(confirmationOrderRequest.MobileNumber2) && !confirmationOrderRequest.MobileNumber2.StartsWith('0'))
            {
                confirmationOrderRequest.MobileNumber2 = string.Concat('0', confirmationOrderRequest.MobileNumber2);
                //Log.Information("Modified MobileNumber1 to: {MobileNumber1}", number);
            }
            return confirmationOrderRequest;
        }

        public bool ValidateNumber(ConfirmationOrderRequest confirmationOrderRequest)
        {

            if (!IsPhoneNumber(confirmationOrderRequest.MobileNumber1) || !IsPhoneNumber(confirmationOrderRequest.MobileNumber2))
            {
                return false;
            }
            return true;
        }
        private bool IsPhoneNumber(string number)
        {
            if (!string.IsNullOrEmpty(number))
                return Regex.Match(number, @"^01[0125][0-9]{8}$").Success;
            else //this fun not valid for empty or not just check mobile number validations.
                return true;
        }
    }
}
