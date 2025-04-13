using LAB04_DelCarpioDeivid.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB04_DelCarpioDeivid.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DbContext _context;

        public CategoriaRepository(DbContext context)
        {
            _context = context;
        }

        public Categoria GetById(int id)
        {
            return _context.Set<Categoria>().Find(id);
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _context.Set<Categoria>().ToList();
        }

        public void Add(Categoria categoria)
        {
            _context.Set<Categoria>().Add(categoria);
            _context.SaveChanges();
        }

        public void Update(Categoria categoria)
        {
            _context.Set<Categoria>().Update(categoria);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var categoria = _context.Set<Categoria>().Find(id);
            if (categoria != null)
            {
                _context.Set<Categoria>().Remove(categoria);
                _context.SaveChanges();
            }
        }
    }
}