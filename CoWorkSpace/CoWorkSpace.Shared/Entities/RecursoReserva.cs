using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoWorkSpace.Shared.Entities
{
    public class RecursoReserva
    {
        public int Id { get; set; }

        public int ReservaId { get; set; }
        [JsonIgnore]
        public Reserva Reserva { get; set; }
        public int RecursoId { get; set; }
        [JsonIgnore]
        public Recurso Recurso { get; set; }
    }
}

