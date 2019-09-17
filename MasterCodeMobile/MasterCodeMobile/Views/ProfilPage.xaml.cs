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
       Utilisateur utilisateur { get; set; }
        
        public ProfilPage()
        {
            Utilisateur _Utilisateur= Application.Current.Properties["utilisateur"] as Utilisateur;
            InitializeComponent();
            // BindingContex = viewModel = new ProfilViewModel();
            utilisateur = _Utilisateur;
            ImageUtilisateur.Source = utilisateur.CheminAvatar;


        }
        public void ModifierProfilAsync(Object sender,EventArgs e)
        {
            Utilisateur utilisateur = Application.Current.Properties["utilisateur"] as Utilisateur;
            utilisateur.CheminAvatar = CheminAvatar.Text;
            utilisateur.Pseudo = Pseudo.Text;
            utilisateur.MotDePasse = MDP.Text;
            MessagingCenter.Send(this, "ModifierProfil", utilisateur);
        }
        protected override void OnAppearing()
        {
           
            

            Pseudo.Text = utilisateur.Pseudo;
            MDP.Text = utilisateur.MotDePasse;
            
            /*if (utilisateur.CheminAvatar=="default")
            {
                CheminAvatar.Text = "iconeutilisateur.jpg";
                ImageUtilisateur.Source = "iconeutilisateur.jpg";
            }
            else
            {
                CheminAvatar.Text =  utilisateur.CheminAvatar;
                ImageUtilisateur.Source = utilisateur.CheminAvatar;
            }*/

            //PseudoUtilisateur.Text = utilisateur.Pseudo;
            //MotDePasseUtilisateur.Text = utilisateur.MotDePasse;
            /*Utilisateur utilisateur = new Utilisateur();
          
            utilisateur.IdUtilisateur = "1";
            utilisateur.Email = "thibault.g.defrance@gmail.com";
            utilisateur.Nom = "Defrance";
            utilisateur.Prenom = "Thibault";
            utilisateur.Pseudo = "titi";
            utilisateur.MotDePasse = "admin";
            MessagingCenter.Send(this, "profil", utilisateur);*/
            //viewModel.LoadProfilCommand.Execute(null);

        }
       
    }
}