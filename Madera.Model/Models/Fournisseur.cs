using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class Fournisseur
    {
        public Fournisseur()
        {
            Composant = new HashSet<Composant>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Reference { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public int Telephone { get; set; }

        public ICollection<Composant> Composant { get; set; }
    }
}
