# Taxi24

Este es el proyecto API para los taxis. He utilizado lo que es la base de datos de SQLite. Pero si desean utilizar la base de datos de SQL server, lo unico que tienen que hacer es colocar su connectin string en la parte de "TaxiDBConnection" apuntando a sus servidores y cambiando el settings de "UseSQLite" a "False". El mismo proyecto al arrancar creara lo que es la base de datos y las tablas que necesita.

Para las pruebas pueden usar los siguientes requeste (tomen en cuenta la posibilidad de que el puerto sea diferente)


# Metodo de los conductores
Metodo: [GET]

Url: https://localhost:44359/conductores/obtenerlista

Descripcion: trae la lista de todos los conductores


Metodo: [GET]

Url: https://localhost:44359/conductores/ObtenerDisponibles

Descripcion: trae la lista de todos los conductores disponibles que no tengan viajes activos


Metodo: [GET]

Url: https://localhost:44359/conductores/ObtenerDisponiblesCercanos?latitude=41.57879&longitude=21.52179&km=5

Descripcion: trae la lista de todos los conductores disponibles dentro de un rango determinado por latitude, longitud y la cantidad de kilometros a la redonda. En caso de no poner ningun kilometro el sistema tomara la cantidad por defecto (que en este caso es 3)


Metodo: [GET]

Url: https://localhost:44359/conductores/ObtenerConductor?ID=2

Descripcion: trae un conductor por su ID


# Metodo de los viajes
Metodo: [GET]

Url: https://localhost:44359/viajes/ViajesActivos

Descripcion: trae la lista de todos los viajes activos


Metodo: [POST]

Url: https://localhost:44359/viajes/NuevoViaje?lat=41.57879&lon=21.52179&km=5

Json: {
    "id": 1,
    "nombre": "Carmen",
    "ubicacionLatitud": 41.57881164550781,
    "ubicacionLongitud": 21.52174949645996
}

Descripcion: crea un nuevo viaje con algun conductor dentro del radio (si no se proporciona km, tomara el rango por defecto que es 3)


Metodo: [PUT]

Url: https://localhost:44359/viajes/CompletarViaje

Json:     {
        "id": 1,
        "idConductor": 2,
        "idPasajero": 2,
        "ubicacionInicialLatitud": 41.41231918334961,
        "ubicacionInicialLongitud": 21.52168083190918,
        "ubicacionFinalLatitud": 41.40231918334961,
        "ubicacionFinalLongitud": 21.53168083190918,
        "estatusViaje": "A",
        "fechaInicioViaje": "2021-05-07T18:00:00",
        "fechaFinViaje": null
    }

Descripcion: Completa un viaje especificado y retorna la factura generada para ese viaje


# Metodo de los pasajeros
Metodo: [GET]

Url: https://localhost:44359/pasajeros/obtenerlista

Descripcion: trae la lista de todos los pasajeros


Metodo: [GET]

Url: https://localhost:44359/pasajeros/ObtenerPasajero?ID=1

Descripcion: trae un pasajero por ID


Metodo: [GET]

Url: https://localhost:44359/pasajeros/ObtenerConductoresCercanos?IDPasajero=1&lat=41.57879&lon=21.52179&km=5&cantidadConductores=10

Descripcion: trae una lista de conductores determinada por el valor cantidadConductores desde el punto del pasajero. los campos de km y cantidad de conductores son opcionales, si los dejan en blanco toman los valores por defecto del appsetings (que es 3 en ambos casos)



