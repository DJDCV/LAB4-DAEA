using LAB04_DelCarpioDeivid.Models;

namespace LAB04_DelCarpioDeivid.Repositories
{
    public interface IPagoRepository
    {
        Pago GetById(int id);
        IEnumerable<Pago> GetAll();
        void Add(Pago pago);
        void Update(Pago pago);
        void Delete(int id);
    }
}