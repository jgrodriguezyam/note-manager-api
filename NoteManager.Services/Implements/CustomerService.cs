using System.Collections.Generic;
using System.Linq;
using FastMapper;
using NoteManager.DataAccess.Queries;
using NoteManager.DataAccess.Repositories;
using NoteManager.DTO.BaseResponse;
using NoteManager.DTO.Message.Customers;
using NoteManager.Infrastructure.Exceptions;
using NoteManager.Infrastructure.Integers;
using NoteManager.Model;
using NoteManager.Model.Enums;
using NoteManager.Services.Interfaces;
using NoteManager.Services.Validators.Interfaces;
using ApplicationException = NoteManager.Infrastructure.Exceptions.ApplicationException;

namespace NoteManager.Services.Implements
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerQuery _customerQuery;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerValidator _customerValidator;

        public CustomerService(ICustomerQuery customerQuery, ICustomerRepository customerRepository, ICustomerValidator customerValidator)
        {
            _customerQuery = customerQuery;
            _customerRepository = customerRepository;
            _customerValidator = customerValidator;
        }

        public FindCustomersResponse Find(FindCustomersRequest request)
        {
            try
            {
                _customerQuery.Init();
                _customerQuery.WithOnlyActivated(true);
                _customerQuery.WithName(request.Name);
                _customerQuery.WithLastName(request.LastName);
                _customerQuery.WithGender(request.GenderType.ConvertToEnum<EGenderType>());
                _customerQuery.WithColony(request.Colony);
                _customerQuery.WithMunicipality(request.Municipality);
                _customerQuery.WithHomePhone(request.HomePhone);
                _customerQuery.WithCellPhone(request.CellPhone);
                _customerQuery.Sort(request.Sort, request.SortBy);
                var totalRecords = _customerQuery.TotalRecords();
                _customerQuery.Paginate(request.ItemsToShow, request.Page);
                var customers = _customerQuery.Execute();

                return new FindCustomersResponse
                {
                    Customers = TypeAdapter.Adapt<List<CustomerResponse>>(customers),
                    TotalRecords = totalRecords
                };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public CreateResponse Create(CustomerRequest request)
        {
            try
            {
                var customer = TypeAdapter.Adapt<Customer>(request);
                _customerValidator.ValidateAndThrowException(customer, "Base");
                _customerRepository.Add(customer);
                return new CreateResponse(customer.Id);
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse Update(CustomerRequest request)
        {
            try
            {
                var currentCustomer = _customerRepository.FindBy(request.Id);
                currentCustomer.ThrowExceptionIfRecordIsNull();
                var customerToCopy = TypeAdapter.Adapt<Customer>(request);
                TypeAdapter.Adapt(customerToCopy, currentCustomer);
                _customerValidator.ValidateAndThrowException(currentCustomer, "Base");
                _customerRepository.Update(currentCustomer);
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public CustomerResponse Get(GetCustomerRequest request)
        {
            try
            {
                request.Id.ThrowExceptionIfIsZero();
                _customerQuery.Init();
                _customerQuery.WithOnlyActivated(true);
                _customerQuery.WithId(request.Id);
                var customer = _customerQuery.Execute().FirstOrDefault();
                customer.ThrowExceptionIfRecordIsNull();
                return TypeAdapter.Adapt<Customer, CustomerResponse>(customer);
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse Delete(DeleteCustomerRequest request)
        {
            try
            {
                var customer = _customerRepository.FindBy(request.Id);
                customer.ThrowExceptionIfRecordIsNull();
                _customerRepository.Remove(customer);
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }
    }
}