/*Title = "Detalles";
        Content = new StackLayout
        {
            Children = {
                new Label { Text = pocso.Codigo },
                new Label { Text = pocso.Producto },
                // Agrega más Labels para cada campo que quieras mostrar
            }
        };*/


//using static QR_App.AppTabbedPage;

namespace QR_App;

public partial class MainPage : ContentPage
{
    //int count = 0;

    public MainPage()
    {
        InitializeComponent();
        //App.Current.MainPage = new NavigationPage(new AppTabbedPage());
        /*cameraView.BarCodeOptions = new()
		{
			PossibleFormats = {ZXing.BarcodeFormat.QR_CODE, ZXing.BarcodeFormat.CODE_39}
		};*/
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {

    }
    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        /*if (cameraView.Cameras.Count > 0) {
			cameraView.Camera = cameraView.Cameras.First();
			MainThread.BeginInvokeOnMainThread(async () =>
			{
				await cameraView.StopCameraAsync();
				await cameraView.StartCameraAsync();
			});
		}*/
    }
    private void cameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        /*MainThread.BeginInvokeOnMainThread(() =>
        {
			barcodeResult.Text = $"{args.Result[0].BarcodeFormat}: {args.Result[0].Text}";
        });*/
    }
}

XAML DE DETAILS PAGE
//BindingContext = new ViewModelData(); //No estoy usando Enlace de Datos, sino Asignación Directa.
        /*selectedCofre = cofre;
        lblCodigo.Text = selectedCofre.Codigo;
        lblBodega.Text = selectedCofre.Bodega;
        lblProducto.Text = selectedCofre.Producto;
        lblInhumado.Text = selectedCofre.Inhumado;
        lblNombreProveedor.Text = selectedCofre.NombreProveedor;*/
        // Aquí puedes utilizar 'selectedCofre' para llenar los controles en DetailPage.
        // Por ejemplo, si tienes un Label para el Codigo:
        // this.CodigoLabel.Text = this.selectedCofre.Codigo;











// Lógica para llamar a la API y actualizar el estado de cofre.
            // Puedes usar HttpClient para hacer la llamada a la API.
            // Asegúrate de manejar cualquier excepción que pueda ocurrir durante la llamada a la API.
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var httpClient = new HttpClient(clientHandler);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://gye01-itjf.server.local/apiscaneo/api/CofresUrnas/CambiaEstadoCofresUrnas"),
                Content = new StringContent(JsonConvert.SerializeObject(new
                {
                    bodega = _selectedCofre.Bodega,
                    codigo = _selectedCofre.Codigo,
                    estado = 1, // actualiza a estado 1
                    comentario = "", // agregar comentario según sea necesario
                    fotografia = "", // agregar fotografía según sea necesario
                    usuario = "" // agregar usuario según sea necesario
                }), Encoding.UTF8, "application/json")
            };

            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiResponse>(responseBody);
                // Verifica el resultado y realiza las acciones correspondientes
            }
            else
            {
                // Maneja el caso en el que la solicitud a la API falla
            }
