using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class GammeFinition
    {
        public int Id { get; set; }
        public int IdFinitionGamme { get; set; }

        public FinitionGamme IdFinitionGammeNavigation { get; set; }
        public Gamme IdNavigation { get; set; }
    }
}
