using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class CritereFinition
    {
        public int Id { get; set; }
        public int IdCritereQualite { get; set; }

        public CritereQualite IdCritereQualiteNavigation { get; set; }
        public FinitionGamme IdNavigation { get; set; }
    }
}
