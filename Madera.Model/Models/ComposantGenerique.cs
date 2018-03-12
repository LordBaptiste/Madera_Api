using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class ComposantGenerique
    {
        public ComposantGenerique()
        {
            ModuleComposantGenerique = new HashSet<ModuleComposantGenerique>();
        }

        public int Id { get; set; }
        public string Reference { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public int IdFamilleComposant { get; set; }

        public FamilleComposant IdFamilleComposantNavigation { get; set; }
        public ICollection<ModuleComposantGenerique> ModuleComposantGenerique { get; set; }
    }
}
