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
            //chargement2.ProgressTo(1, 9000, Easing.Linear);
            
            Utilisateur = new Utilisateur {
                Email="",
                MotDePasse = ""
            };
            BindingContext = this;



        }
        public void Connexion_Clicked(object sender, EventArgs e)
        {
           
            MessagingCenter.Send(this, "Connexion", Utilisateur);

            if (Application.Current.Properties.ContainsKey("utilisateur"))
            {
                
                Navigation.PushAsync(new ListeForumsPage());
            }
            else
            {
                //infoConnexion.Text = "Le mot de passe ou l'email sont éronés";
            }
            


        }
        public void Redirect_Clicked(object sender, EventArgs e)
        {
             Navigation.PushAsync(new InscriptionPage());
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Application.Current.Properties.ContainsKey("utilisateur"))
            {

                await Navigation.PushAsync(new ListeForumsPage());
            }
            /*var chargement = new ProgressBar {
                Progress = 0.1,
                ProgressColor = Color.LimeGreen,
                WidthRequest = 300,
                HeightRequest = 20
            };
            await chargement.ProgressTo(1, 9000, Easing.Linear);
            await chargement2.ProgressTo(1 , 9000, Easing.Linear);
            if (EmailConnexion.Text!="")
            {
                chargement2.Progress += 0.5;
            }
            else
            {
                chargement2.Progress -= 0.5;
            }
            if (MDPConnexion.Text != "")
            {
                chargement2.Progress += 0.5;
            }
            else
            {
                chargement2.Progress -= 0.5;
            }*/

        }

    }
}