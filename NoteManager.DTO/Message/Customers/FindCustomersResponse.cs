using System.Collections.Generic;
using NoteManager.DTO.BaseResponse;

namespace NoteManager.DTO.Message.Customers
{
    public class FindCustomersResponse : FindBaseResponse
    {
        public FindCustomersResponse()
        {
            Customers = new List<CustomerResponse>();
        }

        public List<CustomerResponse> Customers { get; set; }
    }
}