using EH.Entities.Entities.CustomeEntities;
using EH.Entities.Responses;
using System.Threading.Tasks;

namespace EH.Repository.ContactRepo
{
    public interface IContactRepository
    {
        Task<IListData<DbtoContact>> GetAll();
        Task<IData<DbtoContact>> GetRecord(int id);
        Task<IData<DbtoContact>> CreateContact(Contact contact);
        Task<IData<DbtoContact>> InActiveContact(int contactId);
        Task<IData<DbtoContact>> UpdateContact(int contactId, Contact contactToUpdate);
        Task<IData<DbtoContact>> DeleteContact(int contactId);
        
    }
}
