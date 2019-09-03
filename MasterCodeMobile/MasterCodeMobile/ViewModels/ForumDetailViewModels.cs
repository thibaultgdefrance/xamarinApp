using MasterCodeMobile.Models;
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
        public Forum Forum { get; set; }
        public Command LoadMessagesCommand { get; set; }
        public List<Message> messages { get; set; }
        
        public ForumDetailViewModels(Forum forum = null)
        {
            Forum = forum;
            Messages = new ObservableCollection<Message>();
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
                Messages.Clear();
                var msg = await DataStore.GetForumDetailAsync(Forum.IdForum,false);
                foreach (Message item in msg)
                {
                    Messages.Add(item);
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



    }
}
