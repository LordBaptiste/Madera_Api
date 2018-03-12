using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class Devis
    {
        public Devis()
        {
            Maison = new HashSet<Maison>();
        }

        public int Id { get; set; }
        public string Reference { get; set; }
        public double Prix { get; set; }
        public int IdProjet { get; set; }
        public int IdEtatDevis { get; set; }
        public int IdMaison { get; set; }
        public DateTime DateCreation { get; set; }

        public EtatDevis IdEtatDevisNavigation { get; set; }
        public Maison IdMaisonNavigation { get; set; }
        public Projet IdProjetNavigation { get; set; }
        public ICollection<Maison> Maison { get; set; }
    }
}
