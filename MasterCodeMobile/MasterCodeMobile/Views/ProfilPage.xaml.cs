using MasterCodeMobile.Models;
using MasterCodeMobile.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterCodeMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilPage : ContentPage
    {
        public MediaFile _mediaFile;
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

        public async void uploadAvatar(Object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No PickPhoto", " >:° No PickPhoto.", "Ok");
                return;
            }

            _mediaFile = await CrossMedia.Current.PickPhotoAsync();
            if (_mediaFile==null)
            {
                return;
            }
            LocalPathLabel.Text = _mediaFile.Path;
            ImageUtilisateur.Source = ImageSource.FromStream(() =>
              {
                  return _mediaFile.GetStream();
              }


            );
            uploadClicked();
        }



        public async void uploadClicked()
        {
            Utilisateur utilisateur = Application.Current.Properties["utilisateur"] as Utilisateur;
            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(_mediaFile.GetStream()),
                "\"file\"",
                $"\"{_mediaFile.Path}\""
                );
            var httpClient = new HttpClient();
            var uploadAdresse = "http://10.115.145.48/api/Files/Upload";
            var httpReponseMessage = await httpClient.PostAsync(uploadAdresse,content);
            RemotePathLabel.Text = await httpReponseMessage.Content.ReadAsStringAsync();
            //CheminAvatar.Text= await httpReponseMessage.Content.ReadAsStringAsync();
            CheminAvatar.Text = _mediaFile.Path;
        }


        protected override void OnAppearing()
        {
           
            

            Pseudo.Text = utilisateur.Pseudo;
            MDP.Text = utilisateur.MotDePasse;
            CheminAvatar.Text = utilisateur.CheminAvatar;
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