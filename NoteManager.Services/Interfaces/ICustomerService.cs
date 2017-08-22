using NoteManager.DTO.BaseResponse;
using NoteManager.DTO.Message.Customers;

namespace NoteManager.Services.Interfaces
{
    public interface ICustomerService
    {
        FindCustomersResponse Find(FindCustomersRequest request);
        CreateResponse Create(CustomerRequest request);
        SuccessResponse Update(CustomerRequest request);
        CustomerResponse Get(GetCustomerRequest request);
        SuccessResponse Delete(DeleteCustomerRequest request);
    }
}