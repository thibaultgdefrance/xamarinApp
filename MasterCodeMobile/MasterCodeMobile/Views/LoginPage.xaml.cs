using Cryptage2;
using MasterCodeMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterCodeMobile.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class LoginPage : ContentPage
    {
        public Utilisateur Utilisateur { get; set; }
       
        ClefDeCryptage2 clef = new ClefDeCryptage2();
        public LoginPage()
        {
            InitializeComponent();

            Utilisateur = new Utilisateur {
                Email="toto",
                MotDePasse = ""
            };
            BindingContext = this;



        }
        public void Connexion_Clicked(object sender, EventArgs e)
        {
           
            MessagingCenter.Send(this, "Connexion", Utilisateur);

            if (Application.Current.Properties.ContainsKey("Email"))
            {
                infoConnexion.Text = Application.Current.Properties["Email"].ToString();
                Navigation.PushAsync(new ListeForumsPage());
            }
            else
            {
                infoConnexion.Text = "Le mot de passe ou l'email sont éronés";
            }
           
        }
        public void Redirect_Clicked(object sender, EventArgs e)
        {
             Navigation.PushAsync(new InscriptionPage());
        }
        


    }
}