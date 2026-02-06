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
        public required String PaymentID { get; set; }
        public PaymentMethodType PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public Decimal? TotalAmount { get; set;  }
        public DateTime TimeStamp { get; set; }  = DateTime.Now;
    }
}
