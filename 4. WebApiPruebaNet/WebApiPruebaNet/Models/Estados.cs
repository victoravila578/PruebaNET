using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiPruebaNet.Models
{
    public class Estados
    {
        [Key]
        [Required]
        public int iEstadoId { get; set; }
        [Required]
        public string vDescripcionEstado { get; set; }
    }
}
