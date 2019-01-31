using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebPruebaNet.Models;
using Microsoft.AspNetCore.Http;

namespace WebPruebaNet.Controllers
{
    public class SucursalController : Controller
    {
        // GET: /Sucursal/
        Sucursal sucursal = new Sucursal();
        
        public ActionResult Index(int id)
        {
            sucursal.iBancoId = id;            
            var sucursalModel = new Sucursales();
            var resultSet = sucursalModel.getAllInfo(id);            
            return View(resultSet);
        }

        [HttpGet]
        public ActionResult Insert(int bancoId)
        {
            var oSucursal = new Sucursal();
            oSucursal.iBancoId = bancoId;

            ViewBag.iBanco = bancoId;
            return View(oSucursal);
        }

        [HttpPost]
        public ActionResult Insert(Sucursal sucursalModel)
        {          
            if (ModelState.IsValid)
            {
                int retval = sucursalModel.insertarSucursal(sucursalModel);
                if (retval > 0)
                {
                    return RedirectToAction("Index", "Sucursal", new { id = sucursalModel.iBancoId });
                }
                else
                {
                    ModelState.AddModelError("", "Can Not Insert");
                }
            }
            return View();

        }


        [HttpGet]
        public ActionResult Edit(Sucursal SucursalModel, int id)
        {
            var SucursalBE = new Sucursal();
            SucursalBE = SucursalModel.obtenerSucursal(id);
            ViewBag.iBanco = SucursalBE.iBancoId;
            return View(SucursalBE);
        }

        [HttpPost]
        public ActionResult Edit(Sucursal sucursalBE, FormCollection form)
        {            
            var SucursalM = new Sucursal();
            SucursalM = sucursalBE.obtenerSucursal(sucursalBE.iSucursalId);
            
            if (ModelState.IsValid)
            {
                int result = sucursalBE.Edit(sucursalBE);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Sucursal", new { id = SucursalM.iBancoId });
                }
                {
                    ModelState.AddModelError("", "Can Not Update");
                }
            }
            return View(sucursalBE);
        }

        public ActionResult Eliminar(Sucursal sucursalBE, int id)
        {
            var SucursalM = new Sucursal();
            SucursalM = sucursalBE.obtenerSucursal(id);

            var result = sucursalBE.eliminarSucursal(id);
            if (result > 0)
            {
                return RedirectToAction("Index", "Sucursal", new { id = SucursalM.iBancoId });
            }
            {
                ModelState.AddModelError("", "Can Not Update");
                return View("Index");
            }
        }
    }
}