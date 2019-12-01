using System;
namespace NoteKeeper.Models
{
    public class MealItem
    {

        string MealItemName { get; set; }
        int MealItemId { get; set; }
        Nutrient[] NutrientsList { get; set; }
    }
}
