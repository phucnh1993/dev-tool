using DevTool.Services.DatabaseConnect.Sqlite;
using Services.DatabaseConnect.Sqlite.Entities;
using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace DevTool {
    static class Program {
        static void CreateDataDirectory() {
            DirectoryInfo di = new DirectoryInfo("data");
            if (!di.Exists) {
                di.Create();
            }
        }

        static void Migration() {
            AttributeParse.EntityToTable<Language>();
            AttributeParse.UpdateObject<Language>(new Language() { Id = 1, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
        }

        [STAThread]
        static void Main() {
            CreateDataDirectory();
            var databaseRoot = Properties.Settings.Default.DatabaseRoot;

            if (!File.Exists(databaseRoot)) {
                SQLiteConnection.CreateFile(databaseRoot);
                Migration();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuTool());
        }
    }
}
