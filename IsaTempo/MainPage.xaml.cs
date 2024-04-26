using System.Text.Json;
using Windows.ApplicationModel.AppService;

namespace IsaTempo;

public partial class MainPage : ContentPage
{
	const string Url ="https://api.hgbrasil.com/weather?woeid=455927&key=5f1b4e9e";
 	Resposta resposta;

	public MainPage()
	{
		InitializeComponent();
	
	}
     
 void PreencherTela()
  {
	labelTemp.Text= resposta.results.temp.ToString();
    labelSky.Text= resposta.results.description;
    labelCidade.Text= resposta.results.city;
    labelChuva.Text= resposta.results.rain.ToString();
    labelHumidade.Text= resposta.results.humidity.ToString();
	labelAmanhecer.Text= resposta.results.sunrise;
	labelAnoitecer.Text= resposta.results.sunset;
	labelForcawind.Text= resposta.results.wind_speedy.ToString();
	labelDirecawind.Text= resposta.results.wind_direction;
	labelMoonFase.Text= resposta.results.moon_phase;
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
			resposta = JsonSerializer.Deserialize<Resposta>(content);
 		}
		PreencherTela();
	}
	catch (Exception e)
	{
		System.Diagnostics.Debug.WriteLine(e);
	}
  }
}