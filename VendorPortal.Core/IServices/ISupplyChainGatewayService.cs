﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorPortal.Core.Models;

namespace VendorPortal.Core.IServices
{
    public  interface ISupplyChainGatewayService
    {
        Task<HttpResponseMessage> SendConfirmationRequestAsync(ConfirmationOrderRequest request);
    }
}