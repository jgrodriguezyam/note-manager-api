using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NoteManager.DataAccess.Repositories;
using NoteManager.EntityFramework.DataBase;
using NoteManager.Model;

namespace NoteManager.EntityFramework.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDataBaseSqlServerEntityFramework _dataBaseSqlServerEntityFramework;

        public CompanyRepository(IDataBaseSqlServerEntityFramework dataBaseSqlServerEntityFramework)
        {
            _dataBaseSqlServerEntityFramework = dataBaseSqlServerEntityFramework;
        }

        public Company FindBy(int id)
        {
            return _dataBaseSqlServerEntityFramework.GetById<Company>(item => item.Id == id);
        }

        public IEnumerable<Company> FindBy(Expression<Func<Company, bool>> predicate)
        {
            return _dataBaseSqlServerEntityFramework.FindBy(predicate);
        }

        public void Add(Company item)
        {
            _dataBaseSqlServerEntityFramework.InsertForSystem(item);
        }

        public void Update(Company item)
        {
            _dataBaseSqlServerEntityFramework.UpdateForSystem(item);
        }

        public void Remove(Company item)
        {
            _dataBaseSqlServerEntityFramework.LogicRemoveForSystem(item);
        }
    }
}