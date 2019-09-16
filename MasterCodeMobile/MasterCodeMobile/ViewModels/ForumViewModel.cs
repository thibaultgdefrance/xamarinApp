using MasterCodeMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterCodeMobile.ViewModels
{
    class ForumViewModel:BaseViewModel
    {
        public ObservableCollection<Forum> Forums { get; set; }
        public Command LoadForumsCommand { get; set; }

        public  ForumViewModel()
        {
            Title = "Liste des forums";
            Forums = new ObservableCollection<Forum>();
            LoadForumsCommand = new Command(async () => await ExecuteLoadForumsCommand());

            /*MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });*/
            
        }

        async Task ExecuteLoadForumsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Forums.Clear();
                var forums = await DataStore.GetForumsAsync();
                
                
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
        }
    }
}
