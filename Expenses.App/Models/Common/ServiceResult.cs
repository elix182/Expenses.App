using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Expenses.App.Models.Common
{
    [ExcludeFromCodeCoverage]
    public class ServiceResult
    {
        public Error? Error { get; private set; } = null;
        public List<string> Notes { get; private set; } = new List<string>();

        public bool IsSuccess
        {
            get => Error == null;
        }
        public bool IsError
        {
            get => Error != null;
        }

        public void SetErrorMessage(string message, ErrorCode code = ErrorCode.GENERIC)
        {
            var error = new Error(code, message);
            Error = error;
        }

        public void SetErrorMessage(Exception ex, ErrorCode code = ErrorCode.GENERIC)
        {
            var messageBuilder = new StringBuilder();
            messageBuilder.AppendLine(ex.Message);
            messageBuilder.Append(ex.StackTrace);
            var message = messageBuilder.ToString();
            SetErrorMessage(message, code);
        }

        public void Merge(ServiceResult otherResult)
        {
            if (Error != null)
            {
                Notes.Add("Error: " + Error.Message);
            }
            Error = otherResult.Error;
            Notes.AddRange(otherResult.Notes);
        }
    }

    [ExcludeFromCodeCoverage]
    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }

        public bool IsDataNull
        {
            get => Data == null;
        }
    }
}

