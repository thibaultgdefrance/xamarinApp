using System;
using System.Collections.Generic;
using System.Text;

namespace MasterCodeMobile.Models
{
    public class Message
    {
        public string Id { get; set; }
        public string IdMessage { get; set; }
        public string IdMessageParent { get; set; }
        public string IdForum { get; set; }
        public string Texte { get; set; }
        public string Popularite { get; set; }
        public string IdStatut { get; set; }
        public string IdAuteur{ get; set; }
        public string DatePublication { get; set; }
    }
}
