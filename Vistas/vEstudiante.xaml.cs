
using Newtonsoft.Json;
using pmejiaST6.Models;
using System.Collections.ObjectModel;

namespace pmejiaST6.Vistas;

public partial class vEstudiante : ContentPage
{
	private const string url = "http://192.168.18.17/moviles/wsestudiantes.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> est;
	public vEstudiante()
	{
		InitializeComponent();
		ObtenerDatos();
       
    }
	public async void ObtenerDatos()
	{
		var content = await cliente.GetStringAsync(url);
		List<Estudiante> mostrar = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		est = new ObservableCollection<Estudiante>(mostrar);
		listEstudiante.ItemsSource = est;
	}

	private void btnAgregar_Clicked_1(object sender, EventArgs e)
	{

		Navigation.PushAsync(new vAgregar());
	}

	private void listEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var objEstudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new vAgregarEliminar(objEstudiante));

	}
   
}		