using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiChallenge.Models
{
    [Table("TiposProducto")]
    public partial class TiposProducto
    {
        [Key]
        public int TipoProductoId { get; set; }
        [Required]
        [StringLength(50)]
        public string? Nombre { get; set; }
    }
}
