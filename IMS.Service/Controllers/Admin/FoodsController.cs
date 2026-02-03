using IMS.Domain.Models;
using IMS.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Service.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/foods")]
    //[Authorize(Roles = "Admin")]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }
        
        // CREATE: api/admin/foods
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateFood([FromBody] Food food)
        {
            _foodService.AddFood(food);
            return Ok();
        }

        // READ: api/admin/foods
        [HttpGet]
        public async Task<IActionResult> GetFood()
        {
            var foods = _foodService.GetFood();
            return Ok(foods);
        }

        // MAKE THIS MORE CLEARER
        // If I remember correctly, there's a bad request annotator feature here
        // Further, there's also partial patching where you recieve the entire item
        // But then only update the necessary details using the ORM

        //  UPDATE: api/admin/foods/{id}
        [HttpPatch("{foodId:guid}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateFood(Guid foodID, [FromBody] Food food)
        {
            if (foodID != food.FoodID)
                return BadRequest();

            _foodService.UpdateFood(foodID, food);
            return Ok();
        }

        // DELETE: api/admin/foods/{id}
        [HttpDelete("{foodId:guid}")]
        public async Task<IActionResult> DeleteFood(Guid foodId)
        {
            _foodService.DeleteFood(foodId);
            return Ok();
        }
    }
}
