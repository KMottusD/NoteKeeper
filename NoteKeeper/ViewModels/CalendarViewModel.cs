﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NoteKeeper.Views;

using Xamarin.Forms;

namespace NoteKeeper.ViewModels
{
    public class CalendarViewModel : BindableObject
    {
        private DateTime? _date;
        public DateTime? Date
        {
            get
            {
                return _date;
            }
            set
            {

                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private ObservableCollection<XamForms.Controls.SpecialDate> attendances;
        public ObservableCollection<XamForms.Controls.SpecialDate> Attendances
        {
            get
            {
                return attendances;
            }
            set
            {
                attendances = value;
                OnPropertyChanged(nameof(Attendances));
            }
        }

        public Command DateChosen
        {
            get
            {
                return new Command((obj) =>
                {
                    System.Diagnostics.Debug.WriteLine(obj as DateTime?);
                });
            }
        }
    }
}