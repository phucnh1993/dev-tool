using System;

namespace DevTool.Tools.LanguageCodeManager {
    public class LanguageCode {
        public long Id { get; set; }
        public string Name { get; set; }
        public string VersionNow { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActivated { get; set; }
        public string Description { get; set; }

        public string CreateData() {
            string result = "INSERT INTO {0} (name, description, version, created_on, is_activated) " +
                "VALUES ('{1}', '{2}', '{3}', '{4}', {5})";
            return string.Format(result, DefineValue.TableName, Name, Description, VersionNow, CreatedOn.ToString("yyyy-MM-dd HH:mm:ss"), IsActivated ? 1 : 0);
        }

        public string UpdateData() {
            string result = "UPDATE {0} SET " +
                "name = '{1}', description = '{2}', version = '{3}', " +
                "is_activated = {4} WHERE id = {5}";
            return string.Format(result, DefineValue.TableName, Name, Description, VersionNow, IsActivated, Id);
        }
    }
}
