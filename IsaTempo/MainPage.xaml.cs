using System.Text.Json;


namespace IsaTempo;

public partial class MainPage : ContentPage
{
	const string Url ="https://api.hgbrasil.com/weather?woeid=455927&key=5f1b4e9e";
 	Resposta resposta;

	public MainPage()
	{
		InitializeComponent();
	    AtualizaTempo();
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
	labelDirecawind.Text= resposta.results.wind_direction.ToString();
	labelMoonFase.Text= resposta.results.moon_phase;

	if (resposta.results.currently =="dia")
			{
				if (resposta.results.rain >=10)
				imagemfundo.Source="diachuvoso.jpg";
				else if (resposta.results.cloudiness >=10)
				imagemfundo.Source="dianublado.jpg";
				else
				imagemfundo.Source="ceulimpo.jpg";
			}
			else
			   
			{
				if (resposta.results.rain >=10)
				imagemfundo.Source="noitechuva.jpg";
				else if (resposta.results.cloudiness >=10)
				imagemfundo.Source="noitenublada.jpg";
				else
				imagemfundo.Source="ceuestrelado.jpg";
			}
  }
 async void AtualizaTempo()
	{
		try
		{
			var  httpClient= new HttpClient();
			var response= await httpClient.GetAsync(Url);
			if (response.IsSuccessStatusCode)
			{
				var content= await response.Content.ReadAsStringAsync();
				resposta= JsonSerializer.Deserialize<Resposta>(content);		
			}
			PreencherTela();
		}
	   catch (Exception e)
	   {
			System.Diagnostics.Debug.WriteLine(e);
	   }
	}
}