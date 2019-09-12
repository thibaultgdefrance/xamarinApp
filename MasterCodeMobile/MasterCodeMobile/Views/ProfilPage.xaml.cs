using MasterCodeMobile.Models;
using MasterCodeMobile.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public partial class ProfilPage : ContentPage
    {
        ProfilViewModel viewModel;
        public Utilisateur utilisateur = new Utilisateur();
        public ProfilPage()
        {
            InitializeComponent();
           // BindingContex = viewModel = new ProfilViewModel();
        }
        protected override void OnAppearing()
        {
            /*Utilisateur utilisateur = new Utilisateur();
          
            utilisateur.IdUtilisateur = "1";
            utilisateur.Email = "thibault.g.defrance@gmail.com";
            utilisateur.Nom = "Defrance";
            utilisateur.Prenom = "Thibault";
            utilisateur.Pseudo = "titi";
            utilisateur.MotDePasse = "admin";
            MessagingCenter.Send(this, "profil", utilisateur);*/
            viewModel.LoadProfilCommand.Execute(null);
            
        }
       
    }
}