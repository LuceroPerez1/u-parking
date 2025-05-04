namespace Evidencia2
{
    public partial class InicioSesion : ContentPage
    {

        public InicioSesion()
        {
            InitializeComponent();
        }

        //Acci�n para el bot�n Iniciar sesi�n
        private void OnLoginClicked(object sender, EventArgs e)
        {
            //il�gica para validar el inicio de sesi�n


            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                DisplayAlert("Error", "Por favor ingresa tu correo y contrase�a.", "OK");
            }
            else
            {
                //L�gica de inicio de sesi�n exitosa, o redirecci�n a otra p�gina.
                DisplayAlert("Bienvenido", "Iniciando sesi�n...", "OK");
            }
        }

        // Acci�n para el enlace "Crear cuenta"
        private void OnCreateAccountClicked(object sender, EventArgs e)
        {
            //  implementar la l�gica para navegar a la p�gina de registro.
            DisplayAlert("Crear cuenta", "Redirigiendo a la p�gina de registro...", "OK");
        }
    }
}
