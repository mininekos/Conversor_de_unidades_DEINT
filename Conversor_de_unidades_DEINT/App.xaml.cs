using Conversor_de_unidades_DEINT.MVVM.Views;

namespace Conversor_de_unidades_DEINT;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MenuConversorUnidades());
	}
}
