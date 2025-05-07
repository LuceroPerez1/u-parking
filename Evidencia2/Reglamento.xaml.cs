namespace Evidencia2;

public partial class Reglamento : ContentPage
{
	public Reglamento()
	{
		InitializeComponent();
	}

    public async void AceptarButton_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InicioSesion());
    }
}