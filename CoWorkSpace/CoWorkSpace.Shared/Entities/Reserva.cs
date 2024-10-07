using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoWorkSpace.Shared.Entities
{
    public class Reserva
    {
        public int Id { get; set; }

        public int MiembroId { get; set; }
        [JsonIgnore]
        public Miembro Miembro { get; set; }
        public int EspacioTrabajoId { get; set; }
        [JsonIgnore]
        public EspacioTrabajo EspacioTrabajo { get; set; }

        [Display(Name = "Fecha de la reserva")]
        [Required(ErrorMessage = "¡Este campo es obligatorio!")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Hora de inicio")]
        [Required(ErrorMessage = "¡Este campo es obligatorio!")]
        public TimeSpan HoraInicio { get; set; }

        [Display(Name = "Hora de fin")]
        [Required(ErrorMessage = "¡Este campo es obligatorio!")]
        public TimeSpan HoraFin { get; set; }

        public int RecursoId { get; set; }
        [JsonIgnore]
        public ICollection<Recurso> Recursos { get; set; }
    }
}