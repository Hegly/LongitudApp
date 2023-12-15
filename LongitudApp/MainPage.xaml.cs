using static LongitudApp.ViewModels.ViewModel;

namespace LongitudApp;

public partial class MainPage : ContentPage
{
    readonly int count = 0;

    public object KmEntry { get; private set; }
    public object MetrosEntry { get; private set; }
    public object ResultadoKmaM { get; private set; }
    public object ResultadoMaCm { get; private set; }

    public MainPage()
	{
		InitializeComponent();
        BindingContext = new KmaMViewModel();
    }

    private void OnTabChanged(object sender, SelectedTabChangedEventArgs e)
    {
        if (e.Tab.Title == "Km a m")
        {
            BindingContext = new KmaMViewModel();
        }
        else if (e.Tab.Title == "m a cm")
        {
            BindingContext = new MaCmViewModel();
        }
    }

    private async void OnKmToMButtonClick(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(KmEntry.Text))
        {
            await DisplayAlert("Error", "Ingrese un valor en kilómetros", "Aceptar");
            return;
        }

        if (double.TryParse(KmEntry.Text, out double kilometros))
        {
            if (kilometros >= 0)
            {
                double meters = MainPage.ConvertKmToM(kilometros);
                await DisplayAlert("Resultado", $"{kilometros} kilómetros es igual a {meters} metros", "Aceptar");
            }
            else
            {
                await DisplayAlert("Error", "Ingrese un valor válido y no negativo en kilómetros", "Aceptar");
            }
        }
        else
        {
            await DisplayAlert("Error", "Ingrese un valor numérico válido en kilómetros", "Aceptar");
        }
    }

    private async void OnMToCmButtonClick(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(MetrosEntry.Text))
        {
            await DisplayAlert("Error", "Ingrese un valor en metros", "Aceptar");
            return;
        }

        if (double.TryParse(MetrosEntry.Text, out double metros))
        {
            if (metros >= 0)
            {
                double centimetros = MainPage.ConvertMToCm(metros);
                await DisplayAlert("Resultado", $"{metros} metros es igual a {centimetros} centímetros", "Aceptar");
            }
            else
            {
                await DisplayAlert("Error", "Ingrese un valor válido y no negativo en metros", "Aceptar");
            }
        }
        else
        {
            await DisplayAlert("Error", "Ingrese un valor numérico válido en metros", "Aceptar");
        }
    }

    private static double ConvertKmToM(double kilometros)
    {
        return kilometros * 1000; // 1 kilómetro = 1000 metros
    }

    private static double ConvertMToCm(double metros)
    {
        return metros * 100; // 1 metro = 100 centímetros
    }

    private void OnClearKmButtonClick(object sender, EventArgs e)
    {
        KmEntry.Text = string.Empty;
        ResultadoKmaM.Text = "Resultado: ";
    }

    private void OnClearMButtonClick(object sender, EventArgs e)
    {
        MetrosEntry.Text = string.Empty;
        ResultadoMaCm.Text = "Resultado: ";
    }
}


