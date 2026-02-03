using IMS.Domain.Models;
using IMS.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Service.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/mealpackages")]
    //[Authorize(Roles = "Admin")]
    public class PackagesController : ControllerBase
    {

        private readonly IPackageService _packageService;

        public PackagesController(IPackageService packageService) 
        { 
            _packageService = packageService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePackage([FromBody] MealPackage mealPackage) 
        {
            _packageService.AddPackage(mealPackage);
            return Ok (mealPackage);
        }

        [HttpGet]
        public async Task<IActionResult> GetPackage()
        { 
            var packageService = _packageService.GetPackage();
            return Ok(packageService);
        }

        [HttpPatch("{PackageID:Guid}")]
        public async Task<IActionResult> UpdatePackage(Guid PackageID, [FromBody] MealPackage mealPackage)
        {
            if (PackageID != mealPackage.MealPackageID) {
                return BadRequest();
            }

            _packageService.UpdatePackage(mealPackage);
            return Ok(mealPackage);
        }

        [HttpDelete("{PackageID:Guid}")]
        public async Task<IActionResult> DeletePackage(Guid PackageID)
        {
            _packageService.DeletePackage(PackageID);
            return Ok();
        }
    }
}
