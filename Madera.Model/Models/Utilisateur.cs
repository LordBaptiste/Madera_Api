using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            Projet = new HashSet<Projet>();
        }

        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int IdFonctionUtilisateur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public FonctionUtilisateur IdFonctionUtilisateurNavigation { get; set; }
        public ICollection<Projet> Projet { get; set; }
    }
}
