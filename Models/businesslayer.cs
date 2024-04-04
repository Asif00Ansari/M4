using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FleetTrack.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int IsAdmin { get; set; }
    }
    public class Product
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ManufId { get; set; }
        public string ManufacturerName { get; set; }
        public string ProductImage { get; set; }
        public string Descreption { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalCost { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
    }

    public class Transaction
    {
        public Transaction()
        {
            TotalPrice = 0;
            TransactionType = "R";
        }

        public int TransactionId { get; set; }
        public string TransactionNumber { get; set; }
        public int CreatedBy { get; set; }
        public string SupplierName { get; set; }
        public int ManufId { get; set; }
        public string ManufacturerName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string TransactionType { get; set; }
    }

    public class Manufacturer
    {
        public int ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class OrderDetails
    {
        public int OrderId { get; set; }
        public string UniqueId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderBy { get; set; }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }

    }

    public class Router
    {
        public int RouteId { get; set; }
        public string RouteName { get; set; }

        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }

    }

    public class ST
    {
        public int SecurityTeamId { get; set; }
        public string SecurityTeamName { get; set; }

        public int NoOfGuards { get; set; }
        public DateTime CreatedDate { get; set; }

    }

    public class AssignToDriver
    {
        public int AssignToId { get; set; }
        public string Status { get; set; }

        public int STId { get; set; }
        public int VehicleId { get; set; }
        public int RouteId { get; set; }
        public int DriverId { get; set; }


        public DateTime CreatedDate { get; set; }

    }

    public class UpdateStatus1
    {
        public int AssignToId { get; set; }
        public string Status { get; set; }
        public int DdlStatus { get; set; }

        public int STId { get; set; }
        public int VehicleId { get; set; }
        public int RouteId { get; set; }
        public int DriverId { get; set; }


        public DateTime CreatedDate { get; set; }

    }
}