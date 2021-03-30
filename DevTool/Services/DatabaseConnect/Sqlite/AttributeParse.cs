using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DevTool.Services.DatabaseConnect.Sqlite {
    public class AttributeParse {
        public static string EntityToUpdate<T>(T data) {
            string result = "UPDATE {0}.{1} SET ";
            var tableName = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
            result = string.Format(result, tableName.Schema, tableName.Name);
            var properties = typeof(T).GetProperties().ToList();
            var index = properties.Count;
            foreach (var pro in properties) {
                string columnInfo = "";
                var colType = pro.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault() as ColumnAttribute;
                if (colType != null) {
                    columnInfo += colType.Name + " = ";
                    if (colType.TypeName.ToUpper().Contains("TEXT")) {
                        columnInfo += "'" + pro.GetValue(data, null) + "'";
                    }
                } else {
                    columnInfo += pro.Name + " = ";
                    var type = pro.PropertyType.GetType();
                    if (type == typeof(System.Int16) || type == typeof(System.Int32) || type == typeof(System.Int64)
                        || type == typeof(System.UInt16) || type == typeof(System.UInt32) || type == typeof(System.UInt64)
                        || type == typeof(System.Boolean) || type == typeof(System.Byte) || type == typeof(System.SByte)) {
                        columnInfo += "INTEGER";
                    }
                    if (type == typeof(System.String) || type == typeof(System.DateTime) || type == typeof(System.Char)
                        || type == typeof(System.Decimal) || type == typeof(System.DateTimeOffset) || type == typeof(System.Guid)
                        || type == typeof(System.TimeSpan)) {
                        columnInfo += "TEXT";
                    }
                    if (type == typeof(System.Single) || type == typeof(System.Double)) {
                        columnInfo += "REAL";
                    }
                    if (type == typeof(System.Array)) {
                        columnInfo += "BLOB";
                    }
                }
                index--;
                if (index > 0) {
                    columnInfo += ", ";
                }
                result += columnInfo;
            }
            return result;
        }

        public static string EntityToTable<T>() {
            string result = "CREATE TABLE IF NOT EXISTS {0}.{1} ";
            var tableName = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
            result = string.Format(result, tableName.Schema, tableName.Name);
            var properties = typeof(T).GetProperties().ToList();
            var index = properties.Count;
            result += "(";
            foreach (var pro in properties) {
                string columnInfo = "";
                var colType = pro.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault() as ColumnAttribute;
                if (colType != null) {
                    columnInfo += colType.Name + " " + colType.TypeName;
                } else {
                    columnInfo += pro.Name + " ";
                    var type = pro.PropertyType.GetType();
                    if (type == typeof(System.Int16) || type == typeof(System.Int32) || type == typeof(System.Int64)
                        || type == typeof(System.UInt16) || type == typeof(System.UInt32) || type == typeof(System.UInt64)
                        || type == typeof(System.Boolean) || type == typeof(System.Byte) || type == typeof(System.SByte)) {
                        columnInfo += "INTEGER";
                    }
                    if (type == typeof(System.String) || type == typeof(System.DateTime) || type == typeof(System.Char)
                        || type == typeof(System.Decimal) || type == typeof(System.DateTimeOffset) || type == typeof(System.Guid)
                        || type == typeof(System.TimeSpan)) {
                        columnInfo += "TEXT";
                    }
                    if (type == typeof(System.Single) || type == typeof(System.Double)) {
                        columnInfo += "REAL";
                    }
                    if (type == typeof(System.Array)) {
                        columnInfo += "BLOB";
                    }
                }
                var require = pro.GetCustomAttributes(typeof(RequiredAttribute), true).FirstOrDefault() as RequiredAttribute;
                if (require != null) {
                    columnInfo += " NOT NULL";
                }
                var key = pro.GetCustomAttributes(typeof(KeyAttribute), true).FirstOrDefault() as KeyAttribute;
                if (key != null) {
                    columnInfo += " PRIMARY KEY";
                }
                var gen = pro.GetCustomAttributes(typeof(DatabaseGeneratedAttribute), true).FirstOrDefault() as DatabaseGeneratedAttribute;
                if (gen != null) {
                    columnInfo += " AUTOINCREMENT";
                }
                index--;
                if (index > 0) {
                    columnInfo += ", ";
                }
                result += columnInfo;
            }
            result += ")";
            return result;
        }
    }
}
