using System.Collections.Generic;

namespace EH.Entities.Responses
{
    public interface IListData<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }
}
