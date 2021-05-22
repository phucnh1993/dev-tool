using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Duolingo.Services {
    public static class FileService {
        public static bool WriteNewFile(string fileName, string data) {
            try {
                using (var sw = new StreamWriter(new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write), Encoding.UTF8)) {
                    sw.WriteLine(data);
                    sw.Flush();
                    sw.Close();
                }
            } catch(Exception ex) {
                MessageBox.Show(ex.Message, "Lỗi tạo mới file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
