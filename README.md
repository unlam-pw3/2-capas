# Ejemplo de Arquitectura de 2 capas utilizando EF Database First

Puntos Importantes:

1- Se utilizando las entidades generadas por EF como modelo de dominio de la aplicación.
2- Se utiliza un servicio dentro de la capa de DominioDatos para resolver un algoritmo complejo evitando que el código resida dentro del frontend Web. (clase: AnimalesServicio)
3- Carga de un listado de items a partir de una enumeración (vista: Coordinacion/Create).


En la carpeta _DB, van a encontrar el script de SQL para generar la base de datos vinculada al código.
