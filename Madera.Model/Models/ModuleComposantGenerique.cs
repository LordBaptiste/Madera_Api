using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class ModuleComposantGenerique
    {
        public int Quantite { get; set; }
        public int Id { get; set; }
        public int IdComposantGenerique { get; set; }

        public ComposantGenerique IdComposantGeneriqueNavigation { get; set; }
        public Module IdNavigation { get; set; }
    }
}
