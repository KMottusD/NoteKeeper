using System;
namespace NoteKeeper.Models
{
    public interface IMealItem
    {
        string MealItemName { get; set; }
        int MealItemId { get; set; }
        Nutrient[] NutrientsList { get; set; }
    }
}
