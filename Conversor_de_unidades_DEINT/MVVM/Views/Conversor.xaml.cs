using System.Collections.ObjectModel;
using UnitsNet;

namespace Conversor_de_unidades_DEINT.MVVM.Views;

public partial class Conversor : ContentPage
{

	public ObservableCollection<string> FromMedidas { get; set; }
	public ObservableCollection<string> ToMedidades { get; set; }

    private Boolean cargado = false;
	
	string QuantityName;
    public Conversor()
	{
		InitializeComponent();
        

    }

    public Conversor(string s)
    {
        InitializeComponent();
		QuantityName = s;
        txtTexto.Text = s;

        traducir();

        FromMedidas = CargarMedidas();
        ToMedidades = CargarMedidas();

        pickerConvertir.ItemsSource= FromMedidas.ToList<string>();
        pickerConvertir.SelectedIndex = 0;

        
        pickerConvertido.ItemsSource = ToMedidades.ToList();
        pickerConvertido.SelectedIndex = 1;

        cargado = true;

    }

    private ObservableCollection<string> CargarMedidas() {
		
		var types= Quantity.Infos
			.FirstOrDefault(x=>x.Name== QuantityName)
			.UnitInfos
			.Select(u => u.Name)
			.ToList();

		return new ObservableCollection<string>(types);

    }
    public void traducir() {

        switch (QuantityName)
        {
            case "Informacion":
                QuantityName = "Information";
                break;
            case "Volumen":
                QuantityName = "Volume";
                break;
            case "":
                QuantityName = "Length";
                break;
            case "Masa":
                QuantityName = "Mass";
                break;
            case "Temperatura":
                QuantityName = "Temperature";
                break;
            case "Energia":
                QuantityName = "Energy";
                break;
            case "Area":
                QuantityName = "Area";
                break;
            case "Velocidad":
                QuantityName = "Speed";
                break;
            case "Duracion":
                QuantityName = "Duration";
                break;

        }

    }
    public void convertirUnidades() { 
    
        var result=
            UnitConverter
            .ConvertByName(Double.Parse(entryMedida.Text), QuantityName,
            pickerConvertir.SelectedItem.ToString(),
            pickerConvertido.SelectedItem.ToString()
            ).ToString();
        lblConvertido.Text = result;
    }

    private void entryMedida_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(!entryMedida.Text.Equals("") && cargado)
            convertirUnidades();
    }

    private void pickerConvertido_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cargado)
            convertirUnidades();
    }
}