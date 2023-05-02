using System.ComponentModel.DataAnnotations;

namespace Practico2HDP.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CUIT { get; set; }

    }
}
