using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSK.ExceptionHandler
{
    public class TskExceptionModel
    {
        public string ErrorMessage { get; set; } = string.Empty;
        public string DetailedErrorMessage { get; set; } = string.Empty;
        public int StatusCode { get; set; }
    }

    public class TskException : Exception
    {
        private readonly string _errorMessage = "";
        private readonly string _detailedErrorMessage = "";
        private readonly int _statusCode = 500;

        public TskException(string message, string detailedErrorMessage, int? statusCode = null)
        {
            this._errorMessage = message;
            this._detailedErrorMessage = detailedErrorMessage;
            if (statusCode.HasValue)
                this._statusCode = statusCode.Value;
        }

        public TskException(string message, int? statusCode = null)
        {
            this._errorMessage = message;
            this._detailedErrorMessage = string.Empty;
            if (statusCode.HasValue)
                this._statusCode = statusCode.Value;
        }

        public int GetStatusCode()
        {
            return this._statusCode;
        }

        public dynamic GetErrorObject()
        {
            if ((_statusCode >= 200 && _statusCode <= 210) || _statusCode == 412)
                return _errorMessage;
            else
            {
                return new TskExceptionModel
                {
                    ErrorMessage = this._errorMessage,
                    DetailedErrorMessage = this._detailedErrorMessage,
                    StatusCode = this._statusCode
                };
            }
        }
    }
}
