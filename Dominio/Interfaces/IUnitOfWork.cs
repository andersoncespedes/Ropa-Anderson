namespace Dominio.Interfaces;

public interface IUnitOfWork
{
        IUser Users { get; }
        IRol Roles { get; }
        IEmpleado Empleados { get; }
        ICliente Clientes { get; }
        IColor Colores { get; }
        IDepartamento Departamentos { get; }
        IDetalleOrden DetalleOrdenes { get; }
        IDetalleVenta DetalleVentas { get; }
        IEmpresa Empresas { get; }
        IFormaPago FormaPagos { get; }
        IGenero Generos { get; }
        IInsumo Insumos { get; }
        IInventario Inventarios { get; }
        IMunicipio Municipios { get; }
        IOrden Ordenes { get; }
        IPais Paises { get; }
        IPrenda Prendas { get; }
        IProveedor Proveedores { get; }
        ITalla Tallas { get; }
        IVenta Ventas { get; }

        Task<int> SaveAsync();
}