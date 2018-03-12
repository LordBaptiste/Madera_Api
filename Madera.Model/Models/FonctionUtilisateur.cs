using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class FonctionUtilisateur
    {
        public FonctionUtilisateur()
        {
            Utilisateur = new HashSet<Utilisateur>();
        }

        public int Id { get; set; }
        public string Label { get; set; }

        public ICollection<Utilisateur> Utilisateur { get; set; }
    }
}
