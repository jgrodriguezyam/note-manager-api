using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using NoteManager.Infrastructure.Integers;
using NoteManager.Infrastructure.Objects;
using NoteManager.Infrastructure.Strings;
using NoteManager.Infrastructure.Validators;

namespace NoteManager.Infrastructure.Queries
{
    public static class QueryFactory
    {
        private const int NumberOfPagesToSubtract = 1;
        public const char PropertyAndChildSeparator = '.';

        //public static string SelectQuery(this string query, string fields, string tables)
        //{
        //    query += "SELECT " + fields + ", ROW_NUMBER() OVER (ORDER BY {0} {1}) rownum FROM " + tables;
        //    return query;
        //}

        //public static string SelectTotalQuery(this string query, string field, string tables)
        //{
        //    query += string.Format("SELECT COUNT({0}) FROM {1}", field, tables);
        //    return query;
        //}

        public static string SortResolver(this string sort)
        {
            if (sort.IsNotNullOrEmpty())
                return sort.ToUpper();
            return QueryConstants.OrderByAscending;
        }

        //public static string Sort(this string query, string sort, string sortBy)
        //{
        //    if (sort.IsNotNullOrEmpty() && (sort.Equals("ASC", StringComparison.OrdinalIgnoreCase) || sort.Equals("DESC", StringComparison.OrdinalIgnoreCase)))
        //        return string.Format(query, sortBy, sort);
        //    return string.Format(query, sortBy, "asc");
        //}

        //public static string AndCondition(this string query, string key, string value)
        //{
        //    if (value.IsNotNullOrEmpty())
        //        query += query.Contains("WHERE") ? string.Format(" AND {0} = '{1}'", key, value) : string.Format(" WHERE {0} = '{1}'", key, value);
        //    return query;
        //}

        //public static string AndCondition(this string query, string key, int value)
        //{
        //    if (value.IsGreaterThanZero())
        //        query = query.AndCondition(key, value.ToString());
        //    return query;
        //}

        //public static string TrueCondition(this string query, string key, bool onlyTrue)
        //{
        //    if (onlyTrue)
        //        query = query.AndCondition(key, "1");
        //    return query;
        //}

        //public static string FalseCondition(this string query, string key, bool onlyFalse)
        //{
        //    if (onlyFalse)
        //        query = query.AndCondition(key, "0");
        //    return query;
        //}

        //public static string LikeCondition(this string query, string key, string value)
        //{
        //    if (value.IsNotNullOrEmpty())
        //        query += query.Contains("WHERE") ? string.Format(" AND UPPER({0}) LIKE '%{1}%'", key, value) : string.Format(" WHERE UPPER({0}) LIKE '%{1}%'", key, value);
        //    return query;
        //}

        //public static string IsNullCondition(this string query, string key, bool applyCondition)
        //{
        //    if (applyCondition)
        //        query += query.Contains("WHERE") ? string.Format(" AND ({0} IS NULL OR {0} = '')", key) : string.Format(" WHERE ({0} IS NULL OR {0} = '')", key);
        //    return query;
        //}

        //public static string IsNotNullCondition(this string query, string key, bool applyCondition)
        //{
        //    if (applyCondition)
        //        query += query.Contains("WHERE") ? string.Format(" AND ({0} IS NOT NULL OR {0} != '')", key) : string.Format(" WHERE ({0} IS NOT NULL OR {0} != '')", key);
        //    return query;
        //}

        //public static string BetweenDateCondition(this string query, string key, string firstValue, string secondValue)
        //{
        //    if (firstValue.IsNotNullOrEmpty() && secondValue.IsNotNullOrEmpty())
        //        query += query.Contains("WHERE") ? string.Format(" AND CONVERT(DATE,{0},103) between CONVERT(DATE,'{1}',103) AND CONVERT(DATE,'{2}',103)", key, firstValue, secondValue) : string.Format(" WHERE CONVERT(DATE,{0},103) between CONVERT(DATE,'{1}',103) AND CONVERT(DATE,'{2}',103)", key, firstValue, secondValue);
        //    return query;
        //}

        //public static string Paginate(this string query, int startPage, int endPage, string fieldsToPaginate)
        //{
        //    if (startPage.IsGreaterThanZero() && endPage.IsGreaterThanZero())
        //    {
        //        query = string.Format("SELECT {0} FROM ( {1} {2}" , fieldsToPaginate, query, ") seq WHERE seq.rownum BETWEEN {0} AND {1}");
        //        return string.Format(query, startPage, endPage);
        //    }
        //    return query;
        //}

        //public static string Paginate(this string query, int startPage, int endPage)
        //{
        //    if (startPage.IsGreaterThanZero() && endPage.IsGreaterThanZero())
        //    {
        //        query = string.Format("SELECT * FROM ( {0} {1}", query, ") seq WHERE seq.rownum BETWEEN {0} AND {1}");
        //        return string.Format(query, startPage, endPage);
        //    }
        //    return query;
        //}

        //public static string SortByResolver<T>(this string sortBy, Dictionary<string, string> dictionary)
        //{
        //    var checkProperty = Validate<T>.Property(sortBy);
        //    if (checkProperty)
        //        return dictionary[sortBy.ToLower()];
        //    return dictionary.Select(dic => dic.Value).First();
        //}

        public static string SortByResolver<T>(this string sortBy)
        {
            var checkProperty = Validate<T>.Property(sortBy);
            if (checkProperty)
                return sortBy;
            return typeof(T).GetProperties().First().Name;
        }

        private static string PropertyNameResolver<T>(string property)
        {
            if (property.IsNullOrEmpty())
                return typeof(T).GetProperties().First().Name;

            var propertyToValidate = property.Split(PropertyAndChildSeparator);
            var checkProperty = Validate<T>.Property(propertyToValidate[0]);
            if (checkProperty.Equals(false))
                return typeof(T).GetProperties().First().Name;
            
            var isChild = property.Contains(PropertyAndChildSeparator);
            if (isChild)
            {
                var parentClass = typeof(T);
                var childClass = parentClass.GetProperties().First(prop => prop.Name.Equals(propertyToValidate[0], StringComparison.OrdinalIgnoreCase));
                var childClassProperty = childClass.PropertyType.GetProperties().FirstOrDefault(prop => prop.Name.Equals(propertyToValidate[1], StringComparison.OrdinalIgnoreCase));
                if (childClassProperty.IsNull())
                    return typeof(T).GetProperties().First().Name;
            }

            return property;
        }

        private static Type PropertyTypeResolver<T>(string property)
        {
            var propertyToRetrieve = property.Split(PropertyAndChildSeparator);
            var parentClass = typeof(T);
            var parentProperty = parentClass.GetProperties().First(prop => prop.Name.Equals(propertyToRetrieve[0], StringComparison.OrdinalIgnoreCase));
            var propertyType = parentProperty.PropertyType;

            var isChild = property.Contains(PropertyAndChildSeparator);
            if (isChild)
            {
                var childClassProperty = propertyType.GetProperties().First(prop => prop.Name.Equals(propertyToRetrieve[1], StringComparison.OrdinalIgnoreCase));
                return childClassProperty.PropertyType;
            }

            return propertyType;
        }

        public static IQueryable<T> SortByPropertyResolver<T>(string sort, string sortBy, IQueryable<T> query) where T : class
        {
            sort = sort.SortResolver();
            sortBy = PropertyNameResolver<T>(sortBy);
            var propertyType = PropertyTypeResolver<T>(sortBy);

            if (propertyType == typeof(string))
                return Translation<T>.SortByType<string>(sort, sortBy, query);

            if (propertyType == typeof(int))
                return Translation<T>.SortByType<int>(sort, sortBy, query);

            if (propertyType == typeof(DateTime))
                return Translation<T>.SortByType<DateTime>(sort, sortBy, query);

            if (propertyType == typeof(decimal))
                return Translation<T>.SortByType<decimal>(sort, sortBy, query);

            if (propertyType == typeof(bool))
                return Translation<T>.SortByType<bool>(sort, sortBy, query);

            if (propertyType.BaseType == typeof(Enum))
                return Translation<T>.SortByType<Enum>(sort, sortBy, query);

            return null;
        }

        public static IQueryable<T> PaginationResolver<T>(int itemsToShow, int page, IQueryable<T> query)
        {
            if (itemsToShow.IsNotZero() && page.IsNotZero())
                return query.Skip(itemsToShow * (page - NumberOfPagesToSubtract)).Take(itemsToShow);
            return query;
        }

        //public static string InCondition(this string query, string key, string values)
        //{
        //    if (values.IsNotNullOrEmpty())
        //        query += query.Contains("WHERE") ? string.Format(" AND {0} in ({1})", key, values) : string.Format(" WHERE {0} in ({1})", key, values);
        //    return query;
        //}
        
        //public static string SelectOnlyField(string table, string field)
        //{
        //    return string.Format("SELECT {0} from {1}", field, table);
        //}
        
        public static Expression<Func<T, bool>> DeleteMiddleLambdaResolver<T>(this T entityToDelete) where T : class
        {
            return Translation<T>.MiddleEntityLambdaExpression(entityToDelete);
        }
    }
}