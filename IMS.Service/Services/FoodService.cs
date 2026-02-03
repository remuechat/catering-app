using IMS.Domain.Models;
using IMS.Service.Interfaces;

namespace IMS.Service.Services
{
    public class FoodService : IFoodService
    {
        public readonly List<Food> _foods = new List<Food>();

        public void AddFood(Food food) {
            _foods.Add(food);
        }
        public IEnumerable<Food> GetFood() { 
            return _foods;
        }
        public void UpdateFood(Guid FoodID, Food food) { 

        }

        public void DeleteFood(Guid foodID) { 
        
        }
    }
}
