﻿using System;

namespace NoteManager.Model.Base
{
    public abstract class EntityBase : IAuditInfo
    {
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}