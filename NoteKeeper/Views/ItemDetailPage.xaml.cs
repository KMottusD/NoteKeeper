using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoteKeeper.Models;
using NoteKeeper.ViewModels;
using System.Collections.Generic;
using NoteKeeper.Services;

namespace NoteKeeper.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            BindingContext = this.viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            viewModel = new ItemDetailViewModel();
            BindingContext = viewModel;
        }

        public void Cancel_Clicked(object sender, EventArgs eventArgs)
        {
            Navigation.PopModalAsync();
            viewModel.NoteHeading = "XXXXXXX";
            DisplayAlert(
                "Cancel option",
                "Heading value is " + viewModel.Note.Heading,
                "Yes", "NO");
        }

        public void Save_Clicked(object sender, EventArgs eventArgs)
        {
            //DisplayAlert("Save option", "Save was selected", "Save", "Cancel");
            MessagingCenter.Send(this, "SaveNote", viewModel.Note);
            Navigation.PopModalAsync();
            
        }
    }
}