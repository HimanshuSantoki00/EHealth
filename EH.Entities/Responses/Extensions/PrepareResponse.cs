using System;
using System.Net;

namespace EH.Entities.Responses.Extensions
{
    public static class Prepareresponse
    {
        public static void SendResponse(this IResponse response, bool isSuccess, string msg, HttpStatusCode statusCode = HttpStatusCode.OK, Exception exception = null)
        {
            response.StatusCode = statusCode;

            if (!isSuccess)
            {
                if (exception == null)
                    response.ResonseMessage = "Something went wrong, please contact to support team.";
                else
                    response.ResonseMessage = exception.Message;
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            else
                response.ResonseMessage = msg;
        }
    }
}
