using System;
using System.Collections.Generic;

namespace Prueba_Scaffollding.Domain
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public int NroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public int CodCliente { get; set; }
        public int CodVendedor { get; set; }

        public virtual Cliente CodClienteNavigation { get; set; } = null!;
        public virtual Vendedore CodVendedorNavigation { get; set; } = null!;
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
