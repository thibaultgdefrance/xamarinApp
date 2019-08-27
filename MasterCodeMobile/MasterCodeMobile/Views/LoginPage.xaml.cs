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
        string pseudo = "titi";
        string mdp="admin";
        public LoginPage()
        {
            InitializeComponent();





        }
        public void Connexion_Clicked(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            if (pseudo == PseudoConnexion.Text && mdp==MDPConnexion.Text)
            {
                Navigation.PushAsync(new ListeForumsPage());
            }
            else
            {
                    
            }
                
            
            

        }
        public void Redirect_Clicked(object sender, EventArgs e)
        {
             Navigation.PushAsync(new InscriptionPage());
        }
        


    }
}