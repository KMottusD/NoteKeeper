using System;
using System.Collections.Generic;
using NoteKeeper.Models;
using NoteKeeper.ViewModels;

using Xamarin.Forms;

namespace NoteKeeper.Views
{
    public partial class CalendarPage : ContentPage
    {
        ItemsViewModel viewModel;
        public CalendarPage()
        {
            InitializeComponent();

        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var note = args.SelectedItem as Note;
            if (note == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(note)));

            // Manually deselect item.
            //ItemsListView.SelectedItem = null;
        }
    }
}
