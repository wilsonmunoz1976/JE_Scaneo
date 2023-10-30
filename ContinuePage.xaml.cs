using Newtonsoft.Json;
using System.Text;

namespace QR_App;

public partial class ContinuePage : ContentPage
{
    private readonly string barcodeResult;

    public ContinuePage(string barcodeResult)
    {
        InitializeComponent();
        this.barcodeResult = barcodeResult;
    }

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        btnSend.IsEnabled = !string.IsNullOrWhiteSpace(e.NewTextValue);
    }

    private async void OnSendClicked(object sender, EventArgs e)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        var client = new HttpClient(clientHandler);
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://gye01-itjf.server.local/apiscaneo/api/Emergencia/RegistrarEmergencia"),
            Content = new StringContent(JsonConvert.SerializeObject(new { nombres = entryName.Text, articulo = "C90", empresa = "J01", usuario = "wmunoz" }), Encoding.UTF8, "application/json")
        };

        using var response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("Exito", "Datos enviados con éxito", "OK");
        }
        else
        {
            await DisplayAlert("Error", "Ocurrió un error al enviar los datos", "OK");
        }
    }

}