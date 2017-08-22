using System.Web.Http;
using NoteManager.DTO.BaseResponse;
using NoteManager.DTO.Message.Customers;
using NoteManager.Infrastructure.Enums;
using NoteManager.Model.Enums;
using NoteManager.Services.Interfaces;

namespace NoteManager.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet, Route("customers")]
        public FindCustomersResponse Get(FindCustomersRequest request)
        {
            return _customerService.Find(request);
        }

        [HttpPost, Route("customers")]
        public CreateResponse Post(CustomerRequest request)
        {
            return _customerService.Create(request);
        }

        [HttpPut, Route("customers")]
        public SuccessResponse Put(CustomerRequest request)
        {
            return _customerService.Update(request);
        }

        [HttpGet, Route("customers/{Id}")]
        public CustomerResponse Get(GetCustomerRequest request)
        {
            return _customerService.Get(request);
        }

        [HttpDelete, Route("customers/{Id}")]
        public SuccessResponse Delete(DeleteCustomerRequest request)
        {
            return _customerService.Delete(request);
        }

        [HttpGet, Route("customers/gender-type")]
        public EnumeratorResponse Get()
        {
            return new EnumeratorResponse { Enumerator = new EGenderType().ConvertToCollection() };
        }
    }
}