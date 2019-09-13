using System;
using System.Collections.Generic;
using System.Text;

namespace MasterCodeMobile.Models
{
    public class Utilisateur
    {
        public string Id { get; set; }
        public string IdUtilisateur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public string CheminAvatar { get; set; }
        public string IdStatut { get; set; }
        public string IdLangue { get; set; }
        public string IdAcces { get; set; }
        public string Popularite{ get; set; }
        public string IdTrophee { get; set; }
        public string DateCreation { get; set; }
 
    }
}
