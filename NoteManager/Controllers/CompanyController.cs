using System.Web.Http;
using NoteManager.DTO.BaseResponse;
using NoteManager.DTO.Message.Companies;
using NoteManager.Services.Interfaces;

namespace NoteManager.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet, Route("companies")]
        public FindCompaniesResponse Get(FindCompaniesRequest request)
        {
            return _companyService.Find(request);
        }

        [HttpPost, Route("companies")]
        public CreateResponse Post(CompanyRequest request)
        {
            return _companyService.Create(request);
        }

        [HttpPut, Route("companies")]
        public SuccessResponse Put(CompanyRequest request)
        {
            return _companyService.Update(request);
        }

        [HttpGet, Route("companies/{Id}")]
        public CompanyResponse Get(GetCompanyRequest request)
        {
            return _companyService.Get(request);
        }

        [HttpDelete, Route("companies/{Id}")]
        public SuccessResponse Delete(DeleteCompanyRequest request)
        {
            return _companyService.Delete(request);
        }
    }
}