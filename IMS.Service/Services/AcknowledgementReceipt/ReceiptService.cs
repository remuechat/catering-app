using IMS.Domain.Entities.Financial.AcknowledgementReceipts;
using IMS.Domain.Entities.Financial.Promos;
using IMS.Domain.Enums;
using IMS.Domain.Interfaces;
using IMS.Service.DTOs.Financial.AcknowledgementReceipts;
using IMS.Service.DTOs.Financial.AcknowledgmentReceipts;
using IMS.Service.Mappings;
using Microsoft.Identity.Client;


namespace IMS.Service.Services.AcknowledgementReceipt
{
    using ReceiptEntity = IMS.Domain.Entities.Financial.AcknowledgementReceipts.AcknowledgementReceipt;

    public interface IReceiptService
    {
        // For table
        Task<IEnumerable<ReceiptSummaryDto>> GetAllSummariesAsync();

        // For Details
        Task<ReceiptDetailsDto> GetDetailsAsync(int receiptId);

        // For creating new ones
        Task<ReceiptDetailsDto> CreateReceiptAsync(Guid orderId, int customerId, decimal subtotal, Promo? promoId);
    }

    public class ReceiptService : IReceiptService
    {
            private readonly IPromoRepository _promoRepo;
            private readonly IUserRepository _userRepo;
            private readonly IReceiptRepository _receiptRepo;

            public ReceiptService(
                IPromoRepository promoRepo,
                IUserRepository userRepo,
                IReceiptRepository receiptRepo)
            {
                _promoRepo = promoRepo;
                _userRepo = userRepo;
                _receiptRepo = receiptRepo;
            }

        // FOR THE TABLE
        public async Task<IEnumerable<ReceiptSummaryDto>> GetAllSummariesAsync()
        {
            // getting receipt records from the database
            var entities = await _receiptRepo.GetAllAsync();
            var summaries = new List<ReceiptSummaryDto>();

            foreach (var entity in entities)
            {
                //fetching the AppUser record using the CustomerID
                var user = await _userRepo.GetByIdAsync(entity.CustomerID);
                string fullName = user != null
                    ? $"{user.FirstName} {user.LastName}"
                    : "Unknown Customer";

                //mapping entity and the name into the Summary DTO
                summaries.Add(ReceiptMapping.MapToSummaryDto(entity, fullName));
            }

            return summaries;
        }

        // 2. FOR THE POP-UP (Details View)
        public async Task<ReceiptDetailsDto> GetDetailsAsync(int receiptId)
            {
                var entity = await _receiptRepo.GetByIdAsync(receiptId);
                if (entity == null) return null!;

                var user = await _userRepo.GetByIdAsync(entity.CustomerID);
                string fullName = user != null ? $"{user.FirstName} {user.LastName}" : "Unknown Customer";

                return ReceiptMapping.MapToDetailsDto(entity, fullName);
            }

            //CREATING NEW RECEIPTS
            public async Task<ReceiptDetailsDto> CreateReceiptAsync(Guid orderId, int customerId, decimal subtotal, Promo? promo)
            {
                // Promo Logic
                    decimal discountPercent = 0m;
                if (promo != null && promo.IsActive)
                {
                    discountPercent = promo.DiscountPercentageValue;
                }

                //Financial Math
                 decimal discountAmount = subtotal * discountPercent;
                decimal taxableAmount = subtotal - discountAmount;
                decimal taxAmount = taxableAmount * 0.12m;
                decimal grandTotal = taxableAmount + taxAmount;

                var receipt = new ReceiptEntity
                {
                    OrderID = orderId,
                    CustomerID = customerId,
                    Promo = promo,
                    ReceiptNumber = $"AR-{DateTime.Now:yyyyMMddHHmmss}",
                    IssueDate = DateTime.Now,
                    Status = PaymentStatus.Issued,
                    Subtotal = subtotal,
                    DiscountAmount = discountAmount,
                    TaxAmount = taxAmount,
                    GrandTotal = grandTotal
                };

                await _receiptRepo.SaveAsync(receipt);

                // fethcing Customer Name for the DTO
                var user = await _userRepo.GetByIdAsync(customerId);
                string fullName = user != null ? $"{user.FirstName} {user.LastName}" : "Customer Not Found";

                // returning the Details version so the UI can show the full breakdown
                return ReceiptMapping.MapToDetailsDto(receipt, fullName);
            }
        }
}
