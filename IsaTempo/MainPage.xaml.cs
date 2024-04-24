namespace IsaTempo;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		Results Resultados = new Results();
		PreencherTela();
	}

 void PreencherTela()
  {
	labelTemp.Text= Resultados.temp.Tostring();
    labelSky.Text= Resultados.description;
    labelCidade.Text= Resultados.city;
    labelChuva.Text= Resultados.rain.Tostring();
    labelHumidade.Text= Resultados.humidity.Tostring();
	labelAmanhecer.Text= Resultados.sunrise;
	labelAmanhecer.Text= Resultados.sunset;
	labelForcawind.Text= Resultados.wind_speedy.Tostring();
	labelDirecawind.Text= Resultados.wind_direction;
	labelMoonFase.Text= Resultados.moon_phase;
  }
}