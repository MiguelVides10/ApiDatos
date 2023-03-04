using System.ComponentModel.DataAnnotations;

namespace ApiDatos.Models
{
    public class Listas
    {
        [Key]
        public int Idlista { get; set; }
        public string Codigolista { get; set; }
        public string Fechacompra { get; set; }
        public string Supermercado { get; set; }
        public string Producto { get; set; }
        public int Precio { get; set; }

    }
}
