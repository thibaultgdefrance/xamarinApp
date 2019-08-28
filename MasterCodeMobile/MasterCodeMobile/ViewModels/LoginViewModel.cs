using MasterCodeMobile.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterCodeMobile.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        public async Task<bool> LoginUtilisateur(Utilisateur utilisateur,bool forceRefresh = false)
        {
            string login = utilisateur.Email;
            string motdepasse = utilisateur.MotDePasse;
            HttpClient htc= new HttpClient();

            try
            {
                var ApiResponse = await htc.GetStringAsync("http://api.forum.reseaudentreprise.com/api/Utilisateurs?Email="+login+"&mdp="+motdepasse+"");
                if (ApiResponse.Contains("IdUtilisateur"))
                {
                    Application.Current.Properties["login"] = login;
                    Application.Current.Properties["motdepasse"] = motdepasse;
                }
            }catch(Exception)
            {

            }
            return await Task.FromResult(true);
        }
        
    }
}
