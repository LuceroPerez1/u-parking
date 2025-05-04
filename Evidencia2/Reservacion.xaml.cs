namespace Evidencia2
{
    public partial class Reservacion : ContentPage
    {
        public Reservacion()
        {
            InitializeComponent();
        }

        private async void ZonaEntry_Clicked(object sender, EventArgs e)
        {
            var opciones = new[] { "Zona Norte", "Zona Central", "Zona Oriente", "Zona Poniente" };
            string? seleccion = await DisplayActionSheet("Selecciona una zona", null, null, opciones);
            if (!string.IsNullOrEmpty(seleccion))
                ZonaEntry.Text = seleccion;
        }

        private async void NumeroCajonEntry_Clicked(object sender, EventArgs e)
        {
            var opciones = Enumerable.Range(1, 57).Select(i => i.ToString()).ToArray();
            string? seleccion = await DisplayActionSheet("Selecciona un número de cajón", null, null, opciones);
            if (!string.IsNullOrEmpty(seleccion))
                NumeroCajonEntry.Text = seleccion;
        }

        private async void HoraEntradaPicker_Clicked(object sender, EventArgs e)
        {
            var opciones = Enumerable.Range(0, 24).Select(i => $"{i:00}:00").ToArray();
            string? seleccion = await DisplayActionSheet("Selecciona la hora de entrada", null, null, opciones);
            if (!string.IsNullOrEmpty(seleccion))
                HoraEntradaPicker.Text = seleccion;
        }

        private async void HoraSalidaPicker_Clicked(object sender, EventArgs e)
        {
            var opciones = Enumerable.Range(0, 24).Select(i => $"{i:00}:00").ToArray();
            string? seleccion = await DisplayActionSheet("Selecciona la hora de salida", null, null, opciones);
            if (!string.IsNullOrEmpty(seleccion))
                HoraSalidaPicker.Text = seleccion;
        }

        private async void OnReservarButtonClicked(object sender, EventArgs e)
        {
            string zona = ZonaEntry.Text;
            string numeroCajon = NumeroCajonEntry.Text;
            string horaEntrada = HoraEntradaPicker.Text;
            string horaSalida = HoraSalidaPicker.Text;

            if (zona.StartsWith("Selecciona") || numeroCajon.StartsWith("Selecciona") ||
                horaEntrada.StartsWith("Selecciona") || horaSalida.StartsWith("Selecciona"))
            {
                await DisplayAlert("Faltan datos", "Completa todos los campos antes de reservar.", "OK");
                return;
            }

            await DisplayAlert("Reservación exitosa",
                $"Zona: {zona}\nCajón: {numeroCajon}\nEntrada: {horaEntrada}\nSalida: {horaSalida}", "OK");

            // Reiniciar valores
            ZonaEntry.Text = "Selecciona una zona";
            NumeroCajonEntry.Text = "Selecciona un número de cajón";
            HoraEntradaPicker.Text = "Selecciona la hora de entrada";
            HoraSalidaPicker.Text = "Selecciona la hora de salida";
        }
    }
}



