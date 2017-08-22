﻿using System;

namespace NoteManager.Infrastructure.Exceptions
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public DataAccessException(string message) : base(message)
        {
        }
    }
}