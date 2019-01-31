using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiPruebaNet.Models
{
    public class OrdenPagoSucursal
    {
        [Required]
        public int iCodigoOrdenPago { get; set; }
        [Required]
        public int iCodigoSucursal { get; set; }
        [Required]
        public string vNombreSucursal { get; set; }
        [Required]
        public decimal fMonto { get; set; }
        [Required]
        public int iCodigoTipoMoneda { get; set; }
        [Required]
        public string vMonedaDescripcion { get; set; }
        [Required]
        public int iCodigoEstado { get; set; }
        [Required]
        public string vDescripcionEstado { get; set; }
        [Required]
        public string dFechaPago { get; set; }

    }
}
