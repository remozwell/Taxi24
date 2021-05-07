using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
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

        #region ConductoresMethods
        public List<ConductorModel> GetConductores()
        {
            return _context.Tbl_Conductores.ToList();
        }

        public ConductorModel GetConductorByID(int ID)
        {
            return _context.Tbl_Conductores.First(x=> x.ID == ID);
        }

        public List<ConductorModel> GetAvailableConductores()
        {
            var viajesActivos = _context.Tbl_Viajes.Where(x => x.EstatusViaje == 'A'); ;
            return _context.Tbl_Conductores.Where(x => !viajesActivos.Select(x => x.IDConductor).Contains(x.ID)).ToList();

        }

        public List<ConductorModel> GetAvailableConductores(double lat, double lon, double km)
        {
            var puntoBusqueda = new GeoCoordinate(lat, lon);
            var distanciaGeografica = DistanciaGeograficaHelper.GetSquareRadiusCoordenate(puntoBusqueda, km);

            var viajesActivos = _context.Tbl_Viajes.Where(x => x.EstatusViaje == 'A'); ;
            var conductoresDisponibles = _context.Tbl_Conductores.Where(x => !viajesActivos.Select(x => x.IDConductor).Contains(x.ID));

            return conductoresDisponibles.Where(x =>
                x.UbicacionLatitud > distanciaGeografica.min.Latitude &&
                x.UbicacionLongitud > distanciaGeografica.min.Longitude &&
                x.UbicacionLatitud < distanciaGeografica.min.Latitude &&
                x.UbicacionLongitud < distanciaGeografica.min.Longitude
                ).ToList();

        }
        #endregion


        #region ViajesMethods

        #endregion


    }
}
