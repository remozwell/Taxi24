using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Taxi24RestAPI.Bussiness;
using Taxi24RestAPI.Data;
using Taxi24RestAPI.Models;
using GeoCoordinatePortable;

namespace Taxi24RestAPI.Controllers
{

    [ApiController]
    [Route("Viajes")]
    public class ViajeController : Controller
    {
        private readonly BussinessLogic context;

        public ViajeController(TaxiContext _context, ConfigurationContext config, PriceGenerator priceG)
        {
            context = new BussinessLogic(_context, config, priceG);
        }


        [HttpGet]
        [Route("ViajesActivos")]
        public ActionResult<ViajeModel> getViajes()
        {
            try
            {
                return Ok(context.GetViajesActivos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("NuevoViaje")]
        public ActionResult<ViajeModel> PostNuevoViaje(PasajeroModel persona, GeoCoordinate destino, double km = 0)
        {
            try
            {
                return Ok(context.GenerarNuevoViaje(persona, destino, km));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("CompletarViaje")]
        public ActionResult<FacturaModel> CompletarViaje(ViajeModel viaje)
        {
            try
            {
                return Ok(context.CompletarViaje(viaje));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
