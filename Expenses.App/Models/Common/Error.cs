using System.Diagnostics.CodeAnalysis;

namespace Expenses.App.Models.Common
{
    [ExcludeFromCodeCoverage]
    public class Error
    {
        public ErrorCode Code { get; set; } = ErrorCode.NOERROR;
        public string Message { get; private set; } = "";

        public Error() { }

        public Error(ErrorCode code)
        {
            Code = code;
        }

        public Error(ErrorCode code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}

