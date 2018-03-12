using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class ComposantCaracteristique
    {
        public double? Valeur { get; set; }
        public int Id { get; set; }
        public int IdCaracteristique { get; set; }

        public Caracteristique IdCaracteristiqueNavigation { get; set; }
        public Composant IdNavigation { get; set; }
    }
}
