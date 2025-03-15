

using SQLite;

namespace CRUDMvvm.Models
{
    public class Proveedor
    {
        [PrimaryKey]
        public int id { get; set; }
        [NotNull]
        public string Nombre { get; set; }
        public string Direeccion { get; set; }
        public string numTelefono { get; set; }
        public string mail { get; set; }

        if


    }
}
