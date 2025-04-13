using LAB04_DelCarpioDeivid.Models;

namespace LAB04_DelCarpioDeivid.Repositories;

public interface IClienteRepository
{
    Cliente GetById(int id);
    IEnumerable<Cliente> GetAll();
    void Add(Cliente cliente);
    void Update(Cliente cliente);
    void Delete(int id);
}