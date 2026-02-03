using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Enums;

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
    }
}
