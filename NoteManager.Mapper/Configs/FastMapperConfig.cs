using FastMapper;
using NoteManager.DTO.Message.Companies;
using NoteManager.DTO.Message.Customers;
using NoteManager.DTO.Message.Users;
using NoteManager.Model;

namespace NoteManager.Mapper.Configs
{
    public static class FastMapperConfig
    {
        public static void Initialize()
        {
            #region User

            TypeAdapterConfig<User, User>
                .NewConfig()
                .IgnoreMember(dest => dest.Id)
                .IgnoreMember(dest => dest.UserName)
                .IgnoreMember(dest => dest.Password)

                .IgnoreMember(dest => dest.CreatedBy)
                .IgnoreMember(dest => dest.CreatedOn)
                .IgnoreMember(dest => dest.ModifiedBy)
                .IgnoreMember(dest => dest.ModifiedOn)
                .IgnoreMember(dest => dest.IsActive);

            TypeAdapterConfig<UserRequest, User>
                .NewConfig();

            TypeAdapterConfig<User, UserResponse>
                .NewConfig();

            #endregion

            #region Company

            TypeAdapterConfig<Company, Company>
                .NewConfig()
                .IgnoreMember(dest => dest.Id)

                .IgnoreMember(dest => dest.CreatedBy)
                .IgnoreMember(dest => dest.CreatedOn)
                .IgnoreMember(dest => dest.ModifiedBy)
                .IgnoreMember(dest => dest.ModifiedOn)
                .IgnoreMember(dest => dest.IsActive);

            TypeAdapterConfig<CompanyRequest, Company>
                .NewConfig();

            TypeAdapterConfig<Company, CompanyResponse>
                .NewConfig();

            #endregion

            #region Customer

            TypeAdapterConfig<Customer, Customer>
                .NewConfig()
                .IgnoreMember(dest => dest.Id)

                .IgnoreMember(dest => dest.CreatedBy)
                .IgnoreMember(dest => dest.CreatedOn)
                .IgnoreMember(dest => dest.ModifiedBy)
                .IgnoreMember(dest => dest.ModifiedOn)
                .IgnoreMember(dest => dest.IsActive);

            TypeAdapterConfig<CustomerRequest, Customer>
                .NewConfig();

            TypeAdapterConfig<Customer, CustomerResponse>
                .NewConfig();

            #endregion
        }
    }
}