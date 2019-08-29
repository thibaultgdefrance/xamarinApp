using MasterCodeMobile.Models;
using MasterCodeMobile.Views;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MasterCodeMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        Utilisateur Utilisateur { get; set; }
        public LoginViewModel(){
                Utilisateur = new Utilisateur {
                Email = "",
                MotDePasse = ""

            };

            MessagingCenter.Subscribe<LoginPage, Utilisateur>(this, "Connexion", async (obj, user) =>
                   {
                       var _User = user as Utilisateur;
                       Utilisateur = _User;
                       await DataStore.Login(_User);
                   }

            );
           
        }
        public ICommand OpenWebCommand { get; }
       

    }
}
