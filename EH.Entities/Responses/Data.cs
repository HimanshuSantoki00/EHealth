using System.Net;

namespace EH.Entities.Responses
{
    public class Data<TModel> : IData<TModel> where TModel : new()
    {
        public TModel Model { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ResonseMessage { get; set; }

        public Data()
        {
            Model = new TModel();
        }
    }
}
