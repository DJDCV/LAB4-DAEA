using LAB04_DelCarpioDeivid.Models;

namespace LAB04_DelCarpioDeivid.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly TiendaDbContext _context;

    public IClienteRepository Clientes { get; }
    public ICategoriaRepository Categorias { get; }
    public IProductoRepository Productos { get; }
    public IDetallesOrdenRepository DetallesOrdenes { get; }
    public IOrdenRepository Ordenes { get; }
    public IPagoRepository Pagos { get; }

    public UnitOfWork(
        TiendaDbContext context,
        IClienteRepository clienteRepository,
        ICategoriaRepository categoriaRepository,
        IProductoRepository productoRepository,
        IDetallesOrdenRepository detallesOrdenRepository,
        IOrdenRepository ordenRepository,
        IPagoRepository pagoRepository)
    {
        _context = context;
        Clientes = clienteRepository;
        Categorias = categoriaRepository;
        Productos = productoRepository;
        DetallesOrdenes = detallesOrdenRepository;
        Ordenes = ordenRepository;
        Pagos = pagoRepository;
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

