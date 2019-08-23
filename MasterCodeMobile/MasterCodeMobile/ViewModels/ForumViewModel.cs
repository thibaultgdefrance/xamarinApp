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
        public ObservableCollection<Forum> Categories { get; set; }
        public Command LoadCategoriesCommand { get; set; }

        public ForumViewModel()
        {
            Title = "Liste des Categories";
            Forums = new ObservableCollection<Forum>();
            LoadCategoriesCommand = new Forum(async () => await ExecuteLoadCategoriesCommand());

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
                Categories.Clear();
                var categories = await DataStore.GetCategoriesAsync(true);
                foreach (var categorie in categories)
                {
                    Categories.Add(forum);
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
