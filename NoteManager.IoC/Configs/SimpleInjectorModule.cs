using System.Data;
using NoteManager.DataAccess.Listeners;
using NoteManager.DataAccess.Queries;
using NoteManager.DataAccess.Repositories;
using NoteManager.EntityFramework.DataBase;
using NoteManager.EntityFramework.Queries;
using NoteManager.EntityFramework.Repositories;
using NoteManager.Infrastructure.Files;
using NoteManager.Services.Implements;
using NoteManager.Services.Interfaces;
using NoteManager.Services.Validators.Implements;
using NoteManager.Services.Validators.Interfaces;
using SimpleInjector;

namespace NoteManager.IoC.Configs
{
    public static class SimpleInjectorModule
    {
        private static Container _container;

        public static void SetContainer(Container container)
        {
            _container = container;
        }

        public static Container GetContainer()
        {
            return _container;
        }

        public static void VerifyContainer()
        {
            _container.Verify();
        }

        public static void Load()
        {
            _container.RegisterWebApiRequest<IDataBaseSqlServerEntityFramework, DataBaseSqlServerEntityFramework>();
            _container.RegisterInitializer<DataBaseSqlServerEntityFramework>(handler =>
            {
                handler.AuditEventListener = _container.GetInstance<IAuditEventListener>();
                handler.DbContext = new ApiContext();
                handler.DbContext.Database.Connection.Open();
                handler.DbContextTransaction = handler.DbContext.Database.BeginTransaction(IsolationLevel.Snapshot);
            });

            _container.Register<IAuditEventListener, AuditEventListener>();
            _container.Register<IFileResolver, FileResolver>();
            _container.Register<IFileValidator, FileValidator>();
            _container.Register<IStorageProvider, StorageProvider>();
            
            _container.Register<IUserRepository, UserRepository>();
            _container.Register<IUserQuery, UserQuery>();
            _container.Register<IUserValidator, UserValidator>();
            _container.Register<IUserService, UserService>();

            _container.Register<ICompanyRepository, CompanyRepository>();
            _container.Register<ICompanyQuery, CompanyQuery>();
            _container.Register<ICompanyValidator, CompanyValidator>();
            _container.Register<ICompanyService, CompanyService>();

            _container.Register<ICustomerRepository, CustomerRepository>();
            _container.Register<ICustomerQuery, CustomerQuery>();
            _container.Register<ICustomerValidator, CustomerValidator>();
            _container.Register<ICustomerService, CustomerService>();
        }
    }
}