using System.ComponentModel.DataAnnotations;
namespace Tp2Ef.Models
{
    public class Concesionario
    {
                public int ConcesionarioID { get; set; }

        [Display(Name = "Nombre comercial")]
        public string NombreComercial { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        public string Tel { get; set; }
    }
}