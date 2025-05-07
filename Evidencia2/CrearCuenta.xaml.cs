using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;
using System.IO;
using System.Text.Json;
using Microsoft.Maui.Storage;
using System.Collections.Generic;

namespace Evidencia2
{
    public partial class CrearCuenta : ContentPage
    {
        public class FormularioUsuarios
        {
            public int IdUsuario { get; set; } // ID generado autom�ticamente
            public required string Nombre { get; set; }
            public required string Apellido { get; set; }
            public required string Modelo { get; set; }
            public required string Marca { get; set; }
            public required string Placas { get; set; }
            public required string Color { get; set; }
            public required string Email { get; set; }
            public required string Contrasena { get; set; }
        }

        // M�todo de validaci�n
        private bool ValidarCampos(string nombre, string apellido, string modelo, string placas, string marca, string color, string email, string contrasena)
        {
            // Validar campos vac�os
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(modelo) ||
                string.IsNullOrWhiteSpace(placas) || string.IsNullOrWhiteSpace(marca) || string.IsNullOrWhiteSpace(color) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(contrasena))
            {
                DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return false;
            }

            // Validar formato de correo
            var regexEmail = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            if (!regexEmail.IsMatch(email))
            {
                DisplayAlert("Error", "El correo electr�nico no tiene un formato v�lido.", "OK");
                return false;
            }

            // Validar que la contrase�a tenga al menos 6 caracteres
            if (contrasena.Length < 6)
            {
                DisplayAlert("Error", "La contrase�a debe tener al menos 6 caracteres.", "OK");
                return false;
            }

            return true;
        }

        public async void OnCrearCuentaClicked(object sender, EventArgs e)
        {
            string nombre = entryNombre.Text;
            string apellido = entryApellido.Text;
            string modelo = entryModelo.Text;
            string placas = entryPlacas.Text;
            string marca = entryMarca.Text;
            string color = entryColor.Text;
            string email = entryEmail.Text;
            string contrasena = entryContrasena.Text;

            // Validar los campos antes de continuar
            if (!ValidarCampos(nombre, apellido, modelo, placas, marca, color, email, contrasena))
            {
                return; // Si alguna validaci�n falla, salimos del m�todo
            }

            string nombreArchivo = "UsuariosCreados.json";
            string rutaCarpeta = @"C:\Users\52812\Documents\SEMESTRE 8 FACPYA\DESARROLLO DE APLICACIONES MOVILES MULTIPLATAFORMA\Evidencia2\Evidencia2";
            string ruta = Path.Combine(rutaCarpeta, nombreArchivo);

            List<FormularioUsuarios> historial = new();

            if (File.Exists(ruta))
            {
                string jsonExistente = File.ReadAllText(ruta);
                historial = JsonSerializer.Deserialize<List<FormularioUsuarios>>(jsonExistente) ?? new List<FormularioUsuarios>();
            }

            // Generar ID autom�tico
            int nuevoId = historial.Any() ? historial.Max(u => u.IdUsuario) + 1 : 1;

            var nuevoUsuario = new FormularioUsuarios
            {
                IdUsuario = nuevoId,
                Nombre = nombre,
                Apellido = apellido,
                Modelo = modelo,
                Placas = placas,
                Marca = marca,
                Color = color,
                Email = email,
                Contrasena = contrasena,
            };

            historial.Add(nuevoUsuario);

            string nuevoJson = JsonSerializer.Serialize(historial, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ruta, nuevoJson);

            // Confirmaci�n de cuenta creada
            await DisplayAlert("Cuenta creada", "Tu cuenta ha sido registrada con �xito", "OK");
            await Navigation.PushAsync(new Reglamento());
        }

        public CrearCuenta()
        {
            InitializeComponent();
        }
    }
}
