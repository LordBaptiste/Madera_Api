using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class Client
    {
        public Client()
        {
            Projet = new HashSet<Projet>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public int Telephone { get; set; }
        public string CodePostal { get; set; }

        public ICollection<Projet> Projet { get; set; }
    }
}
