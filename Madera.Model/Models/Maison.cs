using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class Maison
    {
        public Maison()
        {
            Bloc = new HashSet<Bloc>();
            Devis = new HashSet<Devis>();
        }

        public int Id { get; set; }
        public int IdDevis { get; set; }
        public int IdGamme { get; set; }

        public Devis IdDevisNavigation { get; set; }
        public Gamme IdGammeNavigation { get; set; }
        public ICollection<Bloc> Bloc { get; set; }
        public ICollection<Devis> Devis { get; set; }
    }
}
