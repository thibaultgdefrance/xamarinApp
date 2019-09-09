using Cryptage;
using Cryptage2;
using MasterCodeMobile.Models;
using MasterCodeMobile.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterCodeMobile.ViewModels
{
    public class ForumDetailViewModels:BaseViewModel
    {
        HttpClient htc = new HttpClient();
        public ObservableCollection<Message> Messages { get; set; }
        public ObservableCollection<MessageForum> MessagesForum { get; set; }
        public Forum Forum { get; set; }
        public Command LoadMessagesCommand { get; set; }
        public ObservableCollection<Message> messages { get; set; }
        public ObservableCollection<MessageForum> messagesForum { get; set; }
        public Message message { get; set; }

        public ClefDeCryptage2 clef = new ClefDeCryptage2();

        public Utilisateur Utilisateur { get; set; }
        
        public ForumDetailViewModels(Forum forum = null)
        {
            Forum = forum;
            messages = new ObservableCollection<Message>();
            messagesForum = new ObservableCollection<MessageForum>();
            LoadMessagesCommand = new Command(async () => await ExecuteLoadMessagesCommand());
            //ExecuteLoadForumsCommand = new Command(async () => await ExecuteLoadForumCommand());
        }
        async Task ExecuteLoadMessagesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                messagesForum.Clear();
                var msg = await DataStore.GetForumDetailAsync(Forum.IdForum,false);
                foreach (MessageForum item in msg)
                {
                    messagesForum.Add(item);
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

        /* async Task ExecuteLoadForumCommand()
         {
             if (IsBusy)
                 return;

             IsBusy = true;

             try
             {
                 Forum.Clear();
                 var forums = await DataStore.GetForumAsync(true);


                 foreach (var forum in forums)
                 {
                     Forums.Add(forum);
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
         }*/


        /*public void posterMessage()
        {
            MessagingCenter.Subscribe<ForumDetailPage, Message>(this, "Ajout", async ( obj, item) =>
                    {
                        string token = clef.create();
                        var _message = item as Message;
                        message.IdForum = Forum.IdForum;
                        Utilisateur.IdUtilisateur = Application.Current.Properties["IdUtilisateur"].ToString();
                        //message.IdForum = "1";
                        //Utilisateur.IdUtilisateur = "1";
                        message.IdAuteur = Utilisateur.IdUtilisateur; 
                        message = _message;
                        messages.Add(message);
                        await DataStore.PostMessageAsync(message, token);
                    });
        }*/
        

        }
    }
