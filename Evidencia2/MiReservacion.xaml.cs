using Microsoft.Maui.Controls;

namespace Evidencia2
{
    public partial class MiReservacion : ContentPage
    {
        public MiReservacion()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ReservacionActiva.Datos != null)
            {
                var r = ReservacionActiva.Datos;
                LabelZona.Text = r.Zona;
                LabelCajon.Text = r.NumeroCajon;
                LabelHoraEntrada.Text = r.HoraEntrada;
                LabelHoraSalida.Text = r.HoraSalida;
                LabelTiempoRestante.Text = "Reserva activa";
            }
            else
            {
                LabelZona.Text = "Sin reservación activa";
                LabelCajon.Text = "";
                LabelHoraEntrada.Text = "";
                LabelHoraSalida.Text = "";
                LabelTiempoRestante.Text = "";
            }
        }
    }
}

