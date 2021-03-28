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

        [STAThread]
        static void Main() {
            CreateDataDirectory();
            var databaseRoot = Properties.Settings.Default.DatabaseRoot;

            if (!File.Exists(databaseRoot)) {
                SQLiteConnection.CreateFile(databaseRoot);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuTool());
        }
    }
}
