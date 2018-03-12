using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class Module
    {
        public Module()
        {
            Bloc = new HashSet<Bloc>();
            ModuleCaracteristique = new HashSet<ModuleCaracteristique>();
            ModuleComposant = new HashSet<ModuleComposant>();
            ModuleComposantGenerique = new HashSet<ModuleComposantGenerique>();
        }

        public int Id { get; set; }
        public string Label { get; set; }
        public string Reference { get; set; }
        public int IdFamilleModule { get; set; }
        public int IdCaracteristique { get; set; }

        public Caracteristique IdCaracteristiqueNavigation { get; set; }
        public FamilleModule IdFamilleModuleNavigation { get; set; }
        public ICollection<Bloc> Bloc { get; set; }
        public ICollection<ModuleCaracteristique> ModuleCaracteristique { get; set; }
        public ICollection<ModuleComposant> ModuleComposant { get; set; }
        public ICollection<ModuleComposantGenerique> ModuleComposantGenerique { get; set; }
    }
}
