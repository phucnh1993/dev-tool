namespace DevTool.Tools.LanguageCodeManager {
    public class DefineValue {
        public const string DatabaseName = "data/gender";
        public const string TableName = "Languages";
        public const string QueryStringList = "SELECT id, name, description, version, created_on, is_activated " +
            "FROM {0} LIMIT {1} OFFSET {2};";
        public const string QueryStringCount = "SELECT COUNT(id) AS count FROM {0};";
    }
}
