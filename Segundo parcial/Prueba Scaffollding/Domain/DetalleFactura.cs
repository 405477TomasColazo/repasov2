using System;
using System.Collections.Generic;

namespace Prueba_Scaffollding.Domain
{
    public partial class DetalleFactura
    {
        public int NroFactura { get; set; }
        public int CodArticulo { get; set; }
        public decimal PreUnitario { get; set; }
        public short Cantidad { get; set; }

        public virtual Articulo CodArticuloNavigation { get; set; } = null!;
        public virtual Factura NroFacturaNavigation { get; set; } = null!;
    }
}
