using System.Collections.Generic;
using NoteManager.DTO.BaseResponse;

namespace NoteManager.DTO.Message.Companies
{
    public class FindCompaniesResponse : FindBaseResponse
    {
        public FindCompaniesResponse()
        {
            Companies = new List<CompanyResponse>();
        }

        public List<CompanyResponse> Companies { get; set; }
    }
}