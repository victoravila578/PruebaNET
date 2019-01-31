using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiPruebaNet.Models
{
    [Table("OrdenesPago")]
    public class OrdenesPago
    {
        [Key]
        [Required]
        public int iOrdenId { get; set; }
        [Required]
        public int iSucursalId { get; set; }
        [Required]
        public double fMonto { get; set; }
        [Required]
        public int iTipoMoneda { get; set; }
        [Required]
        public DateTime dFechaPago { get; set; }
    }
}
