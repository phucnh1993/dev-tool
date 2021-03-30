using DevTool.Services.DatabaseConnect.Sqlite;
using Services.DatabaseConnect.Sqlite.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DevTool {
    static class Program {
        static void CreateDataDirectory() {
            DirectoryInfo di = new DirectoryInfo("data");
            if (!di.Exists) {
                di.Create();
            }
        }

        static void Migration<T>() {
            var query = AttributeParse.EntityToTable<T>();
            var con = SqliteConnectionService.CreateConnection();
            try {
                var chk = SqliteConnectionService.Execute(con, query);
                con.Close();
            } catch (Exception ex) {
                var tableName = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
                MessageBox.Show(ex.Message, string.Format("Create table {0} is error", tableName.Name));
                con.Close();
            }
        }

        [STAThread]
        static void Main() {
            CreateDataDirectory();
            var databaseRoot = Properties.Settings.Default.DatabaseRoot;
            if (!File.Exists(databaseRoot)) {
                SQLiteConnection.CreateFile(databaseRoot);
                Migration<Language>();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuTool());
        }
    }
}
