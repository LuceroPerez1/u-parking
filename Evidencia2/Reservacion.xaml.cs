using System.Text.Json;

namespace Evidencia2
{
    public partial class Reservacion : ContentPage
    {
        public class FormularioReservaciones
        {
            public required string Zona { get; set; }
            public required string NumeroCajon { get; set; }
            public required string HoraEntrada { get; set; }
            public required string HoraSalida { get; set; }
        }

        private async void ZonaEntry_Clicked(object sender, EventArgs e)
{
            string zonaSeleccionada = await DisplayActionSheet("Selecciona una zona", null , null, "Zona Norte", "Zona Centro", "Zona Oriente", "Zona Poniente");

            if (zonaSeleccionada != null && zonaSeleccionada != "Cancelar")
            {
                ZonaEntry.Text = zonaSeleccionada;
            }
        }

        private async void NumeroCajonEntry_Clicked(object sender, EventArgs e)
        {
            string cajonSeleccionado = await DisplayActionSheet("Selecciona un número de cajón", null, null,
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
                "11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
                "21", "22", "23", "24", "25", "26", "27", "28", "29", "30",
                "31", "32", "33", "34", "35", "36", "37", "38", "39", "40",
                "41", "42", "43", "44", "45", "46", "47", "48", "49", "50",
                "51", "52", "53", "54", "55", "56", "57", "58"
            );

            if (cajonSeleccionado != null)
            {
                NumeroCajonEntry.Text = cajonSeleccionado;
            }
        }

        private async void HoraEntradaPicker_Clicked(object sender, EventArgs e)
        {
            string horaEntrada = await DisplayActionSheet(
                "Selecciona la hora de entrada",
                null,
                null,
                "00:00", "01:00", "02:00", "03:00", "04:00",
                "05:00", "06:00", "07:00", "08:00", "09:00",
                "10:00", "11:00", "12:00", "13:00", "14:00",
                "15:00", "16:00", "17:00", "18:00", "19:00",
                "20:00", "21:00", "22:00", "23:00"
            );

            if (horaEntrada != null)
            {
                HoraEntradaPicker.Text = horaEntrada;
            }
        }

        private async void HoraSalidaPicker_Clicked(object sender, EventArgs e)
        {
            string horaSalida = await DisplayActionSheet(
                "Selecciona la hora de salida",
                null,
                null,
                "00:00", "01:00", "02:00", "03:00", "04:00",
                "05:00", "06:00", "07:00", "08:00", "09:00",
                "10:00", "11:00", "12:00", "13:00", "14:00",
                "15:00", "16:00", "17:00", "18:00", "19:00",
                "20:00", "21:00", "22:00", "23:00"
            );

            if (horaSalida != null)
            {
                HoraSalidaPicker.Text = horaSalida;
            }
        }

        private async void OnReservarButtonClicked(object sender, EventArgs e)
        {
            string zona = ZonaEntry.Text;
            string numeroCajon = NumeroCajonEntry.Text;
            string horaEntrada = HoraEntradaPicker.Text;
            string horaSalida = HoraSalidaPicker.Text;

            // Validaciones básicas
            if (zona.StartsWith("Selecciona") || numeroCajon.StartsWith("Selecciona") ||
                horaEntrada.StartsWith("Selecciona") || horaSalida.StartsWith("Selecciona"))
            {
                await DisplayAlert("Error", "Por favor completa todos los campos antes de reservar.", "OK");
                return;
            }

            var nuevaReservacion = new FormularioReservaciones
            {
                Zona = zona,
                NumeroCajon = numeroCajon,
                HoraEntrada = horaEntrada,
                HoraSalida = horaSalida,
            };

            string nombreArchivo = "CrearReservacion.json";
            string rutaCarpeta = @"C:\Users\52812\Documents\SEMESTRE 8 FACPYA\DESARROLLO DE APLICACIONES MOVILES MULTIPLATAFORMA\Evidencia2\Evidencia2";
            string ruta = Path.Combine(rutaCarpeta, nombreArchivo);

            List<FormularioReservaciones> historial = new();

            try
            {
                if (File.Exists(ruta))
                {
                    string jsonExistente = File.ReadAllText(ruta);
                    historial = JsonSerializer.Deserialize<List<FormularioReservaciones>>(jsonExistente) ?? new List<FormularioReservaciones>();
                }

                historial.Add(nuevaReservacion);

                string nuevoJson = JsonSerializer.Serialize(historial, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ruta, nuevoJson);

                await DisplayAlert("Guardado", $"Reservación guardada en:\n{ruta}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error al guardar la reservación:\n{ex.Message}", "OK");
            }
        }

        public Reservacion()
        {
            InitializeComponent();
        }
    }
}
