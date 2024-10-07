using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoWorkSpace.Shared.Entities
{
    public class Membresia
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la membresía")]
        [MaxLength(50, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "¡Este campo es obligatorio!")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción de la membresía")]
        public string Descripcion { get; set; }

        [Display(Name = "Beneficios")]
        public string Beneficios { get; set; }

        public int MiembroId { get; set; }
        [JsonIgnore]
        public ICollection<Miembro> Miembros { get; set; }
    }
}

