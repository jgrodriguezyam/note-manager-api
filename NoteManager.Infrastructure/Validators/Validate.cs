using System;
using System.Linq;

namespace NoteManager.Infrastructure.Validators
{
    public static class Validate<T>
    {
        public static bool Property(string property)
        {
            var myType = typeof(T);
            return myType.GetProperties().Any(prop => prop.Name.Equals(property, StringComparison.OrdinalIgnoreCase));
        }
    }
}