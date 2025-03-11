using Enterprise.Manager.Library.InfraestructureContracts.UnitOfWork;

namespace Enterprise.Manager.DB.Infraestructure.UnitOfWork
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public void AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public T GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
