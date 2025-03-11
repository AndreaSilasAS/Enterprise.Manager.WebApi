using Enterprise.Manager.Contracts.ServiceLibrary.DTO;
using Enterprise.Manager.Library.Entities;

namespace Enterprise.Manager.ServiceLibrary.Mapper.Custom
{
    internal static class CompanyCustomMapping
    {
        internal static CompanyEntity FromCreateRequestToEntity(this CompanyDto src)
        {
            var entity = new CompanyEntity()
            {
                Exchange = src.Exchange,  
                Isin = src.Isin,
                Name = src.Name,
                Ticker = src.Ticker,
                Website = src.Website
            };

            return entity;
        }

        internal static CompanyEntity FromUpdateRequestToEntity(this CompanyDto src)
        {
            var entity = new CompanyEntity()
            {
                Id = src.Id,
                Exchange = src.Exchange,
                Isin = src.Isin,
                Name = src.Name,
                Ticker = src.Ticker,
                Website = src.Website
            };

            return entity;
        }
    }
}
