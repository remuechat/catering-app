using IMS.Domain.Models;

namespace IMS.Service.Interfaces
{
    public interface IFoodService
    {
        void AddFood(Food food);
        IEnumerable<Food> GetFood();
        void UpdateFood(Guid foodID, Food food);
        void DeleteFood(Guid foodID);

        // ADD THESE LATER ON!
        //void AddFood(Food food);
        //IEnumerable<Food> GetFoods();
        //Food GetFoodById(Guid foodId);
        //void UpdateFood(Food food);
        //void DeleteFood(Guid foodId);
        //int GetFoodInventory(Guid foodId);
        //void UpdateInventory(Guid foodId, int quantityChange);
        //IEnumerable<Food> SearchFoods(string searchTerm);
        //IEnumerable<Food> GetFoodsByCategory(string category);
    }
}
