using LAB04_DelCarpioDeivid.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB04_DelCarpioDeivid.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly DbContext _context;

        public PagoRepository(DbContext context)
        {
            _context = context;
        }

        public Pago GetById(int id)
        {
            return _context.Set<Pago>()
                .Include(p => p.Orden)
                .FirstOrDefault(p => p.PagoId == id);
        }

        public IEnumerable<Pago> GetAll()
        {
            return _context.Set<Pago>()
                .Include(p => p.Orden)
                .ToList();
        }

        public void Add(Pago pago)
        {
            _context.Set<Pago>().Add(pago);
            _context.SaveChanges();
        }

        public void Update(Pago pago)
        {
            _context.Set<Pago>().Update(pago);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var pago = _context.Set<Pago>().Find(id);
            if (pago != null)
            {
                _context.Set<Pago>().Remove(pago);
                _context.SaveChanges();
            }
        }
    }
}