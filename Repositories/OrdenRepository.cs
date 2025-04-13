using LAB04_DelCarpioDeivid.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB04_DelCarpioDeivid.Repositories
{
    public class OrdenRepository : IOrdenRepository
    {
        private readonly DbContext _context;

        public OrdenRepository(DbContext context)
        {
            _context = context;
        }

        public Ordene GetById(int id)
        {
            return _context.Set<Ordene>()
                .Include(o => o.Cliente)
                .Include(o => o.Detallesordens)
                .Include(o => o.Pagos)
                .FirstOrDefault(o => o.OrdenId == id);
        }

        public IEnumerable<Ordene> GetAll()
        {
            return _context.Set<Ordene>()
                .Include(o => o.Cliente)
                .Include(o => o.Detallesordens)
                .Include(o => o.Pagos)
                .ToList();
        }

        public void Add(Ordene orden)
        {
            _context.Set<Ordene>().Add(orden);
            _context.SaveChanges();
        }

        public void Update(Ordene orden)
        {
            _context.Set<Ordene>().Update(orden);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var orden = _context.Set<Ordene>().Find(id);
            if (orden != null)
            {
                _context.Set<Ordene>().Remove(orden);
                _context.SaveChanges();
            }
        }
    }
}