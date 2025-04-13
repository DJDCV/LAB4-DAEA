using LAB04_DelCarpioDeivid.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB04_DelCarpioDeivid.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly DbContext _context;

        public ProductoRepository(DbContext context)
        {
            _context = context;
        }

        public Producto GetById(int id)
        {
            return _context.Set<Producto>()
                .Include(p => p.Categoria)
                .FirstOrDefault(p => p.ProductoId == id);
        }

        public IEnumerable<Producto> GetAll()
        {
            return _context.Set<Producto>()
                .Include(p => p.Categoria)
                .ToList();
        }

        public void Add(Producto producto)
        {
            _context.Set<Producto>().Add(producto);
            _context.SaveChanges();
        }

        public void Update(Producto producto)
        {
            _context.Set<Producto>().Update(producto);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var producto = _context.Set<Producto>().Find(id);
            if (producto != null)
            {
                _context.Set<Producto>().Remove(producto);
                _context.SaveChanges();
            }
        }
    }
}