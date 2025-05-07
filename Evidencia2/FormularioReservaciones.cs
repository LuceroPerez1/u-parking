using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidencia2
{
    public static class ReservacionActiva
    {
        public static FormularioReservaciones? Datos { get; set; }
    }
    public class FormularioReservaciones
    {
        public required int IdReservacion { get; set; }
        public required string Zona { get; set; }
        public required string NumeroCajon { get; set; }
        public required string HoraEntrada { get; set; }
        public required string HoraSalida { get; set; }
    }
}