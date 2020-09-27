using EH.Entities.Entities.DbEntities;
using EH.Entities.Repository;
using EH.Entities.Responses;
using EH.Entities.Responses.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System;
using System.Threading.Tasks;
using EH.Entities.Entities.CustomeEntities;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace EH.Repository.ContactRepo
{
    public class ContactRepository : IContactRepository
    {
        #region Init
        private readonly IMapper _mapperProfile;
        private readonly IRepositoryBase<UserContact> _contactRepository;

        public ContactRepository(IRepositoryBase<UserContact> contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapperProfile = mapper;
        }
        #endregion
        public async Task<IListData<DbtoContact>> GetAll()
        {
            var response = new ListData<DbtoContact>();
            try
            {
                var allContacts = _contactRepository.GetAll();
                if (await allContacts.AnyAsync())
                {
                    response.Model = _mapperProfile.Map<List<DbtoContact>>(await allContacts.ToListAsync());
                    response.SendResponse(isSuccess: true, "Total " + response.Model.Count().ToString() + " record found.", HttpStatusCode.OK);
                }
                else
                {
                    response.Model = null;
                    response.SendResponse(true, "No data found for this request.");
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Model = null;
                response.SendResponse(false, ex.Message, exception: ex);
                return response;
            }
        }
        public async Task<IData<DbtoContact>> GetRecord(int id)
        {
            var response = new Data<DbtoContact>();
            try
            {
                UserContact contact = await _contactRepository.GetAll().Where(x => x.Id == id).FirstOrDefaultAsync();

                if (contact != null && contact.Id > 0)
                {
                    response.Model = _mapperProfile.Map<DbtoContact>(contact);
                    response.SendResponse(true, "Data found for this request.", HttpStatusCode.OK);
                }
                else
                {
                    response.Model = null;
                    response.SendResponse(true, "No data found for this request.", HttpStatusCode.OK);
                }
                return response;
            }
            catch (System.Exception ex)
            {
                response.Model = null;
                response.SendResponse(false, ex.Message, exception: ex);
                return response;
            }
        }
        public async Task<IData<DbtoContact>> CreateContact(Contact contact)
        {
            var response = new Data<DbtoContact>();
            try
            {
                #region Check existing record by Email
                var existContact = await _contactRepository.GetAll().Where(x => x.Email == contact.Email).FirstOrDefaultAsync();
                if (existContact != null && existContact.Id > 0)
                {
                    response.SendResponse(true, "Email is already registered with other contact, Please try a different email.", HttpStatusCode.OK);
                    response.Model = _mapperProfile.Map<DbtoContact>(existContact);
                    return response;
                }
                #endregion

                var userContact = _mapperProfile.Map<UserContact>(contact);
                await _contactRepository.CreateAsync(userContact);
                response.Model = _mapperProfile.Map<DbtoContact>(userContact);
                response.SendResponse(true, "Contact has been created successfully.", HttpStatusCode.OK);
                return response;
            }
            catch (Exception ex)
            {
                response.Model = null;
                response.SendResponse(false, ex.Message, exception: ex);
                return response;
            }

        }
        public async Task<IData<DbtoContact>> InActiveContact(int id)
        {
            var response = new Data<DbtoContact>();
            try
            {
                var contact = await _contactRepository.GetAll().Where(x => x.Id == id).FirstOrDefaultAsync();
                if (contact != null && contact.Id > 0)
                {
                    #region Check if contact is InActive
                    if (!contact.Status)
                    {
                        response.Model = _mapperProfile.Map<DbtoContact>(contact);
                        response.SendResponse(true, "Contact is already deactivated.");
                        return response;
                    }
                    #endregion

                    contact.Status = false;
                    await _contactRepository.UpdateAsync(contact);
                    response.Model = _mapperProfile.Map<DbtoContact>(contact);
                    response.SendResponse(true, "Contact has been deactivated successfully.");
                }
                else
                {
                    response.Model = null;
                    response.SendResponse(true, "No data found for this request.");
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Model = null;
                response.SendResponse(false, ex.Message, exception: ex);
                return response;
            }
        }
        public async Task<IData<DbtoContact>> UpdateContact(int id, Contact contact)
        {
            var response = new Data<DbtoContact>();
            try
            {
                #region Check existing record by Email
                var existContact = await _contactRepository.GetAll().Where(x => x.Email == contact.Email && x.Id != id).FirstOrDefaultAsync();
                if (existContact != null && existContact.Id > 0)
                {
                    response.SendResponse(true, "Email is already registered with other contact, Please try a different email.", HttpStatusCode.OK);
                    response.Model = _mapperProfile.Map<DbtoContact>(existContact);
                    return response;
                }
                #endregion

                UserContact userAccount = await _contactRepository.GetAll().Where(x => x.Id == id).FirstOrDefaultAsync();
                if (userAccount != null && userAccount.Id > 0)
                {
                    userAccount = _mapperProfile.Map(contact, userAccount);
                    await _contactRepository.UpdateAsync(userAccount);
                    response.Model = _mapperProfile.Map<DbtoContact>(userAccount);
                    response.SendResponse(true, "Contact has been updated successfully.");
                }
                else
                {
                    response.Model = null;
                    response.SendResponse(true, "No data found for this request.");
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Model = null;
                response.SendResponse(false, ex.Message, exception: ex);
                return response;
            }
        }
        public async Task<IData<DbtoContact>> DeleteContact(int id)
        {
            var response = new Data<DbtoContact>();
            try
            {
                UserContact userContact = await _contactRepository.GetAll().Where(x => x.Id == id).FirstOrDefaultAsync();
                if (userContact != null)
                {
                    await _contactRepository.DeleteAsync(userContact);
                    response.Model = _mapperProfile.Map<DbtoContact>(userContact);
                    response.SendResponse(true, "Contact has been deleted successfully.", HttpStatusCode.OK);
                }
                else
                {
                    response.Model = null;
                    response.SendResponse(true, "No data found for this request.");
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Model = null;
                response.SendResponse(false, ex.Message, exception: ex);
                return response;
            }

        }
    }
}
