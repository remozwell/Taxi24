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
        private readonly ConfigurationContext _configContext;
        private readonly PriceGenerator _priceContext;

        public BussinessLogic(TaxiContext context, ConfigurationContext config, PriceGenerator priceGenerator)
        {
            _context = context;
            _configContext = config;

            _priceContext = priceGenerator;
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

            if (km <= 0)
            {
                km = _configContext.RadioKilometroDefault;
            }

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
        public List<ViajeModel> GetViajesActivos()
        {
            return _context.Tbl_Viajes.Where(x => x.EstatusViaje == 'A').ToList();
        }


        public ViajeModel GenerarNuevoViaje(PasajeroModel pasajero, GeoCoordinate destino, double km)
        {

            Random rd = new Random();
            var conductoresDisponibles = GetAvailableConductores(pasajero.UbicacionLatitud, pasajero.UbicacionLongitud, km);
            var conductor = conductoresDisponibles[rd.Next(0, conductoresDisponibles.Count() - 1)];

            ViajeModel nuevoViaje = new ViajeModel()
            {
                IDConductor = conductor.ID,
                IDPasajero = pasajero.ID,
                Pasajero = pasajero,
                Conductor = conductor,
                EstatusViaje = 'A',
                UbicacionInicialLatitud = pasajero.UbicacionLatitud,
                UbicacionInicialLongitud = pasajero.UbicacionLongitud,
                UbicacionFinalLatitud = destino.Latitude,
                UbicacionFinalLongitud = destino.Longitude
            };
            var _return = _context.Tbl_Viajes.Add(nuevoViaje);
            _context.SaveChanges();
            return _return.Entity;

        }

        public FacturaModel CompletarViaje(ViajeModel viaje)
        {
            var thisViaje = _context.Tbl_Viajes.First(x => x.ID == viaje.ID);
            thisViaje.FechaFinViaje = viaje.FechaFinViaje;
            thisViaje.EstatusViaje = 'C';
            _context.SaveChanges();

            double finalPrice = _priceContext.GetPrecioViaje(thisViaje.getDistanciaRecorrida(), thisViaje.getMinutosViaje().Value);
            FacturaModel nuevaFactura = new FacturaModel()
            {
                Costo = finalPrice,
                duracionViaje = thisViaje.getMinutosViaje().Value,
                distanciaRecorridaKM = thisViaje.getDistanciaRecorrida(),
                viajeID = thisViaje.ID,
                viaje = thisViaje
            };

            var entityFactura = _context.Tbl_Facturas.Add(nuevaFactura);
            _context.SaveChanges();
            return entityFactura.Entity;

        }


        #endregion


    }
}
