using MasterCodeMobile.Models;
using MasterCodeMobile.Services;
using MasterCodeMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace MasterCodeMobile.ViewModels
{
    public class ProfilViewModel : BaseViewModel
    {
        Utilisateur utilisateur = new Utilisateur();

        public Command LoadProfilCommand { get; set; }
        public ProfilViewModel()
        {
            /*MessagingCenter.Subscribe<ProfilPage, Utilisateur>(this, "Profil", async (obj, item) =>
            {

            });*/
            LoadProfilCommand = new Command(async () => await ExecuteLoadProfilCommand());
           

        }
        public async Task ExecuteLoadProfilCommand()
        {
            Application.Current.Properties["IdUtilisateur"] = "1";
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {

                var profil = new Utilisateur();
                
                profil = await DataStore.GetProfil(Application.Current.Properties["IdUtilisateur"].ToString());


                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        
        }



        

    }
    

