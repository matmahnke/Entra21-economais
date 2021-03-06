﻿using DTO;
using DTO.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure
{
    public class SqlGenerator<T> where T : Entity
    {
        private static string GetTableName<T>()
        {
            return
            typeof(T).GetCustomAttribute<TableName>().Text;
        }

        #region Insert
        public static SqlCommand BuildInsertCommand(T item)
        {
            StringBuilder comando = new StringBuilder();
            comando.AppendFormat("INSERT INTO {0} ({1}) VALUES ({2})", GetTableName<T>(), GetInsertFields<T>(false), GetInsertFields<T>(true));
            SqlCommand command = new SqlCommand();
            command.CommandText = comando.ToString();
            GenerateInsertParameters(command, item);
            return command;
        }
        private static void GenerateInsertParameters(SqlCommand command, T item)
        {
            foreach (PropertyInfo propriedade in typeof(T).GetProperties())
            {
                if (propriedade.Name != "ID")
                {
                    command.Parameters.AddWithValue("@" + propriedade.Name, propriedade.GetValue(item));
                }
            }
        }
        private static string GetInsertFields<T>(bool isParameters)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in typeof(T).GetProperties())
            {
                if (item.Name != "ID")
                {
                    if (isParameters)
                    {
                        builder.Append("@" + item.Name + ",");
                    }
                    else
                    {
                        builder.Append(item.Name + ",");
                    }
                }
            }
            builder = builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }
        #endregion

        #region Update
        public static SqlCommand BuildUpdateCommand(T item)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("UPDATE {0} SET {1} WHERE ID = @ID", GetTableName<T>(), GetUpdateFields<T>());
            SqlCommand command = new SqlCommand();
            command.CommandText = builder.ToString();
            GenerateUpdateParameters(command, item);
            return command;
        }

        private static string GetUpdateFields<T>()
        {
            StringBuilder builder = new StringBuilder();
            foreach (PropertyInfo item in typeof(T).GetProperties())
            {
                if (item.GetCustomAttribute<NonEditable>() == null)
                {
                    builder.Append(item.Name + " = @" + item.Name + ",");
                }
            }
            return builder.ToString(0, builder.Length - 1);
        }
        #endregion

        #region Delete
        private static void GenerateUpdateParameters(SqlCommand command, T item)
        {
            foreach (PropertyInfo propriedade in typeof(T).GetProperties())
            {
                if (propriedade.GetCustomAttribute<NonEditable>() == null)
                {
                    command.Parameters.AddWithValue
                        ("@" + propriedade.Name, propriedade.GetValue(item));
                }
            }
            command.Parameters.AddWithValue("@ID", item.ID);
        }

        public static SqlCommand BuildDeleteCommand(T item)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = string.Format("DELETE FROM {0} WHERE ID = @ID", GetTableName<T>());
            command.Parameters.AddWithValue("@ID", item.ID);
            return command;
        }
        #endregion

    }
}
