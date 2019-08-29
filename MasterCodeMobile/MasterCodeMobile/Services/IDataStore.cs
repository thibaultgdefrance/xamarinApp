using MasterCodeMobile.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterCodeMobile.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);

        Task<IEnumerable<Categorie>> GetCategoriesAsync(bool forceRefresh = false);
        Task<Categorie> GetCategorieAsync(string id);

        Task<IEnumerable<Forum>> GetForumsAsync(bool forceRefresh = false);
        Task<Forum> GetForumAsync(string id);
        Task<bool> Login(Utilisateur utilisateur, bool forcedRefresh = false);
    }
}
