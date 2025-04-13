using LAB04_DelCarpioDeivid.Models;

namespace LAB04_DelCarpioDeivid.Repositories
{
    public interface IProductoRepository
    {
        Producto GetById(int id);
        IEnumerable<Producto> GetAll();
        void Add(Producto producto);
        void Update(Producto producto);
        void Delete(int id);
    }
}