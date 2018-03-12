using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class FinitionGamme
    {
        public FinitionGamme()
        {
            CritereFinition = new HashSet<CritereFinition>();
            GammeFinition = new HashSet<GammeFinition>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Reference { get; set; }
        public int IdFamilleComposant { get; set; }

        public FamilleComposant IdFamilleComposantNavigation { get; set; }
        public ICollection<CritereFinition> CritereFinition { get; set; }
        public ICollection<GammeFinition> GammeFinition { get; set; }
    }
}
