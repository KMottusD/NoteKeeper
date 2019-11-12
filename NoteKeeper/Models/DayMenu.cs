using System;
namespace NoteKeeper.Models
{
    public class DayMenu

    {
        string menuName { get; set; }
        int menuID { get; set; }
        Meal[] meals { get; set; }
    }
}
