using Duolingo.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Duolingo.Services {
    public static class HistoryService {
        public static bool CreateOrCheckHistory() {
            var now = DateTime.Now;
            try {
                using (var db = new DuoContext()) {
                    var chk = db.Histories.AsNoTracking().Any(x => x.CreatedDate.Date == now.Date);
                    if (chk) {
                        return true;
                    }
                    var his = new History() { CreatedDate = now };
                    db.Histories.Add(his);
                    db.SaveChanges();
                    return true;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Function " + typeof(HistoryService).Name);
                return false;
            }
            
        }
    }
}
