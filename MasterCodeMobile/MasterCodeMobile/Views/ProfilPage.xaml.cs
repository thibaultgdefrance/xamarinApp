using MasterCodeMobile.Models;
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
        public Utilisateur utilisateur = new Utilisateur();
        public ProfilPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            MessagingCenter.Send(this, "profil", utilisateur);


        }

    }
}