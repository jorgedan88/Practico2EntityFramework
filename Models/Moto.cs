using System.ComponentModel.DataAnnotations;

namespace Practico2HDP.Models
{
    public class Moto
    {
        public int MotoID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public string Color { get; set; }

    }
}
