using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSK.ExceptionHandler
{
    public class ExceptionManager
    {
        public static ObjectResult ReturnErrorMessage(Exception exception)
        {
            if (exception is TskException tskException)
            {
                return new ObjectResult(tskException.GetErrorObject())
                {
                    StatusCode = tskException.GetStatusCode()
                };
            }

            var result = new
            {
                ErrorMessage = "Error!",
                DetailedErrorMessage = exception.GetType().Name + ": " + exception.ToString(),
                StatusCode = StatusCodes.Status500InternalServerError
            };
            return new ObjectResult(result);
        }
    }
}
