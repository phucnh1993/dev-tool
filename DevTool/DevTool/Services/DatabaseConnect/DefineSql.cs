namespace DevTool.Services.DatabaseConnect {
    public static class DefineSql {
        public const string QueryCheckTable = "SELECT name FROM sqlite_master WHERE type='table' AND name='{0}' LIMIT 1;";
        public const string QueryCreateTable = "CREATE TABLE IF NOT EXISTS {0} ({1});";
    }
}
