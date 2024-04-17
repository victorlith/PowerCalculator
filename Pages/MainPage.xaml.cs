using System.Collections;
using System.Collections.ObjectModel;
using PowerCalculator.Model;
using PowerCalculator.ViewModels;

namespace PowerCalculator.Pages;

public partial class MainPage : ContentPage
{
    int count = 0;
    ItemViewModel ivm;

    public MainPage()
	{
		InitializeComponent();

        ivm = new ItemViewModel();

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

                    count++;
                    string msgText = $"Item {count}";
                    ivm.Descricao = msgText;
                    ivm.PotenciaWatts = int.Parse(entryPotencia.Text);
                    ivm.TempoDeUso = double.Parse(entryTempoUso.Text);

                    collectionView1.ItemsSource = ivm.GetItems();
                    lbConsumoTotal.Text = ivm.SomaTotalConsumo();
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

                    count++;
                    ivm.Descricao = entryDescricao.Text;
                    ivm.PotenciaWatts = int.Parse(entryPotencia.Text);
                    ivm.TempoDeUso = double.Parse(entryTempoUso.Text);

                    collectionView1.ItemsSource = ivm.GetItems();
                    lbConsumoTotal.Text = ivm.SomaTotalConsumo();
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
        string textAbout = "";

        await DisplayAlert("Sobre", $"Developer by @yLith \n\n{textAbout}", "OK");
    }

    private void ToolbarItemClear_Clicked(object sender, EventArgs e)
    {
        collectionView1.ItemsSource = null;
        ivm = new ItemViewModel();
        count = 0;
        lbConsumoTotal.Text = "-- kWh";
    }
}