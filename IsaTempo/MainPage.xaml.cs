using System.Text.Json;
using Windows.ApplicationModel.AppService;

namespace IsaTempo;

public partial class MainPage : ContentPage
{
	const string Url ="https://api.hgbrasil.com/weather?"

	public MainPage()
	{
		InitializeComponent();
	
	}
     
 void PreencherTela()
  {
	labelTemp.Text= Resultados.temp.ToString();
    labelSky.Text= Resultados.description;
    labelCidade.Text= Resultados.city;
    labelChuva.Text= Resultados.rain.ToString();
    labelHumidade.Text= Resultados.humidity.ToString();
	labelAmanhecer.Text= Resultados.sunrise;
	labelAnoitecer.Text= Resultados.sunset;
	labelForcawind.Text= Resultados.wind_speedy.ToString();
	labelDirecawind.Text= Resultados.wind_direction;
	labelMoonFase.Text= Resultados.moon_phase;
  }
  async void AtualizaTempo()
  {
	try 
	{
		var httpClient = new HttpClient();
		var response = await httpClient.GetAsync(Url);
		if (response.IsSuccessStatusCode)
		{
			var content = await response.Content.ReadAsStringAsync();
			Resposta = JsonSerializer.Deserialize<Resposta>(content);
 		}
		PreencherTela();
	}
	catch (Exception e)
	{
		System.Diagnostics.Debug.WriteLine(e);
	}
  }
}