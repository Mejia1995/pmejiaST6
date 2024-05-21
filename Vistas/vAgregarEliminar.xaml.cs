using Microsoft.Maui.Controls;
using pmejiaST6.Models;
using System.Net;

namespace pmejiaST6.Vistas;

public partial class vAgregarEliminar : ContentPage
{

    public vAgregarEliminar(Estudiante datos)
    {
        InitializeComponent();

        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var httpClient = new HttpClient();
            var parametros = new Dictionary<string, string>
        {
            {"Codigo", txtCodigo.Text},
            {"Nombre", txtNombre.Text},
            {"Apellido", txtApellido.Text},
            {"Edad", txtEdad.Text}
        };

            var content = new FormUrlEncodedContent(parametros);
            var url = $"http://localhost/moviles/wsestudiantes.php?Codigo={txtCodigo.Text}&Nombre={txtNombre.Text}&Apellido={txtApellido.Text}&Edad={txtEdad.Text}";
            var response = httpClient.PutAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
               var respuestaServidor = response.Content.ReadAsStringAsync().Result;
               DisplayAlert("Respuesta del servidor", respuestaServidor, "OK");
                Navigation.PushAsync(new vEstudiante());
            }
            else
            {
                DisplayAlert("Alerta", "Error al actualizar el registro", "cerrar");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "cerrar");
        }
    }



    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var httpClient = new HttpClient();
            var url = $"http://192.168.18.17/moviles/wsestudiantes.php?codigo={txtCodigo.Text}";
            var response = httpClient.DeleteAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                Navigation.PushAsync(new vEstudiante());
            }
            else
            {
                DisplayAlert("Alerta", "Error al eliminar el registro", "cerrar");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "cerrar");
        }   

    }
}
