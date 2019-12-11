using System;
namespace NoteKeeper.Models
{
    public class MealItem : IMealItem
    {
        public string MealItemName { get; set; }
        public int MealItemId { get; set; }
        public Nutrient[] NutrientsList { get; set; }
    }
}
