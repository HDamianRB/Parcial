using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoWorkSpace.Shared.Entities
{
    public class Evento
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del evento")]
        [MaxLength(100, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "¡Este campo es obligatorio!")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción del evento")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha del evento")]
        [Required(ErrorMessage = "¡Este campo es obligatorio!")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Hora de inicio")]
        [Required(ErrorMessage = "¡Este campo es obligatorio!")]
        public TimeSpan HoraInicio { get; set; }

        [Display(Name = "Hora de fin")]
        [Required(ErrorMessage = "¡Este campo es obligatorio!")]
        public TimeSpan HoraFin { get; set; }

        public int EspacioTrabajoId { get; set; }
        [JsonIgnore]
        public EspacioTrabajo EspacioTrabajo { get; set; }

        public int EventoMiembroId { get; set; }
        [JsonIgnore]
        public ICollection<EventoMiembro> EventoMiembros { get; set; }
    }
}
