using System.Net;

namespace EH.Entities.Responses
{
    public interface IResponse
    {
        HttpStatusCode StatusCode { get; set; }

        bool IsSuccess { get; set; }

        string ResonseMessage { get; set; }
    }
}
