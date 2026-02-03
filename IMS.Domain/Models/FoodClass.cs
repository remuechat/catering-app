using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum FoodType
{
    Viand,
    Rice,
    Desert,
}

namespace IMS.Domain.Models
{
    public class Food
    {
        [Required]
        [Key]
        public Guid FoodID { get; private set; }

        [Required]
        public DateTime CreatedBy { get; private set; }
        public FoodType FoodType { get; set; }

        [Required]
        public string FoodName { get; set; } = string.Empty;

        public decimal FoodPrice { get; set; }

        public bool isAlaCarte { get; set; }

        public bool isAvailable { get; set; }

        public Food()
        {
            FoodID = Guid.NewGuid();
            CreatedBy = DateTime.Now;
        }
    }

    public class Menu
    {
        [Key]
        Guid MenuID { get; set; }
        String? MenuName { get; set; }
        public virtual ICollection<OrderItem>? MenuItems { get; set; }
    }

    public class OrderItem { 
        public Guid OrderItemID { get; set; }
        public Guid OrderID { get; set; }
        public Guid FoodID { get; set; }
        public int Quantity { get; set; }
    }

    public class Order
    {
        [Key]
        Guid OrderID { get; set; }

        DateTime OrderDate { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderID = Guid.NewGuid();
            OrderDate = DateTime.Now;
            OrderItems = new List<OrderItem>();
        }
    }

    public class Cart {
        [Key]
        Guid CartID { get; set; }
        public virtual ICollection<Order>? CartItems { get; set; }
    }

    public class MealPackage
    {
        [Key]
        Guid MealPackageID { get; set; }
        String? PackageName { get; set; }
        public virtual ICollection<OrderItem>? MenuItems { get; set; }
    }
}
