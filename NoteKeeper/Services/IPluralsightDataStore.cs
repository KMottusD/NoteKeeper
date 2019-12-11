using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteKeeper.Models;


namespace NoteKeeper.Services
{
    public interface IPluralsightDataStore
    {
        Task<String> AddNoteAsync(Note courseNote);
        Task<String> AddMealAsync(Meal mealsItem);
        Task<bool> UpdateNoteAsync(Note courseNote);
        Task<bool> UpdateMealAsync(Meal mealsItem);
        Task<Note> GetNoteAsync(String id);
        Task<IList<Note>> GetNotesAsync();
        Task<IList<String>> GetCoursesAsync();
        Task<IList<String>> GetMealsAsync();
    }
}
