using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NoteManager.Infrastructure.IGenericRepositories
{
    public interface IReadableRepository<T>
    {
        T FindBy(int id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}