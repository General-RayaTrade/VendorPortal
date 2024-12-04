using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorPortal.Core.Models
{
    public class D365Model
    {
        public class Address
        {
            public string RecID { set; get; }
            public string BuildingNumber { get; set; }
            public string AddressLine_1 { get; set; }
            public string AddressLine_2 { get; set; }
            public string City { get; set; }
            public string AccountNumber { get; set; }
            public string District { get; set; }
            public string StreetNumber { get; set; }
        }
        public class ClsCustomer
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Gender { get; set; }
            public string Tax_Regist_Number { get; set; }
            public string Customer_Type { get; set; }
            public string M_CustID { get; set; }
            public string NationalID { get; set; }
            public string Birthday { get; set; }
            public string PhoneNumber { get; set; }
        }

        public class ShippingAddress
        {
            public string BuildingNumber { get; set; }
            public string AddressLine_1 { get; set; }
            public string AddressLine_2 { get; set; }
            public string City { get; set; }
            public string region { get; set; }
            public string District { get; set; }
            public string StreetNumber { get; set; }
        }

        public class OrderItem
        {
            public string StoreID { get; set; }
            public string ReferenceId { get; set; }
            public string ItemCode { get; set; }
            public int QtySold { get; set; }
            public decimal UnitPrice { get; set; }
            public int HasInsurance { set; get; }
            public decimal InsuranceAmount { set; get; }

            public string Store_RECID { set; get; }
            public string ItemCode_RECID { set; get; }
            public string Category_Name { set; get; }
        }

        public class Totals
        {
            public double base_total { get; set; }
            public double discount { get; set; }
            public string discount_description { get; set; }
            public double payment_fees { get; set; }
            public double grand_total { get; set; }
            public string discount_coupon { set; get; }
            public string shipping_fees { set; get; }
            public string COD_Delivery_Fee { set; get; }
            public string additional_payment_fee { set; get; }

            public double total_paid { get; set; }
            public double total_due { get; set; }
        }

        public class SalesOrder
        {
            public string M_OrderNumber { get; set; }
            public DateTime CreateDate { get; set; }
            public string DueDate { get; set; }
            public string M_ReferenceId { get; set; }
            public string StoreID { get; set; }
            public long WorkerNumber { get; set; }
            public string M_Recive_Type { get; set; }
            public string Comment { get; set; }
            public string PaymentMethod { get; set; }
            public List<ClsCustomer> Customer { get; set; }
            public List<ShippingAddress> shipping_address { get; set; }
            public List<OrderItem> OrderItems { get; set; }
            public Totals Totals { get; set; }
            public string Source { set; get; }
            public List<Payment> Payments { get; set; }
        }
        public class Payment
        {
            public string name { get; set; }
            public string value { get; set; }
        }
        public class D365_SalesOrder_Request
        {
            public List<SalesOrder> SalesOrder { get; set; }

        }
        public class SalesOrder_Update_List
        {
            public List<SO.SalesOrder_Update> SalesOrder { get; set; }

        }
        public class Customer
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Gender { get; set; }
            public string Tax_Regist_Number { get; set; }
            public string Customer_Type { get; set; }
            public string M_CustID { get; set; }
            public string NationalID { get; set; }
            public string Birthday { get; set; }
        }
        public class OrderItemWithAction
        {
            public int ActionType { set; get; }
            public string ReferenceId { get; set; }
            public object ItemCode { get; set; }
            public int QtySold { get; set; }
            public double UnitPrice { get; set; }
        }

        public class SalesOrderWithOrderNumber
        {
            public string OrderNumber { set; get; }
            public string M_OrderNumber { get; set; }
            public DateTime CreateDate { get; set; }
            public string DueDate { get; set; }
            public string M_ReferenceId { get; set; }
            public string StoreID { get; set; }
            public string WorkerNumber { get; set; }
            public string M_Recive_Type { get; set; }
            public string Comment { get; set; }
            public string PaymentMethod { get; set; }
            public List<ClsCustomer> Customer { get; set; }
            public List<ShippingAddress> shipping_address { get; set; }
            public List<OrderItemWithAction> OrderItems { get; set; }
            public Totals Totals { get; set; }
        }

        public class SO
        {
            public class OrderItem
            {
                public string ReferenceId { get; set; }
                public object ItemID { get; set; }
                public int QtySold { get; set; }
                public decimal UnitPrice { get; set; }
                public string StoreID { set; get; }
            }

            public class SalesOrder
            {
                public string M_OrderNumber { get; set; }
                public string DueDate { get; set; }
                public string Address { get; set; }
                public string AccountNumber { get; set; }
                public string M_ReferenceId { get; set; }
                public string StoreID { get; set; }
                public long WorkerNumber { get; set; }
                public string M_Recive_Type { get; set; }
                public string Comment { get; set; }
                public string PaymentMethod { get; set; }
                public List<OrderItem> OrderItems { get; set; }
                public string API_SOURCE { set; get; }
                public string ORIGINAL_REF_NUM { set; get; }
                public string POD_AMOUNT { set; get; }
                public string SHIPPING_WAY { set; get; }
            }
            public class OrderItem_Update
            {
                public string ReferenceId { get; set; }
                public object ItemID { get; set; }
                public int QtySold { get; set; }
                public decimal UnitPrice { get; set; }
                public int ActionType { get; set; }
            }
            public class SalesOrder_Update
            {
                public string OrderNumber { get; set; }
                public string M_OrderNumber { get; set; }
                public string DueDate { get; set; }
                public string Address { get; set; }
                public string AccountNumber { get; set; }
                public string M_ReferenceId { get; set; }
                public string StoreID { get; set; }
                public string WorkerNumber { get; set; }
                public string M_Recive_Type { get; set; }
                public string Comment { get; set; }
                public string PaymentMethod { get; set; }
                public List<OrderItem_Update> OrderItems { get; set; }
            }
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);



        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Event
        {
            public ProductOrder productOrder { get; set; }
        }

        public class ProductOrder
        {
            public string id { get; set; }
            public List<RelatedParty> relatedParty { get; set; }
            public string state { get; set; }
        }

        public class RelatedParty
        {
            public string name { get; set; }
            public string role { get; set; }
        }

        public class UpdateETIOrderStatusRoot
        {
            public string eventId { get; set; }
            public string eventType { get; set; }
            public Event Event { get; set; }
        }

        public class CancelSalesOrderRequest
        {
            public string MagentoRef { set; get; }
        }
        public class CancelSalesOrderRequest_BySalesID
        {
            public string SalesID { set; get; }
        }
        public class GetInstallmentAppsByMobile
        {
            public string CustomerMobile { set; get; }
        }
        public class GetInstallmentAppsByNational
        {
            public string NationalID { set; get; }
        }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
        public class InstallmentData
        {
            public string Cust_FirstName { get; set; }
            public string Cust_MiddleName { get; set; }
            public string Cust_LastName { get; set; }
            public string Cust_FamilyName { get; set; }
            public string Cust_NationalID { get; set; }
            public string Cust_NationalID_Date { get; set; }
            public string Cust_NationalIDAddress { get; set; }
            public string Cust_CurrentAddress { get; set; }
            public string Cust_MartialStatus { get; set; }
            public string Cust_NationaIDGovernorate { get; set; }
            public string DistrictName { get; set; }
            public string Cust_StreetName { get; set; }
            public string Cust_BuildingNumber { get; set; }
            public string MobileNumber { set; get; }
            public string Cust_Job { get; set; }
            public string Cust_Company { get; set; }
            public string Cust_JobAddress { get; set; }
            public string Cust_JobDate { get; set; }
            public string Cust_TotallSalary { get; set; }
        }

        public class SubmitCorporateRequest
        {
            public string Serial_Number { set; get; }
            public string Mobile_Number { set; get; }
            public string Symptom { set; get; }
            public string CustomerAddress { set; get; }

        }
        public class GetAfterSalesReceipt
        {
            public string WorkOrderID { set; get; }
        }
        public class CorporateCaseResponse
        {
            public bool Result { set; get; }
            public string ResultText { set; get; }
        }
        public class GetInstallmentAppsResponse
        {
            public int Records { set; get; }
            public string Cust_FirstName { set; get; }
            public string Installment_UniqueID { set; get; }
            public string Installment_MonthlyPaid { set; get; }
            public string Installment_Months { set; get; }
            public string Installment_Comment { set; get; }
            public string PendingReason_En { set; get; }
            public string PendingReason { set; get; }
            public string id { set; get; }
        }

        public class GetInstallmentAppsResponseList
        {
            public List<GetInstallmentAppsResponse> Result { set; get; }
        }

        public class CancelSalesOrderResponse
        {
            public bool Status { set; get; }
            public string Message { set; get; }
        }
        public class D365_SalesOrderResponse
        {
            public bool status { get; set; }
            public string Magento_OrderNumber { get; set; }
            public string D365_OrderNumber { get; set; }
            public string Message { get; set; }
            public List<string> Items { get; set; }
            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
        public class D365_SalesOrderResponses
        {
            public List<D365_SalesOrderResponse> D365_SalesOrderResponseList { set; get; }
        }
        public class Phone
        {
            public string PhoneNumber { get; set; }
            public string AccountNumber { get; set; }
        }
        public class ServiceResponse
        {

        }
        public class ServiceCustomerResponse
        {
            public string AccountNumber { get; set; }
            public string Status { get; set; }

        }
        public class ServiceResponseException
        {
            public string Message { get; set; }
            public string ExceptionType { get; set; }
            public string ActivityId { get; set; }
        }
        public class ServiceAddressResponse
        {
            public string RecID { get; set; }
            public string AccountNumber { get; set; }
            public string Status { get; set; }

        }
        public class ServiceResponseSO
        {
            public string OrderNumber { get; set; }
            public string M_OrderNumber { get; set; }
            public string Status { get; set; }
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class TransferOrderHeaders
        {
            public string TransferOrderNumber { get; set; }
            public string RequestedReceiptDate { get; set; }
            public string RequestedShippingDate { get; set; }
            public string ShippingWarehouseId { get; set; }
            public string ReceivingWarehouseId { get; set; }
            public string Test_Custom { get; set; }
        }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class TransferOrderLines
        {
            public string TransferOrderNumber { get; set; }
            public string ItemNumber { get; set; }
            public int TransferQuantity { get; set; }
            public string ItemSerialNumber { get; set; }
            public string ProductStyleId { get; set; }
        }



    }
}
