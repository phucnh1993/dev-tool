using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DevTool.Services.DatabaseConnect.Sqlite {
    public class AttributeParse {
        public static string EntityCount<T>() {
            string result = "SELECT COUNT({0}) FROM {1}";
            var tableName = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
            var properties = typeof(T).GetProperties().ToList();
            var columnId = "";
            var key = properties[0].GetCustomAttributes(typeof(KeyAttribute), true).FirstOrDefault() as KeyAttribute;
            if (key != null) {
                var colType = properties[0].GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault() as ColumnAttribute;
                columnId = colType.Name;
            } else {
                columnId += properties[0].Name;
            }
            result = string.Format(result, columnId, tableName.Name);
            return result;
        }

        public static string EntityToList<T>(int offset, int limit) {
            string result = "SELECT {0} FROM {1} LIMIT {2} OFFSET {3}";
            var tableName = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
            var properties = typeof(T).GetProperties().ToList();
            var column = "";
            var index = properties.Count;
            foreach (var pro in properties) {
                var colType = pro.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault() as ColumnAttribute;
                if (colType != null) {
                    column += colType.Name;
                } else {
                    column += pro.Name;
                }
                index--;
                if (index > 0) {
                    column += ", ";
                }
            }
            result = string.Format(result, column, tableName.Name, limit, offset);
            return result;
        }

        public static string EntityToInserts<T>(List<T> data) {
            string result = "INSERT INTO {0}({1}) VALUES {2}";
            var tableName = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
            string column = "";
            var properties = typeof(T).GetProperties().ToList();
            var index = properties.Count;
            foreach (var pro in properties) {
                var colType = pro.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault() as ColumnAttribute;
                if (colType != null) {
                    column += colType.Name;
                } else {
                    column += pro.Name;
                }
                index--;
                if (index > 0) {
                    column += ", ";
                }
            }
            string values = "";
            var count = data.Count;
            foreach (var item in data) {
                index = properties.Count;
                string value = "(";
                foreach (var pro in properties) {
                    var colType = pro.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault() as ColumnAttribute;
                    if (colType != null) {
                        if (colType.TypeName.ToUpper().Contains("TEXT")) {
                            value += "'" + pro.GetValue(item, null) + "'";
                        } else {
                            var dataValue = pro.GetValue(data, null);
                            if (dataValue.ToString() == "True") {
                                values += 1;
                            } else if (dataValue.ToString() == "False") {
                                values += 0;
                            } else {
                                values += pro.GetValue(data, null);
                            }
                        }
                    } else {
                        var type = pro.PropertyType.GetType();
                        if (type == typeof(String) || type == typeof(DateTime) || type == typeof(Char)
                            || type == typeof(Decimal) || type == typeof(DateTimeOffset) || type == typeof(Guid)
                            || type == typeof(TimeSpan) || type == typeof(Array)) {
                            value += "'" + pro.GetValue(item, null) + "'";
                        } else if (type == typeof(Boolean)) {
                            values += pro.GetValue(data, null).ToString() == "True" ? 1 : 0;
                        } else {
                            value += pro.GetValue(item, null);
                        }
                    }
                    index--;
                    if (index > 0) {
                        value += ", ";
                    }
                }
                value += ")";
                values += value;
                count--;
                if (count > 0) {
                    values += ", ";
                }
            }
            result = string.Format(result, tableName.Name, column, values);
            return result;
        }

        public static string EntityToInsert<T>(T data) {
            string result = "INSERT INTO {0}({1}) VALUES ({2})";
            var tableName = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
            var properties = typeof(T).GetProperties().ToList();
            var index = properties.Count;
            string column = "";
            string values = "";
            foreach (var pro in properties) {
                var colType = pro.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault() as ColumnAttribute;
                if (colType != null) {
                    column += colType.Name;
                    if (colType.TypeName.ToUpper().Contains("TEXT")) {
                        values += "'" + pro.GetValue(data, null) + "'";
                    } else {
                        var dataValue = pro.GetValue(data, null);
                        if (dataValue.ToString() == "True") {
                            values += 1;
                        } else if (dataValue.ToString() == "False") {
                            values += 0;
                        } else {
                            values += pro.GetValue(data, null);
                        }
                    }
                } else {
                    column += pro.Name;
                    var type = pro.PropertyType.GetType();
                    if (type == typeof(String) || type == typeof(DateTime) || type == typeof(Char)
                        || type == typeof(Decimal) || type == typeof(DateTimeOffset) || type == typeof(Guid)
                        || type == typeof(TimeSpan) || type == typeof(Array)) {
                        values += "'" + pro.GetValue(data, null) + "'";
                    } else if (type == typeof(Boolean)) {
                        values += pro.GetValue(data, null).ToString() == "True" ? 1 : 0;
                    } else {
                        values += pro.GetValue(data, null);
                    }
                }
                index--;
                if (index > 0) {
                    column += ", ";
                    values += ", ";
                }
            }
            result = string.Format(result, tableName.Name, column, values);
            return result;
        }

        public static string EntityToUpdate<T>(T data) {
            string result = "UPDATE {0} SET ";
            var tableName = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
            result = string.Format(result, tableName.Name);
            var properties = typeof(T).GetProperties().ToList();
            var index = properties.Count;
            var whereData = " WHERE ";
            foreach (var pro in properties) {
                var key = pro.GetCustomAttributes(typeof(KeyAttribute), true).FirstOrDefault() as KeyAttribute;
                var colType = pro.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault() as ColumnAttribute;
                index--;
                if (key == null) {
                    string columnInfo = "";
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
                            || type == typeof(TimeSpan) || type == typeof(Array)) {
                            columnInfo += "'" + pro.GetValue(data, null) + "'";
                        } else {
                            columnInfo += pro.GetValue(data, null);
                        }
                    }
                    if (index > 0) {
                        columnInfo += ", ";
                    }
                    result += columnInfo;
                } else {
                    whereData += colType.Name + " = " + pro.GetValue(data, null); ;
                }
            }
            result += whereData;
            return result;
        }

        public static string EntityToTable<T>() {
            string result = "CREATE TABLE IF NOT EXISTS {0} ";
            var tableName = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
            result = string.Format(result, tableName.Name);
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
