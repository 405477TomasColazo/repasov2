using System;
using System.Collections.Generic;

namespace Prueba_Scaffollding.Domain
{
    public partial class Vendedore
    {
        public Vendedore()
        {
            Facturas = new HashSet<Factura>();
        }

        public int CodVendedor { get; set; }
        public string NomVendedor { get; set; } = null!;
        public string ApeVendedor { get; set; } = null!;
        public string Calle { get; set; } = null!;
        public int? Altura { get; set; }
        public int? CodBarrio { get; set; }
        public long? NroTel { get; set; }
        public string? EMail { get; set; }
        public DateTime? FecNac { get; set; }

        public virtual Barrio? CodBarrioNavigation { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
