# InventoryManager

Para ejecutar el proyecto lanzar por linea de comandos

dotnet run --project InventoryManager/InventoryManager

Swagger para la API
https://localhost:5001/swagger/index.html

La aplicación lanza log por consola, con lo que se puede comprobar la traza de los métodos y los eventos cuando se ejecutan.

Los nugget utilizados son:
 - EntityFramework InMemory para la base de datos en memoria
 - MassTransit para gestionar eventos a cola en memoria 
 - Moq para los test unitarios
 - FluentAssertions para los test unitarios
 - Swagger documentacion y test de la API
 
