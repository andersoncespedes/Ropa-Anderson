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
### Visualizar los Veterinarios Cuya Especialidad Sea Cirujano Vascular
#### Endpoint
