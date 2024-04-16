using System.Collections.ObjectModel;
using PowerCalculator.Model;

namespace PowerCalculator.Pages;

public partial class MainPage : ContentPage
{
    ObservableCollection<Item> Itens;
    List<double> totalConsumo = new List<double>();

    int count = 0;
    private string _descricao;
    private double _potenciaWatts;
    private double _tempoDeUso;
    private double _consumoEnergia;

    public MainPage()
	{
		InitializeComponent();
	}

    private ObservableCollection<Item> GetItem()
    {
        if (Itens == null)
        {
            Itens = new ObservableCollection<Item>();
        }

        Item item = new Item() { Descricao = _descricao, PotenciaWatts = $"{_potenciaWatts} W", TempoDeUso = $"{_tempoDeUso} {(string)pickerUnidadeTempo.SelectedItem}", ConsumoEnergia = $"{_consumoEnergia.ToString("N2")} kWh" };

        Itens.Add(item);

        return Itens;

    }

    private void CalculoConsumo()
    {
        string unidadeTempo = (string)pickerUnidadeTempo.SelectedItem;

        switch (unidadeTempo)
        {
            case "min":
                _consumoEnergia = (_potenciaWatts / 1000) * (_tempoDeUso / 60);
                totalConsumo.Add(_consumoEnergia);
                break;

            case "hora":
                _consumoEnergia = (_potenciaWatts / 1000) * _tempoDeUso;
                break;
        }

        double sumConsumo = 0;
        foreach (double x in totalConsumo)
        {
            sumConsumo += x;
        }
        lbConsumoTotal.Text = $"{sumConsumo.ToString("N2")} kWh";
    }


    private void ButtonCalcular_Clicked(object sender, EventArgs e)
    {
        try
        {
            string msgErro = "Preencha os dois campos: \"Potência(W):\" e \"Tempo de Uso:\"";

            if (string.IsNullOrEmpty(entryDescricao.Text))
            {
                if (!string.IsNullOrEmpty(entryPotencia.Text) && !string.IsNullOrEmpty(entryTempoUso.Text))
                {
                    if (pickerUnidadeTempo.SelectedItem == null)
                    {
                        DisplayAlert("Atenção!", "Selecione a unidade de tempo: \"min\" ou \"hora\"", "OK");
                        return;
                    }

                    count++;
                    string msgText = $"Item {count}";
                    _descricao = msgText;
                    _potenciaWatts = int.Parse(entryPotencia.Text);
                    _tempoDeUso = double.Parse(entryTempoUso.Text);

                    CalculoConsumo();

                    collectionView1.ItemsSource = GetItem();
                }
                else
                {
                    DisplayAlert("Atenção!", msgErro, "OK");
                    return;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(entryPotencia.Text) && !string.IsNullOrEmpty(entryTempoUso.Text))
                {
                    if (pickerUnidadeTempo.SelectedItem == null)
                    {
                        DisplayAlert("Atenção!", "Selecione a unidade de tempo: \"min\" ou \"hora\"", "OK");
                        return;
                    }

                    _descricao = entryDescricao.Text;
                    _potenciaWatts = int.Parse(entryPotencia.Text);
                    _tempoDeUso = double.Parse(entryTempoUso.Text);

                    CalculoConsumo();

                    collectionView1.ItemsSource = GetItem();
                }
                else
                {
                    DisplayAlert("Atenção!", msgErro, "OK");
                    return;
                }

            }

        }
        catch (Exception ex)
        {

            DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sobre", "Developer by @yLith", "OK");
    }
}