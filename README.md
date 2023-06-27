# NewShoreFlights

Esta aplicación consiste en encontrar vuelos que coincidan con un lugar de origen y un lugar de destino específicos, de esta forma,
brindarle a los usuarios respectivos viajes que sean de su preferencia.Desarrollada en el backend mediante el framework .Net con C#,
esta cuenta con algunas restricciones;

1) El origen y el destino no pueden ser iguales
2) Las rutas deben tener maximo 3 caracteres
3) Las rutas deben estar en Mayuscula sostenida

## Arquitectura utilizada

Arquitectura Hexagonal

## Framework y Lenguaje de programación

.Net, C#

## Librerias

* Mvc.Testing
* HttpClient
* JsonConvert

## Modelo

* Flight: Representa cada uno de los vuelos en un viaje
* GeneralFlight: Representa los vuelos obtenidos del API del ejercicios
* Journey: Representa el viaje con diferentes vuelos
* Transport: Representa el número del vuelo y las iniciales del pais

![image](https://github.com/git-aramirez/NewShoreFlights/assets/70823877/ec88c4a9-6306-4cc2-97bd-ed46bc4a1df1)

* Conversation: Representa la conversión para el cambio de moneda
* Quote: represetna el monto  en diferentes monedas que equivale a un dolar

  
## APIs Utilizadas

1) recruiting-api.newshore.es:
   Api proporcionada por el enunciado del ejercicio para gestionar los viajes
3) apilayer.net:
   Api utilizada para la conversión del dolor a otras monedas.

## Tests

Se realizaron algunas pruebas a nivel del servicio para validar el correcto funcionamiento de los viajes.

## Control de Exceptions

Se controlo la exeption badRequest por medio de un handling, para mostrar un mensaje personalizado a los usuarios dependiendo del caso

## Logs

Se imprimen diferentes logs para monitorear el flujo del programa

## Endpoints
1)
* url : https://localhost:7121/Flight/flights
* http: Get
* description: este endpoint es encargado de traer todos los vuelos proporcionados por la API del ejercicios
  
2)
* url: https://localhost:7121/Flight/journeys/{origin}/{destination}
* htttp: Post
* description: este endpoint obtiene los v vuelos obtenidos del origen y el destino proporcionados por el usuario
* parameters: {origin} : string  {destination} : string
* Request body : [{"departureStation":"MZL","arrivalStation":"MDE","flightCarrier":"CO","flightNumber":"8001","price":200}]
  
3)
* url : https://localhost:7121/Flight/convertion
* http: Get
* description: este endpoint es encargado de obtener la conversión respectivo al equivalente de un dolar

## Authorization

No se utilizó ningun tipo de autorización para esta aplicación

