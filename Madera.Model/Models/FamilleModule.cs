using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class FamilleModule
    {
        public FamilleModule()
        {
            Module = new HashSet<Module>();
        }

        public int Id { get; set; }
        public string Label { get; set; }

        public ICollection<Module> Module { get; set; }
    }
}
