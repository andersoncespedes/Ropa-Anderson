using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    {}

    public DbSet<User> Users { get; set; }
    public DbSet<Cargo> Cargos { get; set; }
    public DbSet<Cliente> Clientes  { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<DetalleOrden> DetalleOrdenes { get; set; }
    public DbSet<DetalleVenta> DetalleVentas { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Estado> Estados { get; set;}
    public DbSet<FormaPago> FormaPagos { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<Insumo> Insumos { get; set; }
    public DbSet<Inventario> Inventarios { get; set; }
    public DbSet<Municipio> Municipios { get; set;}
    public DbSet<Orden> Ordenes {get; set;}
    public DbSet<Pais> Paises {get; set;}
    public DbSet<Prenda> Prendas {get; set;}
    public DbSet<Proveedor> Proveedores {get; set;}
    public DbSet<Rol> Roles {get; set;}
    public DbSet<Talla> Tallas {get; set;}
    public DbSet<TipoEstado> TipoEstados {get; set;}
    public DbSet<TipoPersona> TipoPersonas {get; set;}
    public DbSet<TipoProteccion> TipoProtecciones {get; set;}
    public DbSet<Venta> Ventas {get; set;}
    public DbSet<RefreshToken> RefreshTokens {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}