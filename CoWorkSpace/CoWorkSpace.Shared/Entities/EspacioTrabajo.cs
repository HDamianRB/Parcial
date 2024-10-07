using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoWorkSpace.Shared.Entities
{
    public class EspacioTrabajo
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del espacio")]
        [MaxLength(100, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "¡Este campo es obligatorio!")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción del espacio")]
        public string Descripcion { get; set; }

        [Display(Name = "Capacidad máxima")]
        [Required(ErrorMessage = "¡Este campo es obligatorio!")]
        public int CapacidadMaxima { get; set; }

        public int ReservaId { get; set; }
        [JsonIgnore]
        public ICollection<Reserva> Reservas { get; set; }
        public int RecursoId { get; set; }
        [JsonIgnore]
        public ICollection<Recurso> Recursos { get; set; }
    }
}
