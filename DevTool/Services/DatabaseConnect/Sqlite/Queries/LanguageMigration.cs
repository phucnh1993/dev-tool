namespace DevTool.Services.DatabaseConnect.Sqlite.Queries {
    public class LanguageMigration {
        public const string NameTable = "gender.Languages";
        public const string CreateTable = "Id INTEGER PRIMARY KEY, " +
                                            "Name TEXT(100) NOT NULL, " +
                                            "Version TEXT(20) NULL, " +
                                            "CreatedOn TEXT(30) NOT NULL, " +
                                            "UpdatedOn TEXT(30) NOT NULL, " +
                                            "IsActivated TEXT(1) NOT NULL, " +
                                            "Description TEXT(500) NULL, ";
        public const string UpdateData = "UPDATE {0} SET " +
                                        "Name = '{1}', Description = '{2}', Version = '{3}', " +
                                        "UpdatedOn = {4}, IsActivated = '{5}' WHERE id = {5}";
    }
}
