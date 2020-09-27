using System.Threading.Tasks;
using EH.ApplicationServer.ApiHelper;
using EH.Entities.Entities.CustomeEntities;
using EH.Repository.ContactRepo;
using Microsoft.AspNetCore.Mvc;

namespace EH.ApplicationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        #region Init
        protected IContactRepository contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await contactRepository.GetAll();
            return response.SendHttpResponse();
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await contactRepository.GetRecord(id);
            return response.SendHttpResponse();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await contactRepository.CreateContact(contact);
            return response.SendHttpResponse();
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> InactiveContact(int id)
        {
            var response = await contactRepository.InActiveContact(id);
            return response.SendHttpResponse();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await contactRepository.UpdateContact(id, contact);
            return response.SendHttpResponse();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await contactRepository.DeleteContact(id);
            return response.SendHttpResponse();
        }
    }
}