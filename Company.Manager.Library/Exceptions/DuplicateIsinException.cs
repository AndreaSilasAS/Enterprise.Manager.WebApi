namespace Enterprise.Manager.Library.Exceptions
{
    public class DuplicateIsinException : Exception
    {
        public DuplicateIsinException(string isin) : base($"Isin {isin} already exists in database") { }
    }
}
