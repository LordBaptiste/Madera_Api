using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class Composant
    {
        public Composant()
        {
            ComposantCaracteristique = new HashSet<ComposantCaracteristique>();
            ModuleComposant = new HashSet<ModuleComposant>();
        }

        public int Id { get; set; }
        public string Reference { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public int IdFamilleComposant { get; set; }
        public double PrixHt { get; set; }
        public int IdCaracteristique { get; set; }
        public int IdFournisseur { get; set; }
        public int IdCritereQualite { get; set; }

        public Caracteristique IdCaracteristiqueNavigation { get; set; }
        public CritereQualite IdCritereQualiteNavigation { get; set; }
        public FamilleComposant IdFamilleComposantNavigation { get; set; }
        public Fournisseur IdFournisseurNavigation { get; set; }
        public ICollection<ComposantCaracteristique> ComposantCaracteristique { get; set; }
        public ICollection<ModuleComposant> ModuleComposant { get; set; }
    }
}
