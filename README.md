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


Metodo: [GET]

Url: https://localhost:44359/conductores/ObtenerDisponibles

Descripcion: trae la lista de todos los conductores disponibles que no tengan viajes activos


Metodo: [GET]

Url: https://localhost:44359/conductores/ObtenerDisponiblesCercanos?latitude=41.57879&longitude=21.52179&km=5

Descripcion: trae la lista de todos los conductores disponibles dentro de un rango determinado por latitude, longitud y la cantidad de kilometros a la redonda. En caso de no poner ningun kilometro el sistema tomara la cantidad por defecto (que en este caso es 3)


Metodo: [GET]

Url: https://localhost:44359/conductores/ObtenerConductor?ID=2

Descripcion: trae un conductor por su ID
