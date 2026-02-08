using System;
using System.Collections.Generic;
using System.Text;

using IMS.Domain.Models.Meals.Meal;
using Xunit;

namespace IMS.Tests.Domains.Models;
public class MealCrudTests
{
    public class MealCreateTests
    {
        [Fact]
        public void CreateMeal_WithBasicProperties_Success()
        {
            // Arrange & Act
            var meal = new Meal
            {
                MealID = 1,
                MealName = "Chicken Adobo",
                Description = "Traditional Filipino chicken dish",
                MealPrice = 12.99m,
                ServingSizePAX = 2,
                StockQuantity = 50,
                CaloriesPerServing = 450
            };

            // Assert
            Assert.Equal(1, meal.MealID);
            Assert.Equal("Chicken Adobo", meal.MealName);
            Assert.Equal(12.99m, meal.MealPrice);
            Assert.Equal(50, meal.StockQuantity);
        }

        [Fact]
        public void CreateMeal_WithOptionalFieldsNull_Success()
        {
            // Arrange & Act
            var meal = new Meal
            {
                MealID = 2,
                MealName = "Basic Meal",
                MealPrice = 8.99m,
                Description = null, // Optional field
                ImageUrl = null     // Optional field
            };

            // Assert
            Assert.Equal("Basic Meal", meal.MealName);
            Assert.Null(meal.Description);
            Assert.Null(meal.ImageUrl);
        }
    }

    public class MealReadTests
    {
        [Fact]
        public void ReadMeal_Properties_ReturnCorrectValues()
        {
            // Arrange
            var meal = new Meal
            {
                MealID = 3,
                MealName = "Beef Steak",
                MealPrice = 18.50m,
                StockQuantity = 25,
                MinOrderQuantity = 2
            };

            // Act & Assert
            Assert.Equal(3, meal.MealID);
            Assert.Equal("Beef Steak", meal.MealName);
            Assert.Equal(18.50m, meal.MealPrice);
            Assert.Equal(25, meal.StockQuantity);
            Assert.Equal(2, meal.MinOrderQuantity);
        }

        [Fact]
        public void ReadMeal_DefaultValues_AreSetCorrectly()
        {
            // Arrange & Act
            var meal = new Meal();

            // Assert
            Assert.Equal(1, meal.MinOrderQuantity); // Default value
            Assert.NotNull(meal.MealTags); // Collection initialized
            Assert.Empty(meal.MealTags); // Empty collection
        }
    }

    public class MealUpdateTests
    {
        [Fact]
        public void UpdateMeal_ChangeProperties_Success()
        {
            // Arrange
            var meal = new Meal
            {
                MealID = 1,
                MealName = "Original Name",
                MealPrice = 10.00m,
                StockQuantity = 30
            };

            // Act - Update properties
            meal.MealName = "Updated Name";
            meal.MealPrice = 15.00m;
            meal.StockQuantity = 20;
            meal.Description = "New description";
            meal.LastModifiedByUserID = 123;
            meal.LastModifiedDate = DateTime.Now;

            // Assert
            Assert.Equal("Updated Name", meal.MealName);
            Assert.Equal(15.00m, meal.MealPrice);
            Assert.Equal(20, meal.StockQuantity);
            Assert.Equal("New description", meal.Description);
            Assert.Equal(123, meal.LastModifiedByUserID);
        }

        [Fact]
        public void UpdateMeal_PriceAndStock_Success()
        {
            // Arrange
            var meal = new Meal { MealPrice = 10.00m, StockQuantity = 5 };

            // Act
            meal.MealPrice = 12.50m;
            meal.StockQuantity = 15;

            // Assert
            Assert.Equal(12.50m, meal.MealPrice);
            Assert.Equal(15, meal.StockQuantity);
        }
    }

    public class MealDeleteTests
    {
        [Fact]
        public void Meal_CanBeRemovedFromCollection_Success()
        {
            // Arrange
            var meals = new List<Meal>
                {
                    new Meal { MealID = 1, MealName = "Meal 1" },
                    new Meal { MealID = 2, MealName = "Meal 2" },
                    new Meal { MealID = 3, MealName = "Meal 3" }
                };

            // Act - Simulate deletion by removing from collection
            var mealToRemove = meals.First(m => m.MealID == 2);
            meals.Remove(mealToRemove);

            // Assert
            Assert.Equal(2, meals.Count);
            Assert.DoesNotContain(meals, m => m.MealID == 2);
            Assert.Contains(meals, m => m.MealID == 1);
            Assert.Contains(meals, m => m.MealID == 3);
        }
    }
}

public class MealTagCrudTests
{
    public class MealTagCreateTests
    {
        [Fact]
        public void CreateMealTag_WithBasicProperties_Success()
        {
            // Arrange & Act
            var mealTag = new MealTag
            {
                MealTagID = 1,
                Name = "Halal",
                Description = "Prepared according to Islamic dietary laws",
                MealTagType = MealTagType.Religious
            };

            // Assert
            Assert.Equal(1, mealTag.MealTagID);
            Assert.Equal("Halal", mealTag.Name);
            Assert.Equal("Prepared according to Islamic dietary laws", mealTag.Description);
            Assert.Equal(MealTagType.Religious, mealTag.MealTagType);
        }

        [Fact]
        public void CreateMealTag_DifferentTypes_Success()
        {
            // Arrange & Act
            var dietaryTag = new MealTag
            {
                MealTagID = 2,
                Name = "Vegetarian",
                MealTagType = MealTagType.Dietary
            };

            var healthTag = new MealTag
            {
                MealTagID = 3,
                Name = "Low Sodium",
                MealTagType = MealTagType.Health
            };

            // Assert
            Assert.Equal(MealTagType.Dietary, dietaryTag.MealTagType);
            Assert.Equal(MealTagType.Health, healthTag.MealTagType);
        }
    }

    public class MealTagReadTests
    {
        [Fact]
        public void ReadMealTag_Properties_ReturnCorrectValues()
        {
            // Arrange
            var mealTag = new MealTag
            {
                MealTagID = 5,
                Name = "Kid Friendly",
                Description = "Suitable for children",
                MealTagType = MealTagType.Preference
            };

            // Act & Assert
            Assert.Equal(5, mealTag.MealTagID);
            Assert.Equal("Kid Friendly", mealTag.Name);
            Assert.Equal("Suitable for children", mealTag.Description);
            Assert.Equal(MealTagType.Preference, mealTag.MealTagType);
        }
    }

    public class MealTagUpdateTests
    {
        [Fact]
        public void UpdateMealTag_ChangeProperties_Success()
        {
            // Arrange
            var mealTag = new MealTag
            {
                MealTagID = 1,
                Name = "Original Name",
                Description = "Original Description",
                MealTagType = MealTagType.Other
            };

            // Act
            mealTag.Name = "Updated Name";
            mealTag.Description = "Updated Description";
            mealTag.MealTagType = MealTagType.Dietary;

            // Assert
            Assert.Equal("Updated Name", mealTag.Name);
            Assert.Equal("Updated Description", mealTag.Description);
            Assert.Equal(MealTagType.Dietary, mealTag.MealTagType);
        }
    }

    public class MealTagDeleteTests
    {
        [Fact]
        public void MealTag_CanBeRemovedFromCollection_Success()
        {
            // Arrange
            var mealTags = new List<MealTag>
                {
                    new MealTag { MealTagID = 1, Name = "Tag 1" },
                    new MealTag { MealTagID = 2, Name = "Tag 2" },
                    new MealTag { MealTagID = 3, Name = "Tag 3" }
                };

            // Act - Simulate deletion by removing from collection
            var tagToRemove = mealTags.First(t => t.MealTagID == 2);
            mealTags.Remove(tagToRemove);

            // Assert
            Assert.Equal(2, mealTags.Count);
            Assert.DoesNotContain(mealTags, t => t.MealTagID == 2);
        }
    }
}

public class MealRelationshipTests
{
    [Fact]
    public void Meal_CanHaveMultipleTags_Success()
    {
        // Arrange
        var meal = new Meal { MealID = 1, MealName = "Special Meal" };
        var tag1 = new MealTag { MealTagID = 1, Name = "Spicy" };
        var tag2 = new MealTag { MealTagID = 2, Name = "Popular" };

        // Act - Simulate adding tags through junction (simplified)
        // In real scenario, this would be through MealTagJunction
        var junction1 = new MealTagJunction { Meal = meal, MealTag = tag1 };
        var junction2 = new MealTagJunction { Meal = meal, MealTag = tag2 };

        meal.MealTags.Add(junction1);
        meal.MealTags.Add(junction2);

        // Assert
        Assert.Equal(2, meal.MealTags.Count);
        Assert.Contains(meal.MealTags, j => j.MealTag.Name == "Spicy");
        Assert.Contains(meal.MealTags, j => j.MealTag.Name == "Popular");
    }

    [Fact]
    public void MealTag_CanBeAssociatedWithMultipleMeals_Success()
    {
        // Arrange
        var tag = new MealTag { MealTagID = 1, Name = "Vegetarian" };
        var meal1 = new Meal { MealID = 1, MealName = "Veggie Pasta" };
        var meal2 = new Meal { MealID = 2, MealName = "Vegetable Stir Fry" };

        // Act - Simulate relationships
        var junction1 = new MealTagJunction { Meal = meal1, MealTag = tag };
        var junction2 = new MealTagJunction { Meal = meal2, MealTag = tag };

        // Assert (simplified - in real scenario you'd check from tag side)
        Assert.Equal(tag, junction1.MealTag);
        Assert.Equal(tag, junction2.MealTag);
    }
}