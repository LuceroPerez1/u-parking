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
                await DisplayAlert("Aviso", "No hay una p�gina anterior.", "OK");
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

            // Validaci�n de campos vac�os
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

            // Validaci�n de que el nombre solo contenga letras
            if (!nombre.All(char.IsLetter))
            {
                await DisplayAlert("Error", "El nombre solo debe contener letras.", "OK");
                return;
            }

            // Validaci�n de que el apellido solo contenga letras
            if (!apellido.All(char.IsLetter))
            {
                await DisplayAlert("Error", "El apellido solo debe contener letras.", "OK");
                return;
            }

            // Validaci�n de que el modelo solo contenga letras
            if (!modelo.All(char.IsLetter))
            {
                await DisplayAlert("Error", "El modelo del veh�culo solo debe contener letras.", "OK");
                return;
            }
            // Validaci�n de que la marca solo contenga letras
            if (!marca.All(char.IsLetter))
            {
                await DisplayAlert("Error", "La marca del veh�culo solo debe contener letras.", "OK");
                return;
            }
            // Validaci�n de que el color solo contenga letras
            if (!color.All(char.IsLetter))
            {
                await DisplayAlert("Error", "El color del veh�culo solo debe contener letras.", "OK");
                return;
            }

            // Validaci�n de placas: deben contener al menos una letra, un n�mero y estar en may�sculas
            if (!Regex.IsMatch(placas, "^(?=.*[A-Z])(?=.*[0-9])[A-Z0-9]+$"))
            {
                await DisplayAlert("Error", "Las placas deben contener letras y un n�meros, y estar en may�sculas.", "OK");
                return;
            }

            // Validaci�n de formato de correo electr�nico
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                await DisplayAlert("Error", "El correo electr�nico no tiene un formato v�lido.", "OK");
                return;
            }

            // Validaci�n de la contrase�a (m�nimo 6 caracteres)
            if (contrasena.Length < 6)
            {
                await DisplayAlert("Error", "La contrase�a debe tener al menos 6 caracteres.", "OK");
                return;
            }

            await DisplayAlert("", "Cuenta creada correctamente.", "OK");
        }
    }
}
