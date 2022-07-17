using System;

namespace ERP.Framework.Exceptions
{
    public class ValidationException : Exception
    {
        public string ErrorCode { get; set; }
         
        public string ErrorDescription { get; set; }               

        public ValidationException(string errorCode, string errorDescription)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }
    }
}
