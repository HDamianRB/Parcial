using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoWorkSpace.Shared.Entities
{
    public class Recurso
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del recurso")]
        [MaxLength(50, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "¡Este campo es obligatorio!")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción del recurso")]
        public string Descripcion { get; set; }

        public int EspacioTrabajoId { get; set; }
        [JsonIgnore]
        public EspacioTrabajo EspacioTrabajo { get; set; }
    }
}

