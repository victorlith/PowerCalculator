using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using PowerCalculator.Model;
using CommunityToolkit.Mvvm.Input;

namespace PowerCalculator.ViewModels
{
    internal class ItemViewModel
    {   
        public string Descricao { get; set; }
        public double PotenciaWatts { get; set; }
        public double TempoDeUso { get; set; }
        public double ConsumoEnergia { get; set; }

        List<double> totalConsumo = new List<double>();

        public Item Item;

        public ObservableCollection<Item> Itens;


        private void CalculoConsumo()
        {
            ConsumoEnergia = (PotenciaWatts / 1000) * (TempoDeUso / 60);
            totalConsumo.Add(ConsumoEnergia);

            SomaTotalConsumo();
        }

        public string SomaTotalConsumo()
        {
            double sumConsumo = 0;
            foreach (double x in totalConsumo)
            {
                sumConsumo += x;
            }

            return $"{sumConsumo.ToString("N2")} kWh";
        }


        public ObservableCollection<Item> GetItems()
        {
            if (Itens == null)
                Itens = new ObservableCollection<Item>();

            CalculoConsumo();

            Item = new Item()
            {
                Descricao = this.Descricao,
                PotenciaWatts = this.PotenciaWatts,
                TempoDeUso = this.TempoDeUso,
                ConsumoEnergia = this.ConsumoEnergia
            };

            Itens.Add(Item);

            return Itens;
        }
    }
}




