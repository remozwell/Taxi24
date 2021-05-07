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
    [Route("Conductores")]
    public class ViajeController : Controller
    {
        private readonly BussinessLogic context;
        private readonly ConfigurationContext configContext;

        public ViajeController(TaxiContext _context, ConfigurationContext config)
        {
            context = new BussinessLogic(_context);
            configContext = config;
        }


        [HttpGet]
        [Route("NuevoViaje")]
        public ActionResult<ViajeModel> PostNuevoViaje(PasajeroModel persona, GeoCoordinate destino, double km = 0)
        {
            try
            {
                if(km <= 0)
                {
                    km = configContext.RadioKilometroDefault;
                }
                return Ok(context.GenerarNuevoViaje(persona,destino, km));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
