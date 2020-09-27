namespace EH.Entities.Responses
{
    public interface IData<TModel> : IResponse
    {
        TModel Model { get; set; }
    }
}
