using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Manager.Extensions
{
    public class ErrorResult
    {
        public int Code { get; set; }

        public Exception Exception { get; set; }

        public string Message { get; set; }

        public ErrorResult() { }

        public ErrorResult(string message, int code, Exception exception = null)
        {
            Code = code;
            Message = message;
            Exception = exception;
        }
    }
}
