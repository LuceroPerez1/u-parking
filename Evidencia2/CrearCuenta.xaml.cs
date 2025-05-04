using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;
using System.IO;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace Evidencia2
{

    public partial class CrearCuenta : ContentPage

    {
        public class FormularioUsuarios
        {
            public required string Nombre { get; set; }
            public required string Apellido { get; set; }
            public required string Modelo { get; set; }
            public required string Marca { get; set; }
            public required string Placas { get; set; }
            public required string Color { get; set; }
            public required string Email { get; set; }
            public required string Contrasena { get; set; }

        }

        private async void OnCrearCuentaClicked(object sender, EventArgs e)
        {
            string nombre = entryNombre.Text;
            string apellido = entryApellido.Text;
            string modelo = entryModelo.Text;
            string placas = entryPlacas.Text;
            string marca = entryMarca.Text;
            string color = entryColor.Text;
            string email = entryEmail.Text;
            string contrasena = entryContrasena.Text;

            var nuevoUsuario = new FormularioUsuarios
            {
                Nombre = nombre,
                Apellido = apellido,
                Modelo = modelo,
                Placas = placas,
                Marca = marca,
                Color = color,
                Email = email,
                Contrasena = contrasena,
            };

            string nombreArchivo = "UsuariosCreados.json";
            string rutaCarpeta = @"C:\Users\52812\Documents\SEMESTRE 8 FACPYA\DESARROLLO DE APLICACIONES MOVILES MULTIPLATAFORMA\Evidencia2\Evidencia2";
            string ruta = Path.Combine(rutaCarpeta, nombreArchivo);

            List<FormularioUsuarios> historial = new();

            if (File.Exists(ruta))
            {
                string jsonExistente = File.ReadAllText(ruta);
                historial = JsonSerializer.Deserialize<List<FormularioUsuarios>>(jsonExistente) ?? new List<FormularioUsuarios>();
            }

            historial.Add(nuevoUsuario);

            string nuevoJson = JsonSerializer.Serialize(historial, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ruta, nuevoJson);

            await DisplayAlert("Guardado", $"Archivo actualizado en:\n{ruta}", "OK");
        }
        public CrearCuenta()
        {
            InitializeComponent();
        }


    }
}
