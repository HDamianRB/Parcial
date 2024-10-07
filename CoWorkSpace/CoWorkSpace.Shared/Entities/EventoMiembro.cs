using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoWorkSpace.Shared.Entities
{
    public class EventoMiembro
    {
        public int Id { get; set; }

        public int EventoId { get; set; }
        [JsonIgnore]
        public Evento Evento { get; set; }

        public int MiembroId { get; set; }
        [JsonIgnore]
        public Miembro Miembro { get; set; }

        [Display(Name = "Confirmado")]
        public bool Confirmado { get; set; } = false;
    }
}
