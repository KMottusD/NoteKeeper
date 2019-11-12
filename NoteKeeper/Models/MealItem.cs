using System;
namespace NoteKeeper.Models
{
    public class MealItem
    {

        string MealItemName { get; set; }
        int Id { get; set; }
        Nutrient[] NutrientsList { get; set; }
    }
}
