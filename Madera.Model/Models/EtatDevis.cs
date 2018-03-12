using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class EtatDevis
    {
        public EtatDevis()
        {
            Devis = new HashSet<Devis>();
        }

        public int Id { get; set; }
        public string Label { get; set; }

        public ICollection<Devis> Devis { get; set; }
    }
}
