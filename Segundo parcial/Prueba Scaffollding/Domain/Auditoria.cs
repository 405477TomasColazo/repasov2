using System;
using System.Collections.Generic;

namespace Prueba_Scaffollding.Domain
{
    public partial class Auditoria
    {
        public int Id { get; set; }
        public string? Tabla { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Detalle { get; set; }
        public int? CodEntidad { get; set; }
        public string? Movimiento { get; set; }
    }
}
