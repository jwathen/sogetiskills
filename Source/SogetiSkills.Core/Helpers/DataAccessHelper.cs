﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SogetiSkills.Core.Helpers
{
    /// <summary>
    /// Container class for helpers functions relating to reading data back from a database.
    /// </summary>
    public static class DataAccessHelper
    {
        /// <summary>
        /// Casts a value returned from the database to T. DBNull.Value is returned as default(T).
        /// </summary>
        /// <typeparam name="T">The type to cast to.</typeparam>
        /// <param name="value">The value returned from the database that needs to be casted.</param>
        /// <returns>The value casted to T or default(T) if the value was null or DBNull.Value.</returns>
        public static T CastTo<T>(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return default(T);
            }
            else
            {
                return (T)value;
            }
        }

        /// <summary>
        /// Reads a value from a SqlDataReader and cast it to T.  DBNull.Value is returned as default(T).
        /// </summary>
        /// <typeparam name="T">The type to cast to.</typeparam>
        /// <param name="reader">The data reader to read from.</param>
        /// <param name="columnName">The name of the column to read from.</param>
        /// <returns>The value casted to T or default(T) if the value was null or DBNull.Value. </returns>
        public static T Field<T>(this SqlDataReader reader, string columnName)
        {
            object columnValue = reader[columnName];
            return CastTo<T>(columnValue);
        }

        /// <summary>
        /// Returns either the value passed in or DBNull.Value if the value was null.  SQL Server will throw saying that
        /// a parameter is missing if CLR null is sent is for the parameter value.  Instead we need to send in DBNull.Value.
        /// </summary>
        /// <param name="value">The value that is going to be used as a database parameter.</param>
        /// <returns>The value or DBNull.Value.</returns>
        public static object ValueOrDBNull(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }
    }
}
