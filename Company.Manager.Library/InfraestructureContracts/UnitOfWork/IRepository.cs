using Enterprise.Manager.Library.Entities;

namespace Enterprise.Manager.Library.InfraestructureContracts.UnitOfWork
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CompanyEntity>> GetAllAsync();
        Task<CompanyEntity> GetByIdAsync(int id);
        Task<CompanyEntity> GetByIsinAsync(string isin);
        Task AddAsync(CompanyEntity entity);
        Task UpdateAsync(CompanyEntity entity);
        Task DeleteAsync(int id);
        Task SaveAsync(int id);
    }
}
