using System;
using System.Collections.Generic;

namespace Prueba_Scaffollding.Domain
{
    public partial class HistorialPrecio
    {
        public int Id { get; set; }
        public int CodArticulo { get; set; }
        public decimal? Precio { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
    }
}
