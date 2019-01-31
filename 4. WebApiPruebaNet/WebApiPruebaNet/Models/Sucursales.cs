using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiPruebaNet.Models
{
    public class Sucursales
    {
        [Key]
        [Required]
        public int iSucursalId { get; set; }
        [Required]
        public int iBancoId { get; set; }
        [Required]
        public string vNombre { get; set; }
        [Required]
        public string vDireccion { get; set; }
        [Required]
        public int iActivo { get; set; }
        [Required]
        public string dFechaRegistro { get; set; }
    }
}
