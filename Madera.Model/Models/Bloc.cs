using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class Bloc
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int IdModule { get; set; }
        public int IdMaison { get; set; }

        public Maison IdMaisonNavigation { get; set; }
        public Module IdModuleNavigation { get; set; }
    }
}
