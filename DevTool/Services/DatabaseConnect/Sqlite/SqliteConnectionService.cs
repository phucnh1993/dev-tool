using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
