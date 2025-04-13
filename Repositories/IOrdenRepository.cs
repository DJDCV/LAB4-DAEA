using LAB04_DelCarpioDeivid.Models;

namespace LAB04_DelCarpioDeivid.Repositories
{
    public interface IOrdenRepository
    {
        Ordene GetById(int id);
        IEnumerable<Ordene> GetAll();
        void Add(Ordene orden);
        void Update(Ordene orden);
        void Delete(int id);
    }
}