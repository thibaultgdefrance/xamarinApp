﻿using MasterCodeMobile.Models;
using MasterCodeMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterCodeMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeForumsPage : ContentPage
    {
        ForumViewModel viewModel;
        public ListeForumsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ForumViewModel();
        }
        async public void GetForumDetailAsync(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Forum;
            if (item == null)
                return;

            await Navigation.PushAsync(new ForumDetailPage(new ForumDetailViewModels(item)));

           
          


        }
        public async void goProfil(object sender,EventArgs e)
        {
            await Navigation.PushAsync(new ProfilPage());
        }
        protected override void OnAppearing()
        {
            
         //   base.OnAppearing();

            //await Navigation.PushAsync(new ForumDetailPage());
            if (viewModel.Forums.Count == 0)
                viewModel.LoadForumsCommand.Execute(null);
            
            Utilisateur utilisateur = Application.Current.Properties["utilisateur"] as Utilisateur;
            lbtest.Text ="Bonjour "+utilisateur.Pseudo;
            imgAvatar.Source =utilisateur.CheminAvatar;
        }

        
    }
}