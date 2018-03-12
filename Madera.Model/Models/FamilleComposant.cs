using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class FamilleComposant
    {
        public FamilleComposant()
        {
            Composant = new HashSet<Composant>();
            ComposantGenerique = new HashSet<ComposantGenerique>();
            CritereQualite = new HashSet<CritereQualite>();
            FinitionGamme = new HashSet<FinitionGamme>();
        }

        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

        public ICollection<Composant> Composant { get; set; }
        public ICollection<ComposantGenerique> ComposantGenerique { get; set; }
        public ICollection<CritereQualite> CritereQualite { get; set; }
        public ICollection<FinitionGamme> FinitionGamme { get; set; }
    }
}
