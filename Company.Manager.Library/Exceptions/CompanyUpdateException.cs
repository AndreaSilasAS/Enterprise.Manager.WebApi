namespace Enterprise.Manager.Library.Exceptions
{
    public class CompanyUpdateException : Exception
    {
        public CompanyUpdateException(string name, Exception ex) : base($"Error updating company : {name}", ex) { }
    }
}
