using System;
using System.Collections.Generic;
using NoteKeeper.Models;

namespace NoteKeeper.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {

        public Note Note { get; set; }
        public IList<String> CourseList { get; set; }

        public String NoteHeading
        {
            get { return Note.Heading; }
            set
            {
                Note.Heading = value;
                OnPropertyChanged();
            }
        }

        public ItemDetailViewModel(Note note = null)
        {
<<<<<<< HEAD
            Title = "Edit Note";
            InitializeCourselist();
            Note = Note ?? new Note();
=======
            Title = "Edit note";
            InitializeCourselist();
            Note = note ?? new Note();
>>>>>>> 4fac0aa61d42ae71016e4e6269333b8c5a1ef0fb
        }

        async void InitializeCourselist()
        {
            CourseList = await PluralsightDataStore.GetCoursesAsync();
        }
    }
}
 