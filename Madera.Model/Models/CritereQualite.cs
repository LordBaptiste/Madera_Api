using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class CritereQualite
    {
        public CritereQualite()
        {
            Composant = new HashSet<Composant>();
            CritereFinition = new HashSet<CritereFinition>();
        }

        public int Id { get; set; }
        public string Label { get; set; }
        public int IdFamilleComposant { get; set; }

        public FamilleComposant IdFamilleComposantNavigation { get; set; }
        public ICollection<Composant> Composant { get; set; }
        public ICollection<CritereFinition> CritereFinition { get; set; }
    }
}
