using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace StaffRegistrationPortal.DTOs
{
   
    
    
   
    public class User
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public int GenderId { get; set; }

        public int DepartmentId { get; set; }

        public string? Email { get; set; }  

        public string? Password { get; set; } 

        public string? FirstName { get; set; } 

        public string? LastName { get; set; } 

        public string? OtherName { get; set; } 

        public string? Address { get; set; } 

        public string? Phone { get; set; } 

        public bool IsActive { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool IsUpdated { get; set; }

        public string? UpdatedBy { get; set; } 

        public DateTime UpdateDate { get; set; }

        public bool IsDeactivated { get; set; }

        public string? DeactivatedBy { get; set; } 

        public DateTime DeactivatedDate { get; set; }

        public bool IsReactivated { get; set; }

        public string? ReactivatedBy { get; set; } 

        public DateTime ReactivatedDate { get; set; }
    }

   
  
    public class OrdersResponse
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string? BusinessName { get; set; }
        public string? BusinessAddress { get; set; }
        public string? BusinessPone { get; set; }
        public List<OrdersItems> OrderItems { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string? BusinessName { get; set; }
        public string? BusinessAddress { get; set; }
        public string? BusinessPone { get; set; }
    }

    public class OrdersItems
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? Quantity { get; set; }
    }


    

}
