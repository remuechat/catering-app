using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Domain.Enums;

namespace IMS.Domain.Models.Financial
{
    public class Payment
    {
        // Primary key
        public required String PaymentID { get; set; }

        // Foreign/navigation keys
        public int RecieptID { get; set; }
        public Receipt? Receipt { get; set; }

        // Payment attributes
        public PaymentMethodType PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime TimeStamp { get; set; }  = DateTime.Now;
    }
}
