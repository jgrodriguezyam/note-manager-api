using NoteManager.DTO.BaseResponse;
using NoteManager.DTO.Message.Companies;

namespace NoteManager.Services.Interfaces
{
    public interface ICompanyService
    {
        FindCompaniesResponse Find(FindCompaniesRequest request);
        CreateResponse Create(CompanyRequest request);
        SuccessResponse Update(CompanyRequest request);
        CompanyResponse Get(GetCompanyRequest request);
        SuccessResponse Delete(DeleteCompanyRequest request);
    }
}