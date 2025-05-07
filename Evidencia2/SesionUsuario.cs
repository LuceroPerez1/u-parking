using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidencia2
{
    public static class UsuarioActivo
    {
        public static Usuario? SesionActual { get; set; }
    }

    public class Usuario
    {
        public required int IdUsuario { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Modelo { get; set; }
        public required string Marca { get; set; }
        public required string Placas { get; set; }
        public required string Color { get; set; }
        public required string Email { get; set; }
        public required string Contrasena { get; set; }
    }
}

