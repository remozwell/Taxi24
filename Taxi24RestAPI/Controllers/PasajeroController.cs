using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24RestAPI.Bussiness;
using Taxi24RestAPI.Data;
using Taxi24RestAPI.Models;

namespace Taxi24RestAPI.Controllers
{

    [ApiController]
    [Route("Pasajeros")]
    public class PasajeroController : ControllerBase
    {
        private readonly BussinessLogic context;

        public PasajeroController(TaxiContext _context, ConfigurationContext config, PriceGenerator priceG)
        {
            context = new BussinessLogic(_context, config, priceG);
        }


        [HttpGet]
        [Route("ObtenerLista")]
        public ActionResult<List<PasajeroModel>> GetPasajeros()
        {
            try
            {
                return Ok(context.GetPasajeros());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("ObtenerPasajero")]
        public ActionResult<ConductorModel> GetConductors(int ID)
        {
            try
            {
                return Ok(context.GetPasajeroByID(ID));
            }
            catch (NullReferenceException)
            {
                return NotFound("No se encontro ningun registro con este id");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpGet]
        [Route("ObtenerConductoresCercanos")]
        public ActionResult<List<ConductorModel>> GetAvailableConductors(int IDPasajero, double lon, double lat, double km)
        {
            try
            {
                return Ok(context.GetAvailableConductores());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerDisponibles")]
        public ActionResult<List<ConductorModel>> GetAvailableConductors(double latitude, double longitude, double km = 0)
        {
            try
            {

                return Ok(context.GetAvailableConductores(latitude, longitude, km));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
