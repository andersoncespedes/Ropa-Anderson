using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiContext context;
    private IUser _users;
    private IRol _rol;
    private ICliente _clientes;
    private IColor _color;
    private IDepartamento _departamento;
    private IDetalleOrden _detalleOrden;
    private IDetalleVenta _detalleVenta;
    private IEmpleado _empleado;
    private IEmpresa _empresa;
    private IFormaPago _formaPago;
    private IGenero _genero;
    private IInsumo _insumo;
    private IInventario _inventario;
    private IMunicipio _municipio;
    private IOrden _orden;
    private IPais _pais;
    private IPrenda _prenda;
    private IProveedor _proveedor;
    private ITalla _talla;
    private IUser _user;
    private IVenta _venta;
    public UnitOfWork(ApiContext _context)
    {
        context = _context;
    }
    public IUser Users
    {
        get
        {
            if(_users == null){
                _users = new UserRepository(context);
            }
            return _users;
        }
    }

    public IEmpleado Empleados{
        get{
            _empleado ??= new EmpleadoRepository(context);
            return _empleado;
        }
    }

    public ICliente Clientes 
    {
        get{
            _clientes ??= new ClienteRepository(context);
            return _clientes;
        }
    }

    public IColor Colores {
        get{
            _color ??=new ColorRepository(context);
            return _color;
        }
    }

    public IDepartamento Departamentos
    {
        get{
            _departamento ??= new DepartamentoRepository(context);
            return _departamento;
        }
    }

    public IDetalleOrden DetalleOrdenes 
    {
        get{
            _detalleOrden ??= new DetalleOrdenRepository(context);
            return _detalleOrden;
        }
    }

    public IDetalleVenta DetalleVentas
    {
        get{
            _detalleVenta ??= new DetalleVentaRepository(context);
            return _detalleVenta;
        }
    }

    public IEmpresa Empresas {
        get{
            _empresa ??=new EmpresaRepository(context);
            return _empresa;
        }
    }

    public IFormaPago FormaPagos{
        get{
            _formaPago ??= new FormaPagoRepository(context);
            return _formaPago;
        }
    }

    public IGenero Generos {
        get{
            _genero ??= new GeneroRepository(context);
            return _genero;
        }
    }

    public IInsumo Insumos {
        get{
            _insumo ??= new InsumoRepository(context);
            return _insumo;
        }
    }

    public IInventario Inventarios{
        get{
            _inventario ??= new InventarioRepository(context);
            return _inventario;
        }
    }

    public IMunicipio Municipios{
        get{
            _municipio ??= new MunicipioRepository(context);
            return _municipio;
        }
    }

    public IOrden Ordenes {
        get{
            _orden ??= new OrdenRepository(context);
            return _orden;
        }
    }

    public IPais Paises {
        get{
            _pais ??= new PaisRepository(context);
            return _pais;
        }
    }

    public IPrenda Prendas {
        get{
            _prenda ??= new PrendaRepository(context);
            return _prenda;
        }
    }

    public IProveedor Proveedores{
        get{
            _proveedor ??= new ProveedorRepository(context);
            return _proveedor;
        }
    }

    public ITalla Tallas {
        get{
            _talla ??= new TallaRepository(context);
            return _talla;
        }
    }

    public IVenta Ventas {
        get{
            _venta ??= new VentaRepository(context);
            return _venta;
        }
    }

    public IRol Roles {
        get{
            _rol ??= new RolRepository(context);
            return _rol;
        }
    }

    public void Dispose()
    {
        context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}