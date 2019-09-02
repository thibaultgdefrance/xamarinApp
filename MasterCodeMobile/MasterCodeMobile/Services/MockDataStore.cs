using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Cryptage2;
using MasterCodeMobile.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MasterCodeMobile.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;
        List<Categorie> categories;
        List<Forum> forums;
        ClefDeCryptage2 clef = new ClefDeCryptage2();
        HttpClient htc = new HttpClient();
        //List<Commentaire> commentaires; 
        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<Categorie>> GetCategoriesAsync(bool forceRefresh = false)
        {
            categories = new List<Categorie>();

            var listeCategorie = new List<Categorie>
            {
                new Categorie {Id = Guid.NewGuid().ToString(),LibelleCategorie="C#"},
                new Categorie {Id = Guid.NewGuid().ToString(),LibelleCategorie="Java"},
                new Categorie {Id = Guid.NewGuid().ToString(),LibelleCategorie="C++"},
            };

            foreach (var item in listeCategorie)
            {
                categories.Add(item);
            }
            return await Task.FromResult(categories);
        }


        /*public async void Connexion(string email,string motDePasse)
        {
            string token = clef.create();
            
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetStringAsync("http://api.forum.reseaudentreprise.com/api/Utilisateurs?token="+token+"&Email="+email+"&mdp="+motDePasse+"");

            


        }*/


        public async Task<Categorie> GetCategorieAsync(string id )
        {

            return await Task.FromResult(categories.FirstOrDefault(s=>s.Id==id));
        }



        /*public async Task<IEnumerable<Forum>> GetForumsAsync(bool forceRefresh = false)
        {
            
            forums = new List<Forum>();
            HttpClient htc = new HttpClient();
            var token = clef.create();
            string reponse = await htc.GetStringAsync("http://api.forum.reseaudentreprise.com/api/Fora");
            string[] result =  reponse.Split(',');

            

            foreach (var item in result)
            {

                Forum forum = new Forum();
                if (item.ToString()!= null)
                {
                    string sujet=item.Replace("Sujet:", "");
                    forum.Sujet = sujet;
                    forums.Add(forum);
                }
            }
            return await Task.FromResult(forums);
        }*/
        public async Task<IEnumerable<Forum>> GetForumsAsync(bool forceRefresh = false)
        {
            
            //string reponse = await htc.GetStringAsync("http://api.forum.reseaudentreprise.com/api/Fora");
            string reponse = await htc.GetStringAsync("http://10.115.145.48/api/forums");
            Forum forum = new Forum();
            List<Forum> forums = JsonConvert.DeserializeObject<List<Forum>>(reponse);
            
            return await Task.FromResult(forums);
        }
        /*public async Task<IEnumerable<Forum>> GetDetailsAsync(bool forceRefresh = false)
        {
          commentaire = new List<Commentaire>
        }*/
        public async Task<Forum> GetForumAsync(string id)
        {
            return await Task.FromResult(forums.FirstOrDefault(s => s.Id == id));
        }
        public async Task<bool> Login(Utilisateur utilisateur,bool forcedRefresh = false)
        {
            string email = utilisateur.Email;
            string pass = utilisateur.MotDePasse;
            try
            {
                /*SHA256 sha256Hash = SHA256.Create();
               
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));


                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }*/


                string token = clef.create();
                


                /*pass = builder.ToString();*/
                
                HttpClient htc = new HttpClient();
                var ConnexionReponse = await htc.GetStringAsync("http://10.115.145.48/api/Utilisateurs?token="+token+"&pseudo="+email+"&mdp="+pass+"");
                if (ConnexionReponse.Contains("404"))
                {
                    Application.Current.Properties["Email"] = "Le mot de passe ou l'email sont éronés";
                }
                else
                {
                    Application.Current.Properties["Email"]=email;
                }

            }
            catch (Exception)
            {


            }
            return await Task.FromResult(true);
        }


        public async void GetForumsAsync()
        {
            List<Forum> forums;
            HttpClient htc = new HttpClient();
            try
            {
                var ConnexionReponse = await htc.GetStringAsync("http://api.forum.reseaudentreprise.com/api/Fora");
            }               
            catch (Exception)
            {
              
            }
            

        }
    }
}