using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Enums
{
    public enum DietaryCategory
    {
        // Allergens
        GlutenFree,
        NutFree,
        DairyFree,
        EggFree,
        SoyFree,
        ShellfishFree,

        // Dietary Preferences
        Vegetarian,
        Vegan,
        Pescatarian,

        // Medical/Restrictive
        LowSodium,
        LowCarb,
        KetoFriendly,
        DiabeticFriendly,
        HeartHealthy,

        // Lifestyle
        Organic,
        NonGMO,
        LocallySourced,
        Sustainable,

        // Religious/Cultural
        Halal,
        Kosher,

        // Other
        Spicy,
        Mild,
        KidFriendly
    }

}
