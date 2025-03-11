namespace Enterprise.Manager.Library.Exceptions
{
    public class CompanyInsertException : Exception
    {
        public CompanyInsertException(string name, Exception ex) : base($"Error inserting company : { name }", ex) { }
    }
}
