﻿using System;
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
        //ItemsViewModel model = new ItemsViewModel();

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
        
        }

        async void Cancel_Clicked(object sender, EventArgs eventArgs)
        {
            var action = await DisplayAlert(
                "Cancel option",
                "Do you want to Quit?",
                "Yes", "NO");
            if (action)
            {
                await Navigation.PopToRootAsync();
            }
        }

        async void Save_Clicked(object sender, EventArgs eventArgs)
        {
            MessagingCenter.Send(this, "SaveNote", viewModel.Note);
            await Navigation.PopToRootAsync();
            
        }
    }
}