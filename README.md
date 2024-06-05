# Administracion-Hotelera-API

# 💾 Bases de Datos
Pueden revisar las bases de datos con las siguientes credenciales de conexión.
- Metodo: TCP/IP
- Hostname: bgq4xlro2hlfxt8gm1rl-mysql.services.clever-cloud.com
- Port: 3306
- User: uwzmtbcwjtnwpmyl
- Password: iqvTRbmmduzbzdjgXz81


# 🚀 Agencia de Viajes

A continuación encontrará uan documentación de cada uno de los servicios desplegados en este aplicativo.

## 🏨 Hoteles 🛎️

#### **Endpoint 1:** Obtener todos los Hoteles

Este EndPoint devuelve un listado de todos los hoteles existentes en el sistema.

- No requiere de variables.
    

> URL ejemplo  
[https://localhost:44347/api/Hotel](https://localhost:44347/api/Hotel) 
  

#### **Endpoint 2:** Obtener Hotel por ID

Este EndPoint devuelve los datos de un hotel seleccionado desde la URL.

- Parametro: Id del hotel a consultar
    

> URL ejemplo  
[https://localhost:44347/api/Hotel/1](https://localhost:44347/api/Hotel/1) 
  

#### **Endpoint 3:** Insertar Hotel

Este EndPoint permite ingresar un nuevo hotel al sistema.

``` json
{
  "name": "Esaw",
  "city": "Dubai",
  "status": true
}

 ```

> URL ejemplo  
[https://localhost:44347/api/Hotel/](https://localhost:44347/api/Hotel/) 
  

---

#### **Endpoint 4:** Actualizar Hotel

Este EndPoint permite actualizar los datos de un hotel del sistema.

``` json
{
  "id": "10",
  "name": "Esaw",
  "city": "Dubai",
  "status": false
}

 ```

> URL ejemplo  
[https://localhost:44347/api/Hotel](https://localhost:44347/api/Hotel) 
  

---

## 🏨 Habitaciones 🛏️

#### **Endpoint 1:** Obtener Habitaciones por Hotel

Este EndPoint devuelve un listado de todas las habitaciones de un hotel designado.

- Parametro: Id del hotel a consultar
    

> URL ejemplo  
[https://localhost:44347/api/Room/10](https://localhost:44347/api/Room/10) 
  

#### **Endpoint 2:** Insertar Habitación

Este EndPoint permite ingresar una nueva habitación a un hotel del sistema.

``` json
{
  "id_hotel": 10,
  "status": true,
  "value": 70000,
  "tax": 0.2,
  "type": "Duplex",
  "capacity": 5,
  "location": "Piso 4"
}

 ```

> URL ejemplo  
[https://localhost:44347/api/Room/](https://localhost:44347/api/Room/) 
  

#### **Endpoint 3:** Actualizar Habitación

Este EndPoint permite actualizar los datos de una habitación del sistema.

``` json
{
  "id": 8,
  "id_hotel": 10,
  "status": true,
  "value": 70000,
  "tax": 0.2,
  "type": "Single",
  "capacity": 5,
  "location": "Piso 4"
}

 ```

> URL ejemplo  
[https://localhost:44347/api/Room/](https://localhost:44347/api/Room/) 
  

## 🏨 Reservas 📖

#### **Endpoint 1:** Obtener todas las Reservas

Este EndPoint devuelve un listado de todas las reservas existentes en el sistema.

- No requiere de variables.
    

> URL ejemplo  
[https://localhost:44347/api/Booking](https://localhost:44347/api/Booking) 
  

#### **Endpoint 2:** Detalles por Reserva

Este EndPoint devuelve los detalles de una reserva existente.

- Parametro: Id de la reserva a consultar
    

> URL ejemplo  
[https://localhost:44347/api/Booking/12](https://localhost:44347/api/Booking/12) 
  

# 🚀 Viajero

#### **Endpoint 1:** Obtener habitaciones disponibles

Este EndPoint devuelve un listado de las habitaciones dsponibles para rentar en fechas dadas.

- Parametros:
    - date_start: DateTime
    - date_end: DateTime
    - city: String
    - capacity: Int

> URL ejemplo  
[https://localhost:44347/api/Booking/search?date_start=2024-06-10&amp;date_end=2024-06-13&amp;city=Dubai&amp;capacity=3](https://localhost:44347/api/Booking/search?date_start=2024-06-10&date_end=2024-06-13&city=Dubai&capacity=3) 
  

#### **Endpoint 2:** Insertar Reserva

Este EndPoint permite registrar una nueva reserva con los datos de la reserva y del pasajero.

``` json
{
  "id_hotel": 10,
  "id_room": 8,
  "date_start": "2024-06-10",
  "date_end": "2024-06-13",
  "passenger": {
    "id": 1000616728,
    "first_name": "Moises",
    "last_name": "Miranda",
    "date_birth": "2001-09-09",
    "gender": "M",
    "type_doc": "CC",
    "email": "musicaperrona1@gmail.com",
    "phone": "3214553580",
    "emergency_contact": "dsa"
  }
}

 ```

> URL ejemplo  
[https://localhost:44347/api/Booking/](https://localhost:44347/api/Booking/)
