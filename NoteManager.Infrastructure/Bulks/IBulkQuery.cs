using System.Collections.Generic;

namespace NoteManager.Infrastructure.Bulks
{
    public interface IBulkQuery
    {
        bool Insert(IEnumerable<object> items);
    }
}