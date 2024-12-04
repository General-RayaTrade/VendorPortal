using Microsoft.EntityFrameworkCore;
using VendorPortal.Core;
using VendorPortal.Core.IServices;
using VendorPortal.Core.Models;
using VendorPortal.EF;
using VendorPortal.EF.IRepositories;

namespace VendorPortal.Service.Services
{
    public class ConfirmationService : IConfirmationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICitiesDistrictsService _citiesDistrictsService;
        private readonly IOrderService _orderService;
        private readonly IMoblieNumberValidationService _moblieNumberValidationService;
        private readonly ISupplyChainGatewayService _supplyChainGatewayService;
        public ConfirmationService(IUnitOfWork unitOfWork,
                                   ICitiesDistrictsService citiesDistrictsService,
                                   IOrderService orderService,
                                   IMoblieNumberValidationService moblieNumberValidationService,
                                   ISupplyChainGatewayService supplyChainGatewayService)
        {
            _unitOfWork = unitOfWork;
            _citiesDistrictsService = citiesDistrictsService;
            _orderService = orderService;
            _moblieNumberValidationService = moblieNumberValidationService;
            _supplyChainGatewayService = supplyChainGatewayService;

        }
        public async Task<ConfirmationOrderResponse> ConfirmOrderAsync(ConfirmationOrderRequest request)
        {
            request = _moblieNumberValidationService.ModifyMobileNumber(request);
            if (!_moblieNumberValidationService.ValidateNumber(request))
            {
                return new ConfirmationOrderResponse()
                {
                    state = false,
                    message = "Phone Number is not valid!"
                };
            }
            request.districtCode = int.Parse(request.districtId);
            request.districtId = (await _unitOfWork.vwcityDistrict.FindAsync(dis => dis.Id.ToString() == request.districtId))!.DName;
            var response = await _supplyChainGatewayService.SendConfirmationRequestAsync(request);
            if (response.IsSuccessStatusCode)
            {
                await HandleConfirmationData(request);
                return new ConfirmationOrderResponse
                {
                    message = await response.Content.ReadAsStringAsync(),
                    statusCode = 201,
                    state = true
                };
            }
            else
            {
                return new ConfirmationOrderResponse
                {
                    message = await response.Content.ReadAsStringAsync(),
                    statusCode = 400,
                    state = false
                };
            }
        }

        public async Task<ConfirmationOrderData?> GetOrderConfirmationDataAsync(string vendor, string orderReference)
        {
            var districts = await _citiesDistrictsService.GetCityDistrictsAsync();
            var existingConfirmation = await TryGetConfirmedOrderDateAsync(vendor, orderReference);
            OrdersXsc order = new OrdersXsc();
            if (existingConfirmation == null)
            {
                order = await _orderService.GetOrderAsync(vendor, orderReference);
            }
            if (order is not { })
            {
                return null;
            }
            var (city, district) = await _unitOfWork.GetOrderConfirmationsShippingAddressDataAsync(orderReference);
            return new ConfirmationOrderData
            {
                district = districts,
                deleiveryDate = DateTime.Now.AddDays(1),
                dxCreationDate = order!.DxCreatedDate,
                salesOrderNumber = order.OrderRef,
                shippingAddress = existingConfirmation?.OrderAddress ?? order.CustomerAddress!,
                firstMobileNumber = existingConfirmation?.OrderMobileNumberOne ?? order.CustomerMobile!,
                secondMoblieNumber = existingConfirmation?.OrderMobileNumberTwo!,
                email = null,
                createBy = null,
                selectedDistrictId = existingConfirmation?.DistrictId?.ToString(),
                selectedCityId = existingConfirmation?.CityCode.ToString(),
                shippingMethod = existingConfirmation?.DeliveryMethod!,
                selectedCityName = city,
                selectedDistrictName = district,
            };
        }
        private async Task<OrderConfirmationsData?> TryGetConfirmedOrderDateAsync(string vendor, string orderReference)
        {
            return await _unitOfWork.orderConfirmationsData.FindAsync(order => order.OrderNumber.Equals(orderReference));
        }
        private async Task HandleConfirmationData(ConfirmationOrderRequest request)
        {
            try
            {

                var existingData = await _unitOfWork.orderConfirmationsData.FindAsync(ord => ord.OrderNumber == request.Ordernumber);

                if (existingData != null)
                {
                    UpdateExistingOrderConfirmation(existingData, request);
                    _unitOfWork.orderConfirmationsData.Update(existingData);
                }
                else
                {
                    await _unitOfWork.orderConfirmationsData.AddAsync(CreateNewOrderConfirmation(request));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private OrderConfirmationsData CreateNewOrderConfirmation(ConfirmationOrderRequest model)
        {
            return new OrderConfirmationsData
            {
                DeliveryMethod = model.deliveryMethod,
                DistrictId = model.districtCode,
                OrderAddress = model.street,
                OrderMobileNumberOne = model.MobileNumber1,
                OrderMobileNumberTwo = model.MobileNumber2 ?? string.Empty,
                OrderNumber = model.Ordernumber,
                CityCode = int.Parse(model.cityId!)
            };
        }
        private void UpdateExistingOrderConfirmation(OrderConfirmationsData existingData, ConfirmationOrderRequest model)
        {
            existingData.DeliveryMethod = model.deliveryMethod;
            existingData.DistrictId = model.districtCode;
            existingData.OrderAddress = model.street;
            existingData.OrderMobileNumberOne = model.MobileNumber1;
            existingData.OrderMobileNumberTwo = model.MobileNumber2 ?? string.Empty;
            existingData.CityCode = int.Parse(model.cityId!);
        }

        public async Task<(bool IsValid, string Message)> ValidateOrderConfirmationConstraintsAsync(string vendor, string orderReference)
        {
            // Fetch the order
            OrdersXsc? order = await _orderService.GetOrderAsync(vendor, orderReference);

            if (order == null)
            {
                return (false, "This order doesn't exist.");
            }

            // Normalize strings for comparison
            string orderStatus = order.DxStatus.ToLower();
            string orderSource = order.OrderSource.ToLower();
            string normalizedVendor = vendor.ToLower();

            // Validate constraints
            if (!orderSource.Contains(normalizedVendor))
            {
                return (false, "This order doesn't exist.");
            }

            if (!orderStatus.Contains("open"))
            {
                return (false, "Cannot confirm this order as it is not an open order.");
            }

            // All constraints satisfied
            return (true, string.Empty);
        }

    }
}
