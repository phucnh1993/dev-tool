using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DevTool.Services.DatabaseConnect.Sqlite {
    public class SqliteConnectionService {
        public static SQLiteConnection CreateConnection() {
            SQLiteConnection conn = new SQLiteConnection(Properties.Settings.Default.ConnectionDatabase);
            try {
                conn.Open();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error open connection SQLITE");
            }
            return conn;
        }

        public static bool Execute(SQLiteConnection connection, string queryString) {
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = queryString;
            var chk = command.ExecuteNonQuery();
            connection.Close();
            return chk != -1;
        }

        public static T ReaderDataParse<T>(T instance, SQLiteDataReader reader) {
            Type type = typeof(T);
            PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance);
            int index = -1;
            foreach (PropertyInfo info in props) {
                index++;
                if (info.PropertyType == typeof(DateTime)) {
                    info.SetValue(instance, DateTime.Parse(reader.GetString(index)), null);
                    continue;
                }
                if (info.PropertyType == typeof(Boolean)) {
                    info.SetValue(instance, reader.GetInt16(index) > 0 ? true : false, null);
                    continue;
                }
                if (info.PropertyType == typeof(String)) {
                    info.SetValue(instance, reader.GetString(index), null);
                    continue;
                }
                if (info.PropertyType == typeof(Decimal)) {
                    info.SetValue(instance, reader.GetDecimal(index), null);
                    continue;
                }
                if (info.PropertyType == typeof(Double)) {
                    info.SetValue(instance, reader.GetDouble(index), null);
                    continue;
                }
                if (info.PropertyType == typeof(Guid)) {
                    info.SetValue(instance, Guid.Parse(reader.GetString(index)), null);
                    continue;
                }
                if (info.PropertyType == typeof(Int16)) {
                    info.SetValue(instance, reader.GetInt16(index), null);
                    continue;
                }
                if (info.PropertyType == typeof(Int32)) {
                    info.SetValue(instance, reader.GetInt32(index), null);

                    continue;
                }
                info.SetValue(instance, reader.GetInt64(index), null);
            }
            return instance;
        }

        public static List<T> Query<T>(SQLiteConnection connection, string queryString) {
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = queryString;
            List<T> result = new List<T>();
            try {
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        T data = (T) Activator.CreateInstance(typeof(T), new object[] { });
                        var obj = ReaderDataParse<T>(data, reader);
                        result.Add(obj);
                    }
                }
                connection.Close();
                return result;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Query database error");
                connection.Close();
                return result;
            }
        }

        public static int Count<T>(SQLiteConnection connection) {
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = AttributeParse.EntityCount<T>();
            int result = 0;
            try {
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows) {
                    reader.Read();
                    result = reader.GetInt32(0);
                }
                connection.Close();
                return result;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Query database error");
                connection.Close();
                return result;
            }
        }

        public static List<JObject> Query(SQLiteConnection connection, string queryString) {
            List<JObject> result = new List<JObject>();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = queryString;
            try {
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        JObject obj = new JObject();
                        for (var i = 0; i < reader.FieldCount; i++) {
                            var name = reader.GetName(i);
                            Type dataType = reader.GetFieldType(i);
                            switch (dataType.Name) {
                                case "Int64": {
                                    obj.Add(name, reader.GetInt64(i));
                                    break;
                                }
                                case "Int32": {
                                    obj.Add(name, reader.GetInt32(i));
                                    break;
                                }
                                case "Int16": {
                                    obj.Add(name, reader.GetInt16(i));
                                    break;
                                }
                                case "String": {
                                    obj.Add(name, reader.GetString(i));
                                    break;
                                }
                                case "Double": {
                                    obj.Add(name, reader.GetDouble(i));
                                    break;
                                }
                                case "Decimal": {
                                    obj.Add(name, reader.GetDecimal(i));
                                    break;
                                }
                                case "Boolean": {
                                    obj.Add(name, reader.GetBoolean(i));
                                    break;
                                }
                                default: {
                                    obj.Add(name, reader.GetValue(i).ToString());
                                    break;
                                }
                            }
                        }
                        result.Add(obj);
                    }
                }
                connection.Close();
                return result;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Query database error");
                connection.Close();
                return result;
            }
        }
    }
}
