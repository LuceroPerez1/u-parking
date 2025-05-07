using Microsoft.Maui.Controls;

namespace Evidencia2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCrearCuentaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CrearCuenta());
        }

        private async void OnIniciarSesionClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InicioSesion());
        }
    }
}
