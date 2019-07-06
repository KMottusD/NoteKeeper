using System;
using System.Collections.Generic;
using NoteKeeper.Models;

namespace NoteKeeper.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Note Note { get; set; }
        public IList<String> CourseList { get; set; }

        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            InitializeCourselist();
            Note = new Note
            {
                Heading = "Test note",
                Text = "Text for note in ViewModel",
                Course = CourseList[0]
            };
        }

        async void InitializeCourselist()
        {
            CourseList = await PluralsightDataStore.GetCoursesAsync();
        }
    }
}
 