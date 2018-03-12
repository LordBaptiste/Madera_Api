using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class Projet
    {
        public Projet()
        {
            Devis = new HashSet<Devis>();
        }

        public int Id { get; set; }
        public string Reference { get; set; }
        public DateTime DateCreation { get; set; }
        public int IdClient { get; set; }
        public int IdUtilisateur { get; set; }
        public string Commentaire { get; set; }

        public Client IdClientNavigation { get; set; }
        public Utilisateur IdUtilisateurNavigation { get; set; }
        public ICollection<Devis> Devis { get; set; }
    }
}
