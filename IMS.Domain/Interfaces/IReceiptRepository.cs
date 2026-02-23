using IMS.Domain.Entities.Financial.AcknowledgementReceipts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Interfaces
{}
    public interface IReceiptRepository
    {
        Task<AcknowledgementReceipt?> GetByIdAsync(int id);
        Task<IEnumerable<AcknowledgementReceipt>> GetAllAsync();
        Task SaveAsync(AcknowledgementReceipt receipt);
    }
}
