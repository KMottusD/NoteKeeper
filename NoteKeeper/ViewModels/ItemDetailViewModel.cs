﻿using System;
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
            Title = "Edit Note";
            InitializeCourselist();
            Note = note ?? new Note();
        }

        async void InitializeCourselist()
        {
            CourseList = await PluralsightDataStore.GetCoursesAsync();
        }
    }
}
 