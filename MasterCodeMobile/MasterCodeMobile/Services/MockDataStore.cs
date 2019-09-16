using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public List<Message> messages;
        List<MessageForum> messagesForum;
        public List<Forum> forums;
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
        public  async Task<IEnumerable<MessageForum>> GetForumDetailAsync(string idforum, bool forcedRefresh = false)
        {
            
            HttpClient htcT = new HttpClient();
            string idf = idforum.Replace("\"", "");
            Application.Current.Properties["IdForum"] = idforum;
            //string req = "http://10.115.145.48/api/Messages?idForum="+idf;
            string req = "http://10.115.145.48/api/Messages?IdForum=" + idf + "&sandwich=" + true;
            var reponse = await htcT.GetStringAsync(req);


            messagesForum = JsonConvert.DeserializeObject<List<MessageForum>>(reponse);
            

          

            return messagesForum.AsEnumerable();
        }

        public async Task<IEnumerable<Forum>> GetForumsAsync(bool forceRefresh = false)
        {
            
            //string reponse = await htc.GetStringAsync("http://api.forum.reseaudentreprise.com/api/Fora");
            string reponse = await htc.GetStringAsync("http://10.115.145.48/api/Forums");
            Forum forum = new Forum();
            List<Forum> forums = JsonConvert.DeserializeObject<List<Forum>>(reponse);
            
            return await Task.FromResult(forums);
        }
        /*public async Task<IEnumerable<Forum>> GetForumDetailsAsync(bool forceRefresh = false)
        {
          
        }*/
        public async Task<Forum> GetForumAsync(string id)
        {
            return await Task.FromResult(forums.FirstOrDefault(s => s.Id == id));
        }
        public async Task<Utilisateur> Login(Utilisateur utilisateur,bool forcedRefresh = false)
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
                var ConnexionReponse = await htc.GetStringAsync("http://10.115.145.48/api/Utilisateurs?Email="+email+"&MDP="+pass+"&clafouti=true");
                if (ConnexionReponse=="null")
                {
                    Application.Current.Properties.Remove("utilisateur");
                }
                else
                {
                    utilisateur = JsonConvert.DeserializeObject<Utilisateur>(ConnexionReponse);
                    Application.Current.Properties["utilisateur"] = utilisateur as Utilisateur;
                    return await Task.FromResult(utilisateur);
                }

            }
            catch (Exception)
            {
              
            }
            return null;
        }


        public async Task<List<Forum>> GetForumsAsync()
        {
            
            HttpClient htc = new HttpClient();
            try
            {
                var ConnexionReponse = await htc.GetStringAsync("http://10.115.145.48/api/Forums");
                var obj = JsonConvert.DeserializeObject<List<Forum>>(ConnexionReponse);
                return obj;
            }               
            catch (Exception)
            {
              return null;
            }
            

        }

        public async Task<Message> PostMessageAsync(Message message, string token)
        {
           //Message message2 = new Message();
            //token = clef.create();
            //message.Id= Guid.NewGuid().ToString();
            /*message.IdAuteur = IdAuteur;
            message.IdForum = IdForum;
            message.Texte = Texte;*/
            //string IdAuteur = "1";//Application.Current.Properties["IdAuteur"].ToString();
            //string IdForum = message.IdForum ;
            //string Texte = message.Texte;
            /*message2.Id = Guid.NewGuid().ToString();
            message2.IdForum = "1";
            message2.IdMessage="";
            message2.IdMessageParent = "1";
            message2.IdStatut = "1";
            message2.Popularite = "1";
            message2.Texte = "ioiioiioioioii";
            var contenu2 = new StringContent(JsonConvert.SerializeObject(message2));*/
            
            /*message.IdStatut = "1";
            message.Popularite = "0";
            message.IdMessageParent = null;
            message.DatePublication = (DateTime.Now).ToLongDateString();*/
            HttpClient htc = new HttpClient();
            var json = JsonConvert.SerializeObject(message);
            var contenu = new StringContent(json,Encoding.UTF8, "application/json");
            //contenu.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //HttpResponseMessage reponse= await htc.PostAsync("http://10.115.145.48/api/Messages?token="+token+"&IdForumSelectionne="+message.IdForum+"&idAuteur="+message.IdAuteur+"&texteMessage="+message.Texte,contenu);


            HttpResponseMessage reponse = await htc.PostAsync("http://10.115.145.48/api/Messages",contenu);

           

            return await Task.FromResult(message);
        }

        public async Task<Utilisateur> GetProfil(string idUtilisateur)
        {

            Utilisateur utilisateur = new Utilisateur();
            try
            {
                var reponse = await htc.GetStringAsync("http://10.115.145.48/api/Utilisateurs?idUtilisateur=" + idUtilisateur + "&clafouti=" + true);
                utilisateur= JsonConvert.DeserializeObject<Utilisateur>(reponse);
                
            }
            catch (Exception)
            {

                throw;
            }

            return await Task.FromResult(utilisateur);
        }
        async public Task<bool> UpdateProfil(string pseudo,string mdp,string cheminavatar)
        {
            
            Utilisateur utilisateur = Application.Current.Properties["utilisateur"] as Utilisateur;
            utilisateur.Pseudo = pseudo;
            utilisateur.MotDePasse = mdp;
            utilisateur.CheminAvatar = cheminavatar;
            var json = JsonConvert.SerializeObject(utilisateur);
            var contenu = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage rep = await htc.PutAsync("http://10.115.145.48/api/Utilisateurs/"+utilisateur.IdUtilisateur+"?croquette=true",contenu);
            

            return true;
        }

    }
}