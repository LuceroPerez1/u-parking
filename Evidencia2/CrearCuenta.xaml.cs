using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;

namespace Evidencia2
{
    public partial class CrearCuenta : ContentPage
    {
        public CrearCuenta()
        {
            InitializeComponent();
        }

        private async void OnBackButtonTapped(object sender, EventArgs e)
        {
            if (Navigation.NavigationStack.Count > 1)
            {
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Aviso", "No hay una página anterior.", "OK");
            }
        }

        private async void OnCrearCuentaClicked(object sender, EventArgs e)
        {
            string nombre = entryNombre.Text;
            string apellido = entryApellido.Text;
            string modelo = entryModelo.Text;
            string placas = entryPlacas.Text;
            string marca = entryMarca.Text;
            string color = entryColor.Text;
            string email = entryEmail.Text;
            string contrasena = entryContrasena.Text;

            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(modelo) ||
                string.IsNullOrWhiteSpace(placas) ||
                string.IsNullOrWhiteSpace(marca) ||
                string.IsNullOrWhiteSpace(color) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(contrasena))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

            // Validación de que el nombre solo contenga letras
            if (!nombre.All(char.IsLetter))
            {
                await DisplayAlert("Error", "El nombre solo debe contener letras.", "OK");
                return;
            }

            // Validación de que el apellido solo contenga letras
            if (!apellido.All(char.IsLetter))
            {
                await DisplayAlert("Error", "El apellido solo debe contener letras.", "OK");
                return;
            }

            // Validación de que el modelo solo contenga letras
            if (!modelo.All(char.IsLetter))
            {
                await DisplayAlert("Error", "El modelo del vehículo solo debe contener letras.", "OK");
                return;
            }
            // Validación de que la marca solo contenga letras
            if (!marca.All(char.IsLetter))
            {
                await DisplayAlert("Error", "La marca del vehículo solo debe contener letras.", "OK");
                return;
            }
            // Validación de que el color solo contenga letras
            if (!color.All(char.IsLetter))
            {
                await DisplayAlert("Error", "El color del vehículo solo debe contener letras.", "OK");
                return;
            }

            // Validación de placas: deben contener al menos una letra, un número y estar en mayúsculas
            if (!Regex.IsMatch(placas, "^(?=.*[A-Z])(?=.*[0-9])[A-Z0-9]+$"))
            {
                await DisplayAlert("Error", "Las placas deben contener letras y un números, y estar en mayúsculas.", "OK");
                return;
            }

            // Validación de formato de correo electrónico
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                await DisplayAlert("Error", "El correo electrónico no tiene un formato válido.", "OK");
                return;
            }

            // Validación de la contraseña (mínimo 6 caracteres)
            if (contrasena.Length < 6)
            {
                await DisplayAlert("Error", "La contraseña debe tener al menos 6 caracteres.", "OK");
                return;
            }

            await DisplayAlert("", "Cuenta creada correctamente.", "OK");
        }
    }
}
