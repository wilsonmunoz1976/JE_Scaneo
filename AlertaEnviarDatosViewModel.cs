using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_App
{
    internal class AlertaEnviarDatosViewModel
    {
        /*private readonly AlertaTabViewModel _alertaTabViewModel;

        public AlertaEnviarDatosViewModel(AlertaTabViewModel alertaTabViewModel)
        {
            _alertaTabViewModel = alertaTabViewModel;
        }

        public async Task EnviarDatosAsync(string nombre)
        {
            var request = new AlertaRegistrarEmergenciaRequest
            {
                nombres = nombre,
                //articulo = _alertaTabViewModel.CodigoQR,
                articulo = "C90",
                empresa = "J01", // Puedes reemplazar esto con el valor real
                usuario = "wmunoz" // Puedes reemplazar esto con el valor real
            };

            var response = await RegistrarEmergenciaAsync(request);

            if (response.Codigo == -1)
            {
                // Informar al usuario sobre el error
                await ToastUtility.ShowToastAsync("Error: " + response.Mensaje);
            }
            else
            {
                //Informar al usuario que la solicitud fue exitosa
                await ToastUtility.ShowToastAsync("Success: " + "Los datos se enviaron con éxito.");
            }
        }

        private async Task<ApiResponse> RegistrarEmergenciaAsync(AlertaRegistrarEmergenciaRequest request)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://gye01-itjf.server.local/apiscaneo/api/Emergencia/RegistrarEmergencia", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ApiResponse>(responseContent);
                }
                else
                {
                    // manejar el error
                    return null;
                }
            }
        }*/
    }
}