using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class Caracteristique
    {
        public Caracteristique()
        {
            Composant = new HashSet<Composant>();
            ComposantCaracteristique = new HashSet<ComposantCaracteristique>();
            Module = new HashSet<Module>();
            ModuleCaracteristique = new HashSet<ModuleCaracteristique>();
        }

        public int Id { get; set; }
        public string Label { get; set; }
        public string Unite { get; set; }

        public ICollection<Composant> Composant { get; set; }
        public ICollection<ComposantCaracteristique> ComposantCaracteristique { get; set; }
        public ICollection<Module> Module { get; set; }
        public ICollection<ModuleCaracteristique> ModuleCaracteristique { get; set; }
    }
}
