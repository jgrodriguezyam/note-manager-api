using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NoteManager.DataAccess.Repositories;
using NoteManager.EntityFramework.DataBase;
using NoteManager.Model;

namespace NoteManager.EntityFramework.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDataBaseSqlServerEntityFramework _dataBaseSqlServerEntityFramework;

        public CustomerRepository(IDataBaseSqlServerEntityFramework dataBaseSqlServerEntityFramework)
        {
            _dataBaseSqlServerEntityFramework = dataBaseSqlServerEntityFramework;
        }

        public Customer FindBy(int id)
        {
            return _dataBaseSqlServerEntityFramework.GetById<Customer>(item => item.Id == id);
        }

        public IEnumerable<Customer> FindBy(Expression<Func<Customer, bool>> predicate)
        {
            return _dataBaseSqlServerEntityFramework.FindBy(predicate);
        }

        public void Add(Customer item)
        {
            _dataBaseSqlServerEntityFramework.InsertForSystem(item);
        }

        public void Update(Customer item)
        {
            _dataBaseSqlServerEntityFramework.UpdateForSystem(item);
        }

        public void Remove(Customer item)
        {
            _dataBaseSqlServerEntityFramework.LogicRemoveForSystem(item);
        }
    }
}