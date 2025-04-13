namespace LAB04_DelCarpioDeivid.Repositories;

public interface IUnitOfWork : IDisposable
{
    IClienteRepository Clientes { get; }
    ICategoriaRepository Categorias { get; }
    IDetallesOrdenRepository DetallesOrdenes { get; }
    IOrdenRepository Ordenes { get; }
    IPagoRepository Pagos { get; }
    IProductoRepository Productos { get; }
    int SaveChanges();

}