using IMS.Domain.Entities.Orders;
using IMS.Service.DTOs.Orders;

namespace IMS.Service.Mappings
{
    public static class OrderMapping
    {
        //entity to dto
        public static OrderDto MapToDto(Order entity)
        {
            if (entity == null) return null!;
            return new OrderDto
            {
                OrderID = entity.OrderID,
                ReceiptID = entity.ReceiptID,
                RecipientID = entity.RecipientID,
                RecipientName = entity.Recipient?.UserName ?? "Unknown",
                OrderTotalAmount = entity.OrderTotalAmount, // Computed in Entity
                OrderDate = entity.OrderDate,
                EstimatedDeliveryDate = entity.EstimatedDeliveryDate,
                DeliveryType = entity.DeliveryType.ToString(),
                DeliveryStatus = entity.DeliveryStatus.ToString(),
                Address = entity.Address,
                TrackingNumber = entity.TrackingNumber,
                CustomerNotes = entity.CustomerNotes,
                SpecialInstructions = entity.SpecialInstructions,
                OrderItems = entity.OrderItems.Select(i => new OrderMealProductDto
                {
                    MealProductID = i.MealProductID,
                    MealProductName = i.MealProduct?.ProductName ?? "Unknown Product",
                    ItemPrice = i.ItemPrice,
                    MealProductOrderQty = i.MealProductOrderQty,
                    SubTotal = i.SubTotal // Computed in Entity
                }).ToList()
            };
        }

        //dto to entity
        public static Order MapToEntity(OrderDto dto)
        {
            if (dto == null) return null!;
            var order = new Order
            {
                OrderID = dto.OrderID,
                ReceiptID = dto.ReceiptID,
                RecipientID = dto.RecipientID,
                Address = dto.Address,
                TrackingNumber = dto.TrackingNumber,
                CustomerNotes = dto.CustomerNotes,
                SpecialInstructions = dto.SpecialInstructions,
                // EstimatedDeliveryDate is often set by the service, but can be mapped here
                EstimatedDeliveryDate = dto.EstimatedDeliveryDate
            };

            order.OrderItems = dto.OrderItems.Select(i => new OrderMealProduct
            {
                OrderID = dto.OrderID,
                MealProductID = i.MealProductID,
                ItemPrice = i.ItemPrice,
                MealProductOrderQty = i.MealProductOrderQty
            }).ToList();

            return order;
        }
    }
}
