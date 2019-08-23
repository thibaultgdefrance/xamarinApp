using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterCodeMobile.Models;

namespace MasterCodeMobile.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;
        List<Categorie> categories;
        List<Forum> forums;
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



        public async Task<IEnumerable<Forum>> GetForumsAsync(bool forceRefresh = false)
        {
            forums = new List<Forum>();

            var listeForum = new List<Forum>
            {
                new Forum {Id = Guid.NewGuid().ToString(),Sujet="C#"},
                new Forum {Id = Guid.NewGuid().ToString(),Sujet="Java"},
                new Forum {Id = Guid.NewGuid().ToString(),Sujet="C++"},
            };

            foreach (var item in listeForum)
            {
                forums.Add(item);
            }
            return await Task.FromResult(forums);
        }
        public async Task<Forum> GetForumAsync(string id)
        {
            return await Task.FromResult(forums.FirstOrDefault(s => s.Id == id));
        }

    }
}