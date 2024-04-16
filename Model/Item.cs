using System.Collections.ObjectModel;

namespace PowerCalculator.Model;

internal class Item
{
    public string Descricao { get; set; }
    public string PotenciaWatts { get; set; }
    public string TempoDeUso { get; set; }
    public string ConsumoEnergia { get; set; }

    public ObservableCollection<Item> Itens = new ObservableCollection<Item>();
}
