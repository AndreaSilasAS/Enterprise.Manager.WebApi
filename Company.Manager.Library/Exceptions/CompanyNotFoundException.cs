namespace Enterprise.Manager.Library.Exceptions
{
    public class CompanyNotFoundException : Exception
    {
        public CompanyNotFoundException(int companyId) : base($"Company with Id: {companyId} was no found") { }
        public CompanyNotFoundException(string isin) : base($"Company with ISIN: {isin} was no found") { }
    }
}
