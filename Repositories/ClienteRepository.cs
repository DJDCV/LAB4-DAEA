using LAB04_DelCarpioDeivid.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LAB04_DelCarpioDeivid.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbContext _context;

        public ClienteRepository(DbContext context)
        {
            _context = context;
        }

        public Cliente GetById(int id)
        {
            return _context.Set<Cliente>().Find(id);
        }
        
        public IEnumerable<Cliente> GetAll()
        {
            return _context.Set<Cliente>().ToList();
        }
        
        public void Add(Cliente cliente)
        {
            _context.Set<Cliente>().Add(cliente);
            _context.SaveChanges();
        }
        
        public void Update(Cliente cliente)
        {
            _context.Set<Cliente>().Update(cliente);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cliente = _context.Set<Cliente>().Find(id);
            if (cliente != null)
            {
                _context.Set<Cliente>().Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}