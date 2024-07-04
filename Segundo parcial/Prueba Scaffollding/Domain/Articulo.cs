using System;
using System.Collections.Generic;

namespace Prueba_Scaffollding.Domain
{
    public partial class Articulo
    {
        public Articulo()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public int CodArticulo { get; set; }
        public string? Descripcion { get; set; }
        public short? StockMinimo { get; set; }
        public short Stock { get; set; }
        public decimal PreUnitario { get; set; }
        public string? Observaciones { get; set; }

        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
