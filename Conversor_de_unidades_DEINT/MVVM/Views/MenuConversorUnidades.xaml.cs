namespace Conversor_de_unidades_DEINT.MVVM.Views;

public partial class MenuConversorUnidades : ContentPage
{
	public MenuConversorUnidades()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
		Grid grid= (Grid)sender;
		Label lbl= grid.Children[1] as Label;
		Navigation.PushAsync(new Conversor(lbl.Text));
    }
}