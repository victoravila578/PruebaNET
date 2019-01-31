using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebPruebaNet.Models;
using Microsoft.AspNetCore.Http;


namespace WebPruebaNet.Controllers
{
    public class OrdenPagoController : Controller
    {
        // GET: /OrdenVenta/

        public ActionResult Index(int id)
        {
            var ordenpago = new OrdenPago();
            ordenpago.iSucursalId = id;

            var oSucursal = new Sucursal().obtenerSucursal(id);

            ViewBag.iBanco = oSucursal.iBancoId;

            var ordenVentas = new OrdenesPago();
            var resultSet = ordenVentas.getAllOrdenes(id);
            return View(resultSet.lstOrderVenta);
        }

        [HttpGet]
        public ActionResult Insert(int sucursalId)
        {
            var ordenPago = new OrdenPago();
            ordenPago.iSucursalId = sucursalId;

            ViewBag.iSurcursal = sucursalId;

            var lstMonedas = new Moneda().getMonedas(1);            
            ViewBag.TipoMonedaList = lstMonedas;
            return View(ordenPago);
        }

        [HttpPost]
        public ActionResult Insert(OrdenPago ordenPagoModel)
        {
            
            if (ModelState.IsValid)
            {
                //string iTipoMoneda = Request.Form["TipoMonedaList"].ToString();
                //ordenPagoModel.iTipoMoneda = int.Parse(iTipoMoneda);
                int retval = ordenPagoModel.insertarOrdenPago(ordenPagoModel);
                if (retval > 0)
                {
                    return RedirectToAction("Index", "OrdenPago", new { id = ordenPagoModel.iSucursalId });
                }
                else
                {
                    ModelState.AddModelError("", "Error al insertar el orden de pago.");
                }
            }
            return View();

        }

        [HttpGet]
        public ActionResult Edit(OrdenPago ordenPagoModel, int id)
        {
            var ordenPagoBE = new OrdenPago();
            ordenPagoBE = ordenPagoModel.obtenerOrdenPAgo(id);
            ViewBag.iSurcursal = ordenPagoBE.iSucursalId;

            var lstMonedas = new Moneda().getMonedas(ordenPagoBE.iTipoMoneda);
            ViewBag.TipoMonedaList = lstMonedas;

            var lstEstados = new Estado().getEstados(ordenPagoBE.iEstadoId);
            ViewBag.EstadoList = lstEstados;

            return View(ordenPagoBE);
        }

        [HttpPost]
        public ActionResult Edit(OrdenPago ordenPagoModel, FormCollection form)
        {
       

            string iTipoMoneda = Request.Form["TipoMonedaList"].ToString();
            string iEstado = Request.Form["EstadoList"].ToString();
            if (ModelState.IsValid)
            {
                //ordenPagoModel.iTipoMoneda = int.Parse(iTipoMoneda);
                //ordenPagoModel.iEstadoId = int.Parse(iEstado);
                int result = ordenPagoModel.Edit(ordenPagoModel);
                if (result > 0)
                {
                    return RedirectToAction("Index", "OrdenPago", new { id = ordenPagoModel.iSucursalId });
                }
                {
                    ModelState.AddModelError("", "Hubo un problema al actualizar la orden de pago");
                }
            }
            return View(ordenPagoModel);
        }

        public ActionResult Eliminar(OrdenPago ordenPagoModel, int id)
        {
            var ordenPagoBE = new OrdenPago();
            var ObtenerOrdenPagoId = ordenPagoBE.obtenerOrdenPAgo(id);

            var result = ordenPagoBE.eliminarOrdenPago(id);
            if (result > 0)
            {
                return RedirectToAction("Index", "OrdenPago", new { id = ObtenerOrdenPagoId.iSucursalId });
            }
            {
                ModelState.AddModelError("", "Can Not Update");
                return View("Index");
            }
        }


    }
}