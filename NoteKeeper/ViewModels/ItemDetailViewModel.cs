using System;
using System.Collections.Generic;
using NoteKeeper.Models;

namespace NoteKeeper.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {

        public Note Note { get; set; }
        public IList<String> CourseList { get; set; }
        public IList<String> MealList { get; set; }
        public Meal Meal { get; set; }


        // See Sring NoteHeading - oleks vaja teha copy ja NoteCourse ja NoteText kohta samma moodi + ära muuta ItemDetailPage.xamal...
        // see annab meile selle, et kõik info oleks kogu aeg syncroniseeritud (Managing Data Presentation with Model-View-ViewModel -> Implementing Change Notifications)
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
            Title = "Edit Note";
            InitializeCourselist();
            Note = note ?? new Note();
        }

        async void InitializeCourselist()
        {
            CourseList = await PluralsightDataStore.GetCoursesAsync();
            MealList = await PluralsightDataStore.GetMealingsAsync();
        }
    }
}
