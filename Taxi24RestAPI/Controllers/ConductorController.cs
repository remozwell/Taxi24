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
    [Route("Conductores")]
    public class ConductorController : ControllerBase
    {
        private readonly BussinessLogic context;

        public ConductorController(TaxiContext _context, ConfigurationContext config, PriceGenerator priceG)
        {
            context = new BussinessLogic(_context, config, priceG);
        }


        [HttpGet]
        [Route("ObtenerLista")]
        public ActionResult<List<ConductorModel>> GetConductors()
        {
            try
            {
                return Ok(context.GetConductores());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerDisponibles")]
        public ActionResult<List<ConductorModel>> GetAvailableConductors()
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
        [Route("ObtenerDisponiblesCercanos")]
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


        [HttpGet]
        [Route("ObtenerConductor")]
        public ActionResult<ConductorModel> GetConductors(int ID)
        {
            try
            {
                return Ok(context.GetConductorByID(ID));
            }
            catch(NullReferenceException)
            {
                return NotFound("No se encontro ningun registro con este id");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
