# Ropa Anderson Cespedes

## Consultas
### Basicas
- Crear
```
[POST]localhost:5022/api/[Nombre de la entidad]/Create
```
- Editar
```
[PUT]localhost:5022/api/[Nombre de la entidad]/Update
```
- Eliminar
```
[DELETE]localhost:5022/api/[Nombre de la entidad]/Delete/[id]
```
- Conseguir Por Id
```
[GET]localhost:5022/api/[Nombre de la entidad]/Obtener/[id]
```
- Listar v1.0
```
[GET]localhost:5022/api/[Nombre de la entidad]/
```
- Listar v1.1
```
[GET]localhost:5022/api/[Nombre de la entidad]/
```
```
X-Version : 1.1
```
### JWT
#### Registrar
- Endpoint
```
http://localhost:5022/api/User/Register/
```
#### Token
- Endpoint
```
http://localhost:5022/api/User/Token/
```
#### Añadri rol
- Endpoint
```
http://localhost:5022/api/User/addrole/
```
####  Refresh Token
```
http://localhost:5022/api/User/refresh-token/
```
### Listar los insumos que pertenecen a una prenda especifica. El usuario debe ingresar el código de la prenda
#### Endpoint
```
localhost:5118/api/Prenda/GetInsumo?Codigo=a
```
### Listar los Insumos que son vendidos por un determinado proveedor cuyo tipo de persona sea Persona Jurídica. El usuario debe ingresar el Nit de proveedor.
#### Endpoint
```
localhost:5118/api/Proveedor/GetInsumo?Codigo=a
```
### Listar todas las ordenes de producción cuyo estado se en proceso.
#### Endpoint
```
localhost:5118/api/Orden/ByEstado?
```
### Listar los empleados por un cargo especifico. Los cargos que se encuentran en la empresa son: Auxiliar de Bodega, Jefe de Producción, Corte, Jefe de bodega, Secretaria, Jefe de IT.
#### Endpoint
```
localhost:5118/api/Empleado/getByCargo
```
### Listar las ordenes de producción que pertenecen a un cliente especifico.
#### Endpoint
```
localhost:5118/api/Cliente/getSDataById/{id}
```
### Listar las ventas realizadas por un empleado especifico.
#### Endpoint
```
localhost:5118/api/Cliente/getByVenta/{id}
```
