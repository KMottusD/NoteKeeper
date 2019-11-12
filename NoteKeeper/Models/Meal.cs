using System;

namespace NoteKeeper.Models
{
    public class Meal
    {
        string mealId { get; set; }
        string mealName { get; set; }
        string mealDescription { get; set; }
        MealItem[] meals { get; set; }
    }
}