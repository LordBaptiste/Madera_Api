using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class ModuleCaracteristique
    {
        public double Valeur { get; set; }
        public int Id { get; set; }
        public int IdCaracteristique { get; set; }

        public Caracteristique IdCaracteristiqueNavigation { get; set; }
        public Module IdNavigation { get; set; }
    }
}
