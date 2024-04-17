using System.Collections.ObjectModel;

namespace PowerCalculator.Model;

internal class Item
{
    public string Descricao { get; set; }
    public double PotenciaWatts { get; set; }
    public double TempoDeUso { get; set; }
    public double ConsumoEnergia { get; set; }

}
