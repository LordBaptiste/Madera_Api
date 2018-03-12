using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class ModuleComposant
    {
        public int Quantite { get; set; }
        public int Id { get; set; }
        public int IdComposant { get; set; }

        public Composant IdComposantNavigation { get; set; }
        public Module IdNavigation { get; set; }
    }
}
