﻿using System.Collections.Generic;

namespace NoteManager.DataAccess.Queries
{
    public interface IQuery<T>
    {
        void Init();
        void Sort(string sort, string sortBy);
        void Paginate(int itemsToShow, int page);
        int TotalRecords();
        IEnumerable<T> Execute();
    }
}