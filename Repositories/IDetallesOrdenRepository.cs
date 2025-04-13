using LAB04_DelCarpioDeivid.Models;

namespace LAB04_DelCarpioDeivid.Repositories
{
    public interface IDetallesOrdenRepository
    {
        Detallesorden GetById(int id);
        IEnumerable<Detallesorden> GetAll();
        void Add(Detallesorden detalle);
        void Update(Detallesorden detalle);
        void Delete(int id);
    }
}