using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DevTool.Services.DatabaseConnect.Sqlite {
    public class AttributeParse {
        public static string UpdateObject<T>(T data) {
            string result = "UPDATE {0}.{1} SET ";
            var tableName = data.GetType().GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
            result = string.Format(result, tableName.Schema, tableName.Name);
            var properties = data.GetType().GetProperties().ToList();
            var index = properties.Count;
            foreach (var pro in properties) {
                string columnInfo = "";
                var colType = pro.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault() as ColumnAttribute;
                if (colType != null) {
                    columnInfo += colType.Name + " = ";
                    if (colType.TypeName.ToUpper().Contains("TEXT")) {
                        columnInfo += "'" + pro.GetValue(data, null) + "'";
                    } else {
                        columnInfo += pro.GetValue(data, null);
                    }
                } else {
                    columnInfo += pro.Name + " = ";
                    var type = pro.PropertyType.GetType();
                    if (type == typeof(String) || type == typeof(DateTime) || type == typeof(Char)
                        || type == typeof(Decimal) || type == typeof(DateTimeOffset) || type == typeof(Guid)
                        || type == typeof(TimeSpan) || type == typeof(System.Array)) {
                        columnInfo += "'" + pro.GetValue(data, null) + "'";
                    } else {
                        columnInfo += pro.GetValue(data, null);
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
                    if (type == typeof(Int16) || type == typeof(Int32) || type == typeof(Int64)
                        || type == typeof(UInt16) || type == typeof(UInt32) || type == typeof(UInt64)
                        || type == typeof(Boolean) || type == typeof(Byte) || type == typeof(SByte)) {
                        columnInfo += "INTEGER";
                    }
                    if (type == typeof(String) || type == typeof(DateTime) || type == typeof(Char)
                        || type == typeof(Decimal) || type == typeof(DateTimeOffset) || type == typeof(Guid)
                        || type == typeof(TimeSpan)) {
                        columnInfo += "TEXT";
                    }
                    if (type == typeof(Single) || type == typeof(Double)) {
                        columnInfo += "REAL";
                    }
                    if (type == typeof(Array)) {
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
