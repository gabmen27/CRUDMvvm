
using CRUDMvvm.Models;
using SQLite;

namespace CRUDMvvm.Services
{
    class ProveedorService
    {
        private readonly SQLiteConnection _connection;

        //Constructor
        public ProveedorService() {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Proveedor.db3");
            //Initialize connection and data base was created
            _connection = new SQLiteConnection(dbPath);

            _connection.CreateTable<Proveedor>();
        }

        public List<Proveedor> GetAll() 
        {
            return _connection.Table<Proveedor>().ToList();
        }

        public int Insert(Proveedor Proveedor) {
            return _connection.Insert(Proveedor);
        }

        public int Update(Proveedor Proveedor) {
            return _connection.Update(Proveedor);
        }

        public int Delete(Proveedor Proveedor) {
            return _connection.Delete(Proveedor);
        }
    }
}
