using System;
using System.Collections.Generic;

namespace Prueba_Scaffollding.Domain
{
    public partial class Barrio
    {
        public Barrio()
        {
            Clientes = new HashSet<Cliente>();
            Vendedores = new HashSet<Vendedore>();
        }

        public int CodBarrio { get; set; }
        public string? Barrio1 { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Vendedore> Vendedores { get; set; }
    }
}
