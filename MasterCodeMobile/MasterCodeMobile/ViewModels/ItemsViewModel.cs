using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using MasterCodeMobile.Models;
using MasterCodeMobile.Views;
using System.Collections.Generic;
using Cryptage2;

namespace MasterCodeMobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Utilisateur Utilisateur;
        public List<Forum> Forums;
        public Forum Forum { get; set; }
        public Message message { get; set; }
        public Utilisateur utilisateur { get; set; }
        public List<Message> messages { get; set; }
        public ClefDeCryptage2 clef = new ClefDeCryptage2();

        public ItemsViewModel()
        
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            
            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
            MessagingCenter.Subscribe<LoginPage, Utilisateur>(this, "Connexion", async (obj, user) =>
            {
                var _User = user as Utilisateur;
                Utilisateur = _User;
                await DataStore.Login(_User);
            });


            MessagingCenter.Subscribe<ForumDetailPage, Message>(this, "Ajout", async (obj, item) =>
            {
                string token = clef.create();
                var _message = item as Message;
                message = _message;
                //Utilisateur.IdUtilisateur = Application.Current.Properties["IdUtilisateur"].ToString();
                //message.IdForum = "1";



                await DataStore.PostMessageAsync(message, token);
                //messages.Add(message);
            });

            MessagingCenter.Subscribe<ProfilPage, Utilisateur>(this, "ModifierProfil", async (obj, item) =>
              {
                  
                  var _utilisateur = item as Utilisateur;
                  utilisateur = _utilisateur;
                  await DataStore.UpdateProfil(utilisateur.Pseudo,utilisateur.MotDePasse,utilisateur.CheminAvatar);
              }


            );
            
        }



        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
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