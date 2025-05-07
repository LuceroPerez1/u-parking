using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.Maui.Controls;

namespace Evidencia2
{
    public partial class MiPerfil : ContentPage
    {
        private string filePath;
        private bool modoEdicion = false;

        public MiPerfil()
        {
            InitializeComponent();

            // Ruta exacta donde tienes el JSON
            filePath = @"C:\Users\52812\Documents\SEMESTRE 8 FACPYA\DESARROLLO DE APLICACIONES MOVILES MULTIPLATAFORMA\Evidencia2\Evidencia2\usuarioscreados.json";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var usuario = UsuarioActivo.SesionActual;

            if (usuario != null)
            {
                LabelNombreCompleto.Text = $"{usuario.Nombre} {usuario.Apellido}";
                LabelCorreo.Text = usuario.Email;
                LabelModelo.Text = usuario.Modelo;
                LabelPlacas.Text = usuario.Placas;
                LabelMarca.Text = usuario.Marca;
                LabelColor.Text = usuario.Color;

                EntryModelo.Text = usuario.Modelo;
                EntryPlacas.Text = usuario.Placas;
                EntryMarca.Text = usuario.Marca;
                EntryColor.Text = usuario.Color;
            }
        }

        private async void BtnEditarGuardar_Clicked(object sender, EventArgs e)
        {
            var usuario = UsuarioActivo.SesionActual;

            if (usuario == null)
            {
                await DisplayAlert("Error", "No se ha encontrado un usuario activo.", "OK");
                return;
            }

            if (!modoEdicion)
            {
                // Activar edición
                LabelModelo.IsVisible = false;
                LabelPlacas.IsVisible = false;
                LabelMarca.IsVisible = false;
                LabelColor.IsVisible = false;

                EntryModelo.IsVisible = true;
                EntryPlacas.IsVisible = true;
                EntryMarca.IsVisible = true;
                EntryColor.IsVisible = true;

                BtnEditarGuardar.Text = "Guardar";
                modoEdicion = true;
            }
            else
            {
                // Guardar cambios
                usuario.Modelo = EntryModelo.Text;
                usuario.Placas = EntryPlacas.Text;
                usuario.Marca = EntryMarca.Text;
                usuario.Color = EntryColor.Text;

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    var usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);

                    if (usuarios == null)
                    {
                        await DisplayAlert("Error", "No se pudieron cargar los usuarios desde el archivo JSON.", "OK");
                        return;
                    }

                    var index = usuarios.FindIndex(u => u.Email == usuario.Email);
                    if (index != -1)
                    {
                        usuarios[index] = usuario;

                        string nuevoJson = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(filePath, nuevoJson);

                        await DisplayAlert("Éxito", "Datos actualizados correctamente.", "OK");

                        // Actualizar Labels
                        LabelModelo.Text = usuario.Modelo;
                        LabelPlacas.Text = usuario.Placas;
                        LabelMarca.Text = usuario.Marca;
                        LabelColor.Text = usuario.Color;

                        // Ocultar entradas
                        EntryModelo.IsVisible = false;
                        EntryPlacas.IsVisible = false;
                        EntryMarca.IsVisible = false;
                        EntryColor.IsVisible = false;

                        LabelModelo.IsVisible = true;
                        LabelPlacas.IsVisible = true;
                        LabelMarca.IsVisible = true;
                        LabelColor.IsVisible = true;

                        BtnEditarGuardar.Text = "Editar";
                        modoEdicion = false;
                    }
                }
                else
                {
                    await DisplayAlert("Error", "No se encontró el archivo de usuarios.", "OK");
                }
            }
        }
    }
}