using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24RestAPI.Models;

namespace Taxi24RestAPI.Data
{
    public class TaxiDbInitializer
    {
        public static void Initialize(TaxiContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            // Revisando que no este vacia
            if (dbContext.Tbl_Conductores.Any())
            {
                dbContext.Dispose();
                return;
            }

            var Conductores = new ConductorModel[]
            {
            new ConductorModel{Nombre="Juan",UbicacionLatitud = 41.57879F, UbicacionLongitud = 21.52179F, Vehiculo = "Civic" },
            new ConductorModel{Nombre="Pedro",UbicacionLatitud = 41.41235F, UbicacionLongitud = 21.52169F, Vehiculo = "Mercedes" },
            new ConductorModel{Nombre="Jose",UbicacionLatitud = 41.57878F, UbicacionLongitud = 21.52171F, Vehiculo = "Toyota" },
            new ConductorModel{Nombre="marino",UbicacionLatitud = 40.57878F, UbicacionLongitud = 25.52171F, Vehiculo = "Toyota" },
            };

            foreach (var C in Conductores)
            {
                dbContext.Tbl_Conductores.Add(C);
            }
            dbContext.SaveChanges();


            var pasajeros = new PasajeroModel[]
            {
            new PasajeroModel{Nombre="Maira",UbicacionLatitud = 41.57877F, UbicacionLongitud = 21.52179F },
            new PasajeroModel{Nombre="Georgina",UbicacionLatitud = 41.41232F, UbicacionLongitud = 21.52168F},
            new PasajeroModel{Nombre="Carmen",UbicacionLatitud = 41.57881F, UbicacionLongitud = 21.52175F },
            };

            foreach (var P in pasajeros)
            {
                dbContext.Tbl_Pasajeros.Add(P);
            }
            dbContext.SaveChanges();

            var viajes = new ViajeModel[]
            {
            new ViajeModel{
                IDConductor = 2,
                IDPasajero = 2,
                //Pasajero = dbContext.Tbl_Pasajeros.First(x=> x.ID == 2),
                //Conductor = dbContext.Tbl_Conductores.First(x=> x.ID == 2),
                EstatusViaje = 'A',
                FechaInicioViaje = DateTime.Now,
                UbicacionInicialLatitud = 41.41232F, UbicacionInicialLongitud = 21.52168F,
                UbicacionFinalLatitud = 41.40232F, UbicacionFinalLongitud = 21.53168F}
            };
            foreach (var v in viajes)
            {
                dbContext.Tbl_Viajes.Add(v);
            }
            dbContext.SaveChanges();
            dbContext.Dispose();
        }

    }
}
