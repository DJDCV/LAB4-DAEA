using LAB04_DelCarpioDeivid.Models;

namespace LAB04_DelCarpioDeivid.Repositories
{
    public interface ICategoriaRepository
    {
        Categoria GetById(int id);
        IEnumerable<Categoria> GetAll();
        void Add(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(int id);
    }
}