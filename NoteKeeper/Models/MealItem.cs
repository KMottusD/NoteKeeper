using System;
namespace NoteKeeper.Models
{
    public class MealItem
    {

        string mealItemName { get; set; }
        int mealItemId { get; set; }
        Nutrient[] nutrientsList { get; set; }
    }
}
