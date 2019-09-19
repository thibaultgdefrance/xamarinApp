﻿using MasterCodeMobile.Models;
using MasterCodeMobile.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterCodeMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForumDetailPage : ContentPage
    {
        HttpClient htc = new HttpClient();
        Forum Forum { get; set; }
        //Message message { get; set; }

        ForumDetailViewModels viewModels;
        public ForumDetailPage()
        {
            InitializeComponent();
            Forum = new Forum();
            
            List<Message> messages = new List<Message>();
            List<MessageForum> messagesForum = new List<MessageForum>();
        }

        

        public void supMessage(Object sender, EventArgs e)
        {
            MessageForum message = new MessageForum();
            Button bt = sender as Button;
            string idmessage = bt.ClassId;
            message.IdMessage = idmessage;
            MessagingCenter.Send(this, "sup", idmessage);
            Navigation.PushAsync(new ListeForumsPage());
        }
        public ForumDetailPage(ForumDetailViewModels viewModel)
        {

            InitializeComponent();
            Forum = new Forum();
            BindingContext = this.viewModels = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModels.LoadMessagesCommand.Execute(null);
            
            

          
        }
        
        public void PostMessagesAsync(Object sender ,EventArgs e)
        {
            Utilisateur utilisateur = Application.Current.Properties["utilisateur"] as Utilisateur;
            Message message = new Message();
            message.Texte = commentaire.Text;
            message.IdAuteur = utilisateur.IdUtilisateur;
            message.IdForum = Application.Current.Properties["IdForum"].ToString();
            message.DatePublication = DateTime.Now.ToLongDateString();
            message.IdMessageParent = null;
            message.IdStatut = "1";

            //message.Id = Guid.NewGuid().ToString();
            if (commentaire.Text != null)
            {
                MessagingCenter.Send(this, "Ajout", message);

         
                commentaire.Placeholder = "Commentaire ajouté";
                commentaire.PlaceholderColor = Color.LimeGreen;
                commentaire.Text = "";
            }
            else
            {
                commentaire.PlaceholderColor = Color.Red;
                commentaire.Placeholder = "Le Commentaire doit etre valide";
            }


        }
    }
}