using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24RestAPI.Data;
using Taxi24RestAPI.Models;

namespace Taxi24RestAPI.Bussiness
{
    public class BussinessLogic
    {
        private readonly TaxiContext _context;

        public BussinessLogic(TaxiContext context)
        {
            _context = context;
        }


        public List<ConductorModel> GetConductores()
        {
            return _context.Tbl_Conductores.ToList();
        }

        internal List<ConductorModel> GetAvailableConductores()
        {
            var viajesActivos = _context.Tbl_Viajes.Where(x => x.EstatusViaje == 'A'); ;
            return _context.Tbl_Conductores.Where(x=> !viajesActivos.Select(x=> x.IDConductor).Contains(x.ID)).ToList();
             
        }
    }
}
