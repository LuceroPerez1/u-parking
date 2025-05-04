namespace Evidencia2
{
    public partial class InicioSesion : ContentPage
    {

        public InicioSesion()
        {
            InitializeComponent();
        }

        //Acción para el botón Iniciar sesión
        private void OnLoginClicked(object sender, EventArgs e)
        {
            //ilógica para validar el inicio de sesión


            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                DisplayAlert("Error", "Por favor ingresa tu correo y contraseña.", "OK");
            }
            else
            {
                //Lógica de inicio de sesión exitosa, o redirección a otra página.
                DisplayAlert("Bienvenido", "Iniciando sesión...", "OK");
            }
        }

        // Acción para el enlace "Crear cuenta"
        private void OnCreateAccountClicked(object sender, EventArgs e)
        {
            //  implementar la lógica para navegar a la página de registro.
            DisplayAlert("Crear cuenta", "Redirigiendo a la página de registro...", "OK");
        }
    }
}
