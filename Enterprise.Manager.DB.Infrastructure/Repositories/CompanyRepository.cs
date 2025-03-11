using Enterprise.Manager.DB.Infrastructure.DBContext.DBContext;
using Enterprise.Manager.Library.Entities;
using Enterprise.Manager.Library.InfraestructureContracts.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Enterprise.Manager.DB.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly EnterpriseDbContext _enterpriseDbContext;
        public CompanyRepository()
        {
            _enterpriseDbContext = new EnterpriseDbContext();
        }
 
        public async Task<IEnumerable<CompanyEntity>> GetAllAsync()
        {
            return await _enterpriseDbContext.Company.ToListAsync();
        }

        public async Task<CompanyEntity> GetByIdAsync(int id)
        {
            return await _enterpriseDbContext.Company.FindAsync(id);
        }

        public async Task<CompanyEntity> GetByIsinAsync(string isin)
        {
            return await _enterpriseDbContext.Company.FirstOrDefaultAsync(c => c.Isin == isin);
        }

        public async Task AddAsync(CompanyEntity entity)
        {
            await _enterpriseDbContext.Company.AddAsync(entity);
            await _enterpriseDbContext.SaveChangesAsync();
        }
        public void Detach(CompanyEntity entity)
        {
            if (entity != null)
            {
                var entry = _enterpriseDbContext.Entry(entity);
                if (entry.State == EntityState.Modified)
                {
                    entry.State = EntityState.Detached;
                }
            }
        }

        public async Task UpdateAsync(CompanyEntity entity)
        {
            var existingEntity = _enterpriseDbContext.Company.Local
                               .FirstOrDefault(e => e.Id == entity.Id);
            if (existingEntity != null)
            {
                _enterpriseDbContext.Entry(existingEntity).State = EntityState.Detached;
            }
            _enterpriseDbContext.Company.Update(entity);
            await _enterpriseDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _enterpriseDbContext.Company.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"No company founded with id: {id}");
            }
            _enterpriseDbContext.Company.Remove(entity);
            await _enterpriseDbContext.SaveChangesAsync();
        }

        public async Task SaveAsync(int id)
        {
            await _enterpriseDbContext.SaveChangesAsync();
        }
    }
}
