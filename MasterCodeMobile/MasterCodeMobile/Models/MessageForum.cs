using System;
using System.Collections.Generic;
using System.Text;

namespace MasterCodeMobile.Models
{
    public class MessageForum
    {
        public string IdForum { get; set; }
        public string TitreForum { get; set; }
        public string PseudoUtilisateur { get; set; }
        public string DatePublication { get; set; }
        public string TexteMessage { get; set; }
    }
}
