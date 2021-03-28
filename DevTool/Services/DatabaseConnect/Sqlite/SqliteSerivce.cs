using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DevTool.Services.DatabaseConnect.Sqlite {
    public class SqliteSerivce {
        public static bool CheckTableExist(string database, string tableName) {
            string query = string.Format(DefineSql.QueryCheckTable, tableName);
            var con = SqliteConnectionController.CreateConnection(database);
            try {
                SQLiteCommand command = con.CreateCommand();
                command.CommandText = query;
                SQLiteDataReader reader = command.ExecuteReader();
                var chk = reader.HasRows;
                con.Close();
                return chk;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Check table is exist error");
                con.Close();
                return false;
            }
        }

        public static bool CreateTable(string database, string tableName, string columnInfo) {
            string query = string.Format(DefineSql.QueryCreateTable, tableName, columnInfo);
            var con = SqliteConnectionController.CreateConnection(database);
            try {
                var chk = SqliteConnectionController.Execute(con, query);
                con.Close();
                return chk;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Create table is error");
                con.Close();
                return false;
            }
        }
    }
}
