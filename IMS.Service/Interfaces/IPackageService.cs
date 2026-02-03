using IMS.Domain.Models;

namespace IMS.Service.Interfaces
{
    public interface IPackageService
    {
        void AddPackage(MealPackage mealPackage);
        IEnumerable<MealPackage> GetPackage();
        void UpdatePackage(MealPackage mealPackage);
        void DeletePackage(Guid mealPackageID);
    }
}
