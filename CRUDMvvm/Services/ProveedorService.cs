
using SQLite;

namespace CRUDMvvm.Services
{
    class ProveedorService
    {
        private readonly SQLiteConnection _connection;

        public ProveedorService() {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Proveedor.db3");
        }
    }
}
