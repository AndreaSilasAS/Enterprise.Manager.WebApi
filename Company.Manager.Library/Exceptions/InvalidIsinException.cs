namespace Enterprise.Manager.Library.Exceptions
{
    public class InvalidIsinException : ArgumentException
    {
        public InvalidIsinException(string isin) : base($"ISIN is invalid: {isin}") { }
    }
}
