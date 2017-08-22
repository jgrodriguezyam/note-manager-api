using System.Collections.Generic;
using System.Linq;
using FastMapper;
using NoteManager.DataAccess.Queries;
using NoteManager.DataAccess.Repositories;
using NoteManager.DTO.BaseResponse;
using NoteManager.DTO.Message.Companies;
using NoteManager.Infrastructure.Exceptions;
using NoteManager.Model;
using NoteManager.Services.Interfaces;
using NoteManager.Services.Validators.Interfaces;

namespace NoteManager.Services.Implements
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyQuery _companyQuery;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyValidator _companyValidator;

        public CompanyService(ICompanyQuery companyQuery, ICompanyRepository companyRepository, ICompanyValidator companyValidator)
        {
            _companyQuery = companyQuery;
            _companyRepository = companyRepository;
            _companyValidator = companyValidator;
        }


        public FindCompaniesResponse Find(FindCompaniesRequest request)
        {
            try
            {
                _companyQuery.Init();
                _companyQuery.WithOnlyActivated(true);
                _companyQuery.WithName(request.Name);
                _companyQuery.WithColony(request.Colony);
                _companyQuery.WithCity(request.City);
                _companyQuery.Sort(request.Sort, request.SortBy);
                var totalRecords = _companyQuery.TotalRecords();
                _companyQuery.Paginate(request.ItemsToShow, request.Page);
                var companies = _companyQuery.Execute();

                return new FindCompaniesResponse
                {
                    Companies = TypeAdapter.Adapt<List<CompanyResponse>>(companies),
                    TotalRecords = totalRecords
                };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public CreateResponse Create(CompanyRequest request)
        {
            try
            {
                var company = TypeAdapter.Adapt<Company>(request);
                _companyValidator.ValidateAndThrowException(company, "Base");
                _companyRepository.Add(company);
                return new CreateResponse(company.Id);
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse Update(CompanyRequest request)
        {
            try
            {
                var currentCompany = _companyRepository.FindBy(request.Id);
                currentCompany.ThrowExceptionIfRecordIsNull();
                var companyToCopy = TypeAdapter.Adapt<Company>(request);
                TypeAdapter.Adapt(companyToCopy, currentCompany);
                _companyValidator.ValidateAndThrowException(currentCompany, "Base");
                _companyRepository.Update(currentCompany);
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public CompanyResponse Get(GetCompanyRequest request)
        {
            try
            {
                request.Id.ThrowExceptionIfIsZero();
                _companyQuery.Init();
                _companyQuery.WithOnlyActivated(true);
                _companyQuery.WithId(request.Id);
                var company = _companyQuery.Execute().FirstOrDefault();
                company.ThrowExceptionIfRecordIsNull();
                return TypeAdapter.Adapt<Company, CompanyResponse>(company);
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse Delete(DeleteCompanyRequest request)
        {
            try
            {
                var company = _companyRepository.FindBy(request.Id);
                company.ThrowExceptionIfRecordIsNull();
                _companyRepository.Remove(company);
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }
    }
}