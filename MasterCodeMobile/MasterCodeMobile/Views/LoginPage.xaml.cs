using Cryptage2;
using MasterCodeMobile.Models;
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
    
    public partial class LoginPage : ContentPage
    {
        Utilisateur Utilisateur { get; set; }
        string pseudo = "titi";
        string mdp="admin";
        ClefDeCryptage2 clef = new ClefDeCryptage2();
        public LoginPage()
        {
            InitializeComponent();

            Utilisateur Utilisateur = new Utilisateur();
            BindingContext = this;



        }
        public async void Connexion_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "ConnectUtilisateur", Utilisateur);
            await Navigation.PushAsync(new ItemsPage(Utilisateur));
                

        }
        public void Redirect_Clicked(object sender, EventArgs e)
        {
             Navigation.PushAsync(new InscriptionPage());
        }
        


    }
}