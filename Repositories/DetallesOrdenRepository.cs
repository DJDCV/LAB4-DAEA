using LAB04_DelCarpioDeivid.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB04_DelCarpioDeivid.Repositories
{
    public class DetallesOrdenRepository : IDetallesOrdenRepository
    {
        private readonly DbContext _context;

        public DetallesOrdenRepository(DbContext context)
        {
            _context = context;
        }

        public Detallesorden GetById(int id)
        {
            return _context.Set<Detallesorden>()
                .Include(d => d.Orden)
                .Include(d => d.Producto)
                .FirstOrDefault(d => d.DetalleId == id);
        }

        public IEnumerable<Detallesorden> GetAll()
        {
            return _context.Set<Detallesorden>()
                .Include(d => d.Orden)
                .Include(d => d.Producto)
                .ToList();
        }

        public void Add(Detallesorden detalle)
        {
            _context.Set<Detallesorden>().Add(detalle);
            _context.SaveChanges();
        }

        public void Update(Detallesorden detalle)
        {
            _context.Set<Detallesorden>().Update(detalle);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var detalle = _context.Set<Detallesorden>().Find(id);
            if (detalle != null)
            {
                _context.Set<Detallesorden>().Remove(detalle);
                _context.SaveChanges();
            }
        }
    }
}