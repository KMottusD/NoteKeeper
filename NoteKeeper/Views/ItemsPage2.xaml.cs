using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NoteKeeper.Models;
using NoteKeeper.Views;
using NoteKeeper.ViewModels;

namespace NoteKeeper.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage2 : ContentPage
    {
        ItemsViewModel viewModel2;

        public ItemsPage2()
        {
            InitializeComponent();

            BindingContext = viewModel2 = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var note = args.SelectedItem as Note;
            if (note == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(note)));

            // Manually deselect item.
           ItemsListView2.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
             Note note = new Note();
            if (note == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(note)));

            // Manually deselect item.
            ItemsListView2.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel2.Notes.Count == 0)
                viewModel2.LoadItemsCommand.Execute(null);
        }
    }
}