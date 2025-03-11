namespace Enterprise.Manager.Extensions
{
    public class OperationResult<TResult> : OperationResult
    {
        public TResult Result { get; set; }
    }

    public class OperationResult
    {
        public List<ErrorResult> Errors { get; set; }

        public bool HasErrors => Errors != null && Errors.Any();

        public OperationResult()
        {
            Errors = new List<ErrorResult>();
        }
    }
}
