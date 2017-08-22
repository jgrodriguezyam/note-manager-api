using System.Collections.Generic;
using NoteManager.Infrastructure.Enums;

namespace NoteManager.DTO.BaseResponse
{
    public class EnumeratorResponse
    {
        public EnumeratorResponse()
        {
            Enumerator = new List<Enumerator>();
        }

        public List<Enumerator> Enumerator { get; set; }
    }
}