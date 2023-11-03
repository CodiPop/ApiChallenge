using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiChallenge.Models
{
    public partial class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        [StringLength(255),MinLength(1)]
        public string? Descripcion { get; set; }
        public int? TipoProductoId { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Valor { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FechaCompra { get; set; }
        [StringLength(10)]
        public string? EstadoProducto { get; set; }
    }
}
