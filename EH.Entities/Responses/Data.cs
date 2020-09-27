namespace EH.Entities.Responses
{
    public class Data<TModel> : IData<TModel> where TModel : new()
    {
        public TModel Model { get; set; }
        public System.Net.HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string ResonseMessage { get; set; }

        public Data()
        {
            Model = new TModel();
        }
    }
}
