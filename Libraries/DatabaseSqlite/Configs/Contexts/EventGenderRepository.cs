using System;
using System.Linq;

namespace DatabaseSqlite.Configs.Contexts {
    public class EventGenderRepository<T> : IEventGenderRepository<T> {
        private readonly GenderContext _context;
        public EventGenderRepository(GenderContext context) {
            _context = context;
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<T> GetList(IQueryable<T> query) {
            throw new NotImplementedException();
        }

        public T GetDetail(long id) {
            throw new NotImplementedException();
        }
    }
}
