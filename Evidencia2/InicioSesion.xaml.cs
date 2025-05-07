using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Maui.Controls;

namespace Evidencia2
{
    public partial class InicioSesion : ContentPage
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        public async void OnLoginClicked(object sender, EventArgs e)
        {
            string? email = EmailEntry.Text?.Trim().ToLower();
            string password = PasswordEntry.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Por favor ingresa tu correo y contraseña.", "OK");
                return;
            }

            // ✅ Ruta ABSOLUTA de tu archivo en desarrollo local
            string ruta = @"C:\Users\52812\Documents\SEMESTRE 8 FACPYA\DESARROLLO DE APLICACIONES MOVILES MULTIPLATAFORMA\Evidencia2\Evidencia2\UsuariosCreados.json";

            if (!File.Exists(ruta))
            {
                await DisplayAlert("Error", $"No se encontró el archivo de usuarios en:\n{ruta}", "OK");
                return;
            }

            try
            {
                string json = File.ReadAllText(ruta);
                var usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);

                if (usuarios == null || usuarios.Count == 0)
                {
                    await DisplayAlert("Error", "No hay usuarios registrados en el sistema.", "OK");
                    return;
                }

                var usuario = usuarios.FirstOrDefault(u =>
                    u.Email.Trim().ToLower() == email &&
                    u.Contrasena == password);

                if (usuario != null)
                {
                    UsuarioActivo.SesionActual = usuario;
                    await Navigation.PushAsync(new Reservacion());
                }
                else
                {
                    await DisplayAlert("Error", "Credenciales incorrectas. ¿Deseas crear una cuenta?", "OK");
                    await Navigation.PushAsync(new CrearCuenta());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al leer usuarios: {ex.Message}", "OK");
            }
        }

        public async void OnCreateAccountClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CrearCuenta());
        }
    }
}
