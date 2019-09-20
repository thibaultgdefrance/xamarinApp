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
        Task<Utilisateur> Login(Utilisateur utilisateur, bool forcedRefresh = false);

        Task<IEnumerable<MessageForum>> GetForumDetailAsync(string idforum, bool forcedRefresh = false);

        Task<Message> PostMessageAsync(Message message, string token);

        Task<Utilisateur> GetProfil(string IdUtilisateur);
        Task<bool> UpdateProfil(string pseudo, string mdp, string cheminavatar);

        Task<bool> SupMessageAsync(string idMessage);
        
    }
}
