using System.Collections.Generic;
using System.Net;

namespace EH.Entities.Responses
{
    public class ListData<TModel> : IListData<TModel>
    {
        public IEnumerable<TModel> Model { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ResonseMessage { get; set; }
    }
}
