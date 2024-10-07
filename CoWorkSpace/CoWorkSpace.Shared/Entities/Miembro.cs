using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoWorkSpace.Shared.Entities
{
    public class Miembro
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del miembro")]
        [MaxLength(100, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "¡Este campo es obligatorio!")]
        public string Nombre { get; set; }

        [Display(Name = "Correo electrónico")]
        [MaxLength(100, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "¡Este campo es obligatorio!")]
        [EmailAddress(ErrorMessage = "Debe ser un correo electrónico válido")]
        public string Email { get; set; }

        [Display(Name = "Teléfono")]
        [MaxLength(15, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        public string Telefono { get; set; }

        public int MembresiaId { get; set; }
        [JsonIgnore]
        public Membresia Membresia { get; set; }
        public int ReservaId { get; set; }
        [JsonIgnore]
        public ICollection<Reserva> Reservas { get; set; }
        public int EventoMiembroId { get; set; }
        [JsonIgnore]
        public ICollection<EventoMiembro> EventosMiembros { get; set; }
    }
}

