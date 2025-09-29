using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Shared.Entidad
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreCompleto { get; set; } = null!;
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string FechaNac { get; set; }= null!;
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string LugarNac { get; set; } = null!;
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string EstadoCivil { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Profesion { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Domicilio { get; set; } = null!;
    }
}
