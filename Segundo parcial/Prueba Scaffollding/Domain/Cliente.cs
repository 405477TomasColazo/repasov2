using System;
using System.Collections.Generic;

namespace Prueba_Scaffollding.Domain
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public int CodCliente { get; set; }
        public string NomCliente { get; set; } = null!;
        public string ApeCliente { get; set; } = null!;
        public string Calle { get; set; } = null!;
        public int? Altura { get; set; }
        public int CodBarrio { get; set; }
        public long? NroTel { get; set; }
        public string? EMail { get; set; }

        public virtual Barrio CodBarrioNavigation { get; set; } = null!;
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
