using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.Maui.Controls;

namespace Evidencia2
{
    public partial class Reservacion : ContentPage
    {
        public Reservacion()
        {
            InitializeComponent();
        }

        private async void OnMiReservacionClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MiReservacion());
        }

        private async void OnMiPerfilClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MiPerfil());
        }

        private async void ZonaEntry_Clicked(object sender, EventArgs e)
        {
            string zonaSeleccionada = await DisplayActionSheet("Selecciona una zona", null, null, "Zona Norte", "Zona Centro", "Zona Oriente", "Zona Poniente");
            if (!string.IsNullOrEmpty(zonaSeleccionada))
                ZonaEntry.Text = zonaSeleccionada;
        }

        private async void NumeroCajonEntry_Clicked(object sender, EventArgs e)
        {
            string cajonSeleccionado = await DisplayActionSheet("Selecciona un número de cajón", null, null,
                Enumerable.Range(1, 58).Select(i => i.ToString()).ToArray());

            if (!string.IsNullOrEmpty(cajonSeleccionado))
                NumeroCajonEntry.Text = cajonSeleccionado;
        }

        private async void OnReservarButtonClicked(object sender, EventArgs e)
        {
            string zona = ZonaEntry.Text;
            string numeroCajon = NumeroCajonEntry.Text;
            string horaEntrada = HoraEntradaPicker.Time.ToString(@"hh\:mm");
            string horaSalida = HoraSalidaPicker.Time.ToString(@"hh\:mm");

            if (string.IsNullOrWhiteSpace(zona) || string.IsNullOrWhiteSpace(numeroCajon))
            {
                await DisplayAlert("Error", "Por favor completa todos los campos.", "OK");
                return;
            }

            var nueva = new FormularioReservaciones
            {
                IdReservacion = new Random().Next(1000, 9999),
                Zona = zona,
                NumeroCajon = numeroCajon,
                HoraEntrada = horaEntrada,
                HoraSalida = horaSalida
            };

            // Ruta personalizada + archivo JSON
            string rutaPersonal = @"C:\Users\52812\Documents\SEMESTRE 8 FACPYA\DESARROLLO DE APLICACIONES MOVILES MULTIPLATAFORMA\Evidencia2\Evidencia2";
            string filePath = Path.Combine(rutaPersonal, "CrearReservacion.json");

            List<FormularioReservaciones> reservaciones = new();
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                reservaciones = JsonSerializer.Deserialize<List<FormularioReservaciones>>(json) ?? new List<FormularioReservaciones>();
            }

            // Validar traslape de horario
            bool yaReservado = reservaciones.Any(r =>
                r.Zona == nueva.Zona &&
                r.NumeroCajon == nueva.NumeroCajon &&
                TimeSpan.Parse(nueva.HoraEntrada) < TimeSpan.Parse(r.HoraSalida) &&
                TimeSpan.Parse(nueva.HoraSalida) > TimeSpan.Parse(r.HoraEntrada)
            );

            if (yaReservado)
            {
                await DisplayAlert("Ocupado", "Ese cajón ya está reservado durante ese horario.", "OK");
                return;
            }

            // Guardar nueva reservación
            reservaciones.Add(nueva);
            string nuevoJson = JsonSerializer.Serialize(reservaciones);
            File.WriteAllText(filePath, nuevoJson);

            ReservacionActiva.Datos = nueva;

            await DisplayAlert("Éxito", "Reservación guardada exitosamente.", "OK");
            await Navigation.PushAsync(new MiReservacion());
        }
    }
}




