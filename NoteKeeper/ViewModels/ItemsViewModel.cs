using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

using NoteKeeper.Models;
using NoteKeeper.Views;

namespace NoteKeeper.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Note> Notes { get; set; }
        public ObservableCollection<Meal> Meals { get; set; }
        public Command LoadItemsCommand { get; set; }
        public List<string> NoteIds { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Notes = new ObservableCollection<Note>();
            Meals = new ObservableCollection<Meal>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<ItemDetailPage, Note>(this, "SaveNote", async (sender, note) => 
            {

            if (note.Id > 0)
                {
                    await PluralsightDataStore.UpdateNoteAsync(note);
                }
                else
                {
                    Notes.Add(note);
                    await PluralsightDataStore.AddNoteAsync(note);
                }
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                Notes.Clear();
                Meals.Clear();
                var notes = await PluralsightDataStore.GetNotesAsync();
                var meals = await PluralsightDataStore.GetMealsAsync();
                foreach (var note in notes)
                {
                    Notes.Add(note);
                }
                foreach (var meal in meals)
                {
                    Meals.Add(meal);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}