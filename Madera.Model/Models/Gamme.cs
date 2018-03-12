using System;
using System.Collections.Generic;

namespace Madera.Model.Models
{
    public partial class Gamme
    {
        public Gamme()
        {
            GammeFinition = new HashSet<GammeFinition>();
            Maison = new HashSet<Maison>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public double Marge { get; set; }

        public ICollection<GammeFinition> GammeFinition { get; set; }
        public ICollection<Maison> Maison { get; set; }
    }
}
