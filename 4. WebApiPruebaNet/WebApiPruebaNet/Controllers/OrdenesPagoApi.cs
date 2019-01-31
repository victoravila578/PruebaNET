using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiPruebaNet.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiPruebaNet.Controllers
{
    [Produces("application/json")]
    [Route("api/OrdenesPagoApi")]
    public class OrdenesPagoApi : Controller
    {
        private readonly PruebaNetDbContext _db;

        public OrdenesPagoApi(PruebaNetDbContext db)
        {
            _db = db;
        }

        // GET: api/values
        [Route("OrdenPago")]
        public IEnumerable<OrdenesPago> GetOrdenPago(int iTipoMoneda)
        {
            return _db.OrdenesPago.ToList();
        }

        //http://localhost:52960/api/OrdenesPagoApi/GetOrdenesPorMoneda?IdSucursal=1&IdTipoMoneda=1
        [Route("GetOrdenesPorMoneda")]
        public dynamic GetOrdenesPorMoneda(int idSucursal, int idTipoMoneda)
        {        
            var data = new Data.OrdenesPago().getAll(idSucursal, idTipoMoneda);
            return data;
        }

        //http://localhost:52960/api/OrdenesPagoApi/GetSucursalesPorBanco?IdBanco=1
        [Route("GetSucursalesPorBanco")]
        public dynamic GetSucursalesPorBanco(int IdBanco)
        {            
            var data = new Data.SucursalesBanco().obtenerSucursalPorBanco(IdBanco);
            return data;

        }

    }
}
